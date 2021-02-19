using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantMVC.Extensions;
using NykantMVC.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ILogger<BaseController> logger) : base(logger)
        {
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
                var postRequest = await PostRequest("/Order/PostOrder", order);
                if (!postRequest.IsSuccessStatusCode)
                {
                    return NotFound();
                }

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
            var orderItems = new List<Models.OrderItem>();
            foreach (var item in checkout.BagItems)
            {
                orderItems.Add(new Models.OrderItem { Quantity = item.Quantity, ProductId = item.ProductId });
            }

            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                CustomerInfId = checkout.CustomerInf.Id,
                PaymentIntent_Id = paymentIntentId,
                ShippingDeliveryId = checkout.ShippingDeliveryId,
                Status = Status.Accepted,
                TotalPrice = checkout.TotalPrice,
                OrderItems = orderItems
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
