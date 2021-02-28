using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Services;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        public OrderController(IMailService mailService, IRazorViewToStringRenderer razorViewToStringRenderer, ILogger<BaseController> logger) : base(logger)
        {
            this.mailService = mailService;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody]string paymentIntentId)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }

            if (checkout.Stage == Stage.payment)
            {
                var order = BuildOrder(checkout, paymentIntentId);
                var response = await PostRequest("/Order/PostOrder", order);

                var json = await GetRequest(response.Headers.Location.AbsolutePath);
                Models.Order newOrder = JsonConvert.DeserializeObject<Models.Order>(json);
                order = newOrder;
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var orderItems = new List<Models.OrderItem>();
                foreach (var item in checkout.BagItems)
                {
                    orderItems.Add(new Models.OrderItem { Quantity = item.Quantity, ProductId = item.ProductId, OrderId = order.Id });
                }
                var postRequest = await PostRequest("/Orderitem/PostOrderItems", orderItems);
                if (!postRequest.IsSuccessStatusCode)
                {
                    return NotFound();
                }
                order.OrderItems = orderItems;
                foreach(var item in order.OrderItems)
                {
                    foreach(var bagItem in checkout.BagItems)
                    {
                        if(bagItem.ProductId == item.ProductId)
                        {
                            item.Product = bagItem.Product;
                        }
                    }
                }

                await mailService.SendOrderEmailAsync(checkout, order);

                if (User.Identity.IsAuthenticated)
                {
                    var url = $"/BagItem/DeleteBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}";
                    var deleteRequest = await DeleteRequest(url);
                    if (!deleteRequest.IsSuccessStatusCode)
                    {
                        return NotFound(deleteRequest.StatusCode);
                    }
                }
                else
                {
                    HttpContext.Session.Set<List<BagItem>>(BagSessionKey, null);
                }

                checkout.Stage = Stage.completed;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                return Ok();
            }
            else
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }
        }

        private Models.Order BuildOrder(Checkout checkout, string paymentIntentId)
        {

            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                CustomerInfId = checkout.CustomerInf.Id,
                PaymentIntent_Id = paymentIntentId,
                ShippingDeliveryId = checkout.ShippingDeliveryId,
                Status = Status.Accepted,
                TotalPrice = checkout.TotalPrice
            };

            if (User.Identity.IsAuthenticated)
                order.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            return order;
        }

        private int CalculateOrderAmount(List<BagItem> items)
        {
            int price = 0;
            foreach (var item in items)
            {
                price += item.Product.Price;
            }
            return price;
        }
    }
}
