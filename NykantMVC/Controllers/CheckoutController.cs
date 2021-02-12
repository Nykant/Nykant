using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {

        }

        [HttpGet]
        public async Task<IActionResult> CustomerInfo(BagVM bagVM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Bag");
            }

            CheckoutVM checkoutVM = new CheckoutVM
            {
                BagItems = bagVM.BagItems,
                PriceSum = bagVM.PriceSum
            };

            return View(checkoutVM);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerInfoCrumb(CheckoutVM checkoutVM)
        {
            return View("CustomerInfo", checkoutVM);
        }
        [HttpPost]
        public async Task<IActionResult> ShippingCrumb(CheckoutVM checkoutVM)
        {
            return View("Shipping", checkoutVM);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerInfo(CheckoutVM checkoutVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                checkoutVM.CustomerInfo.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                var customerInfoJson = new StringContent(
                    JsonConvert.SerializeObject(checkoutVM.CustomerInfo),
                    Encoding.UTF8,
                    "application/json");

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                string uri = "https://localhost:6001/api/CustomerInfo/PostCustomerInfo";
                var content = await client.PostAsync(uri, customerInfoJson);

                if (content.IsSuccessStatusCode)
                {
                    return View("Shipping", checkoutVM);
                }
                return Content("Failed");
            }

            return View("Shipping", checkoutVM);
        }

        [HttpGet]
        public async Task<IActionResult> Shipping(CheckoutVM checkoutVM)
        {
            return View(checkoutVM);
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<IActionResult> PostShipping(CheckoutVM checkoutVM)
        {
            // Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/account/apikeys
            StripeConfiguration.ApiKey = "sk_test_51Hyy3eKS99T7pxPWiw3m8vnWtHOQgSA2LO778AHP80OLEsntKcJXaej9Xye5zb1yOo85WZX9360L9X7YFyhRX68S00xUn0LWMS";

            var options = new PaymentIntentCreateOptions
            {
                Amount = 1099,
                Currency = "usd",
                // Verify your integration in this guide by including this parameter
                Metadata = new Dictionary<string, string>
                {
                    { "integration_check", "accept_a_payment" },
                },
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);
            ViewBag.ClientSecret = paymentIntent.ClientSecret;

            Models.Order order = new Models.Order
            {
                BagItems = checkoutVM.BagItems,
                CreatedAt = DateTime.Now,
                CustomerInfo = checkoutVM.CustomerInfo,
                ShippingOption = checkoutVM.ShippingOption,
                Status = Status.Created,
                Subject = checkoutVM.Subject,
                TotalPrice = checkoutVM.PriceSum,
                Valuta = Valuta.DKK,
                PIClientSecret = paymentIntent.ClientSecret
            };

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var orderJson = new StringContent(
                   JsonConvert.SerializeObject(order),
                   Encoding.UTF8,
                   "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Order/PostOrder/";
            var content = await client.PostAsync(uri, orderJson);

            if (content.IsSuccessStatusCode)
            {
                return View("Payment", checkoutVM);
            }
            return Content("Failed to create order");
        }

        [HttpPost]
        public async Task<IActionResult> PaymentProcess()
        {
            return View();
        }

        [HttpGet]
        [Route("{controller}/{action}/{email}")]
        public async Task<IActionResult> PaymentSuccess(string email)
        {
            ViewBag.Email = email;
            return View();
        }
    }
}
