using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {

        }

        [HttpGet]
        public IActionResult CustomerInfo(BagVM bagVM)
        {
            if (ModelState.IsValid)
            {
                CheckoutVM checkoutVM = new CheckoutVM
                {
                    BagItems = bagVM.BagItems,
                    PriceSum = bagVM.PriceSum
                };
                return View(checkoutVM);  
            }

            return RedirectToAction("Details", "Bag");
        }

        [HttpGet]
        public IActionResult CustomerInfoCrumb(CheckoutVM checkoutVM)
        {
            return View("CustomerInfo", checkoutVM);
        }

        [HttpGet]
        public IActionResult ShippingCrumb(CheckoutVM checkoutVM)
        {
            return View("Shipping", checkoutVM);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInfo(CheckoutVM checkoutVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                checkoutVM.CustomerInfo.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                var order = BuildOrder(checkoutVM);
                checkoutVM.Order = order;

                var response = await PostRequest("CustomerInfo/PostCustomerInfo", checkoutVM);

                if (response.IsSuccessStatusCode)
                {
                    return View("Shipping", checkoutVM);
                }
                return Content("Failed");
            }

            return View("Shipping", checkoutVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddShipping(CheckoutVM checkoutVM)
        {

            Models.Order order = new Models.Order
            {
                 CustomerInfoEmail = checkoutVM.CustomerInfo.Email,
                 ShippingOptionName = checkoutVM.ShippingOption.Name,
            };

            var response = await PatchRequest("Order/UpdateOrder", order);
            checkoutVM.ClientSecret = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return View("Payment", checkoutVM);
            }
            return Content("Failed to create order");
        }

        [HttpPost]
        [Route("create-payment-intent")]
        public ActionResult CreatePaymentIntent([FromBody]PaymentIntentCreateRequest request)
        {
            StripeConfiguration.ApiKey = "sk_test_51Hyy3eKS99T7pxPWiw3m8vnWtHOQgSA2LO778AHP80OLEsntKcJXaej9Xye5zb1yOo85WZX9360L9X7YFyhRX68S00xUn0LWMS";

            var options = new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(request.Items),
                Currency = "dkk",
                Metadata = new Dictionary<string, string>
                {
                    { "integration_check", "accept_a_payment" },
                },
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }
        private int CalculateOrderAmount(Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 1400;
        }
        public class PaymentIntentCreateRequest
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }
        }
        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        [HttpPost]
        public IActionResult PaymentProcess()
        {
            return NoContent();
        }
        
        [HttpGet]
        [Route("{controller}/{action}/{email}")]
        public async Task<IActionResult> PaymentSuccess(string email)
        {
            ViewBag.Email = email;

            Models.Order order = new Models.Order
            {
                CustomerInfoEmail = email,
                Status = Status.Accepted
            };

            var response = await PatchRequest("Order/UpdateOrder", order);

            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            return Content("Failed to Accept order");
        }



        private Models.Order BuildOrder(CheckoutVM checkoutVM)
        {
            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Status = Status.Created,
                Subject = checkoutVM.Subject,
                TotalPrice = checkoutVM.PriceSum,
                CustomerInfoEmail = checkoutVM.CustomerInfo.Email
            };
            return order;
        }

        
    }
}
