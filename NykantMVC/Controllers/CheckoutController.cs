using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.DTO;
using NykantMVC.ViewModels;
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
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {

        }

        [HttpGet]
        public async Task<IActionResult> CustomerInfo()
        {
            var subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Bag", new { subject });
            }
            
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Checkout/GetCheckoutInfo/" + subject;
            var result = await client.GetStringAsync(uri);
            
            CheckoutVM checkoutVM = JsonConvert.DeserializeObject<CheckoutVM>(result);
            if (checkoutVM == null)
            {
                return NotFound();
            }

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
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            checkoutVM.CustomerInfo.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            var customerInfoJson = new StringContent(
                JsonConvert.SerializeObject(checkoutVM.CustomerInfo),
                Encoding.UTF8,
                "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/CustomerInfo/PostCustomerInfo/" + checkoutVM.CustomerInfo;
            var content = await client.PostAsync(uri, customerInfoJson);

            if (content.IsSuccessStatusCode)
            {
                return View("Shipping", checkoutVM);
            }
            return Content("Failed");
        }

        [Route("checkout")]
        [HttpPost]
        public async Task<IActionResult> Shipping(CheckoutVM checkoutVM)
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

            return View("Payment", checkoutVM);
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
