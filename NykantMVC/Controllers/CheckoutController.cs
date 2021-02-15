using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
using NykantMVC.Extensions;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Customer()
        {
            if (User.Identity.IsAuthenticated)
            {
                var json = await GetRequest($"BagItem/GetBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
                var bagVM = JsonConvert.DeserializeObject<BagVM>(json);

                Checkout checkout = new Checkout
                {
                    BagItems = bagVM.BagItems,
                    Stage = Stage.customer
                };
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                return View(checkout);
            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                if (bagItems == null)
                {
                    return NotFound();
                }
                else
                {
                    Checkout checkout = new Checkout
                    {
                        BagItems = bagItems,
                        Stage = Stage.customer,
                        TotalPrice = CalculateAmount(bagItems)
                    };
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                    return View(checkout);
                }
            }
        }

        private int CalculateAmount(List<BagItem> items)
        {
            int price = 0;
            foreach (var item in items)
            {
                price += item.Product.Price;
            }
            return price;
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(Models.Customer customer)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            checkout.Customer = customer;
            

            if (checkout.Stage == Stage.customer)
            {
                if(User.Identity.IsAuthenticated)
                checkout.Customer.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                var response = await PostRequest("CustomerInfo/PostCustomerInfo", checkout.Customer);

                if (response.IsSuccessStatusCode)
                {
                    checkout.Stage = Stage.shipping;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    return RedirectToAction("Shipping");
                }
                return Content("Failed");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Shipping()
        {
            return View(HttpContext.Session.Get<Checkout>(CheckoutSessionKey));
        }

        [HttpPost]
        public async Task<IActionResult> PostShipping(Models.Shipping shipping)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

            if (checkout.Stage == Stage.shipping)
            {
                var response = await PostRequest("Shipping/PostShipping", shipping);
                var content = response.Content;
                if (response.IsSuccessStatusCode)
                {
                    checkout.Shipping = shipping;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    return RedirectToAction("Payment");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View(HttpContext.Session.Get<Checkout>(CheckoutSessionKey));
        }
    }
}
