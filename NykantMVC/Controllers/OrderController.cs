﻿using Microsoft.AspNetCore.Identity;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody]string paymentIntentId)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.Stage == Stage.completing)
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

                return NoContent();
            }
            else
            {
                return NotFound();
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
                CustomerEmail = checkout.Shipping.Email,
                PaymentIntent_Id = paymentIntentId,
                ShippingId = checkout.Shipping.ShippingId,
                Status = Status.Accepted,
                TotalPrice = checkout.TotalPrice,
                OrderItems = orderItems
            };
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
