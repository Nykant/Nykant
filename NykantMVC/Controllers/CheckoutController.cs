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
using NykantMVC.Support;

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
            var checkout = CheckoutCookie.GetCheckout<Checkout>(Request);
            if (checkout == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var json = await GetRequest($"/BagItem/GetBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
                    var bagVM = JsonConvert.DeserializeObject<BagVM>(json);

                    Checkout checkoutNEW = new Checkout
                    {
                        BagItems = bagVM.BagItems,
                        Stage = Stage.customer,
                        TotalPrice = CalculateAmount(bagVM.BagItems)
                    };
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkoutNEW);
                    return View(checkoutNEW);
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
                        Checkout checkoutNEW = new Checkout
                        {
                            BagItems = bagItems,
                            Stage = Stage.customer,
                            TotalPrice = CalculateAmount(bagItems)
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkoutNEW);

                        return View(checkoutNEW);
                    }
                }
            }
            else
            {
                checkout.Stage = Stage.customer;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                return View(checkout);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(Models.Customer customer)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.Stage == Stage.customer)
            {
                checkout.Customer = customer;

                if (User.Identity.IsAuthenticated)
                    checkout.Customer.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                var response = await PostRequest("/Customer/PostCustomer", checkout.Customer);

                if (response.IsSuccessStatusCode)
                {
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
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if(checkout == null)
            {
                return NotFound();
            }
            else
            {
                checkout.Stage = Stage.shipping;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                return View(checkout);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostShipping(Models.Shipping shipping)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return NotFound();
            }

            shipping.Address = checkout.Customer.Address;
            shipping.City = checkout.Customer.City;
            shipping.Country = checkout.Customer.Country;
            shipping.Email = checkout.Customer.Email;
            shipping.FirstName = checkout.Customer.FirstName;
            shipping.LastName = checkout.Customer.LastName;
            shipping.Phone = checkout.Customer.Phone;
            shipping.Postal = checkout.Customer.Postal;

            if (checkout.Stage == Stage.shipping)
            {
                checkout.Shipping = shipping;

                var response = await PostRequest("/Shipping/PostShipping", checkout.Shipping);
                var json = await GetRequest(response.Headers.Location.AbsolutePath);
                var shippingNEW = JsonConvert.DeserializeObject<Models.Shipping>(json);

                if (response.IsSuccessStatusCode)
                {
                    checkout.Shipping = shippingNEW;
                    checkout.Stage = Stage.payment;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    return RedirectToAction("Payment");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Payment()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if(checkout == null)
            {
                return NotFound();
            }

            if(checkout.Stage == Stage.payment)
            {
                return View(checkout);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Success()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return NotFound();
            }
            if (checkout.Stage == Stage.completed)
            {
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                return View();
            }
            return NotFound();
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
    }
}
