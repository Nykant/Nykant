using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace NykantMVC.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IProtectionService _protectionService;
        public OrderController(IMailService mailService, ILogger<BaseController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
            this.mailService = mailService;
            _protectionService = protectionService;
        }

        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            var json = await GetRequest($"/Order/GetOrders/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var json = await GetRequest($"/Order/GetOrder/{id}");
            var order = JsonConvert.DeserializeObject<Models.Order>(json);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody]string paymentIntentId)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CheckoutController.Checkout));
            }

            if (checkout.Stage == Stage.payment)
            {
                var order = BuildOrder(checkout, paymentIntentId);
                var response = await PostRequest("/Order/PostOrder", order);
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                var json = await GetRequest(response.Headers.Location.AbsolutePath);
                Models.Order newOrder = JsonConvert.DeserializeObject<Models.Order>(json);
                order = newOrder;
                if (!response.IsSuccessStatusCode)
                {
                    return NotFound();
                }

                checkout.ShippingDelivery.OrderId = order.Id;
                var postShipping = await PostRequest("/ShippingDelivery/Post", checkout.ShippingDelivery);

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

                var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                var customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                customer = _protectionService.UnprotectCustomer(customer);

                json = await GetRequest($"/Order/GetOrder/{order.Id}");
                order = JsonConvert.DeserializeObject<Models.Order>(json);

                await mailService.SendOrderEmailAsync(customer, order);

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
                    HttpContext.Session.Set<int>(BagItemAmountKey, 0);
                }

                checkout.Stage = Stage.completed;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                return Ok();
            }
            else
            {
                return RedirectToAction(nameof(CheckoutController.Checkout));
            }
        }

        private Models.Order BuildOrder(Checkout checkout, string paymentIntentId)
        {

            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                CustomerId = checkout.CustomerInfId,
                PaymentIntent_Id = paymentIntentId,
                Status = Status.Pending,
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
