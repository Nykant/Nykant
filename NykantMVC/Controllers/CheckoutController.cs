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
    [Route("{controller}/{action}/")]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {

        }

        [HttpGet("{edit?}")]
        public async Task<IActionResult> CustomerInf(bool? edit)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            List<BagItem> bagItemsSession = new List<BagItem>();
            List<BagItem> bagItemsDb = new List<BagItem>();

            if (User.Identity.IsAuthenticated)
            {
                var json = await GetRequest($"/BagItem/GetBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
                bagItemsDb = JsonConvert.DeserializeObject<BagVM>(json).BagItems;
            }
            else
            {
                bagItemsSession = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
            }

            if (checkout == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (bagItemsDb.Count() == 0)
                    {
                        return Content("No bag items to check out");
                    }
                    else
                    {
                        Checkout checkoutNEW = new Checkout
                        {
                            BagItems = bagItemsDb,
                            Stage = Stage.customerInf,
                            TotalPrice = CalculateAmount(bagItemsDb)
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkoutNEW);
                        return View(checkoutNEW);
                    }
                }
                else
                {
                    if(bagItemsSession == null)
                    {
                        return Content("No bag items to check out");
                    }
                    if (bagItemsSession.Count() == 0)
                    {
                        return Content("No bag items to check out");
                    }
                    else
                    {
                        Checkout checkoutNEW = new Checkout
                        {
                            BagItems = bagItemsSession,
                            Stage = Stage.customerInf,
                            TotalPrice = CalculateAmount(bagItemsSession)
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkoutNEW);

                        return View(checkoutNEW);
                    }
                }
            }

            if(edit == true)
            {
                checkout.Stage = Stage.customerInf;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
            }

            if (checkout.Stage == Stage.customerInf)
            {
                if (bagItemsSession.Count() == 0 && bagItemsDb.Count() == 0)
                {
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);
                    return Content("No bag items to check out");
                }
                return View(checkout);
            }
            else if(checkout.Stage == Stage.shippingDel)
            {
                if (bagItemsSession.Count() == 0 && bagItemsDb.Count() == 0)
                {
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);
                    return Content("No bag items to check out");
                }
                return RedirectToAction(nameof(ShippingDelivery));
            }
            else if (checkout.Stage == Stage.payment)
            {
                if (bagItemsSession.Count() == 0 && bagItemsDb.Count() == 0)
                {
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);
                    return Content("No bag items to check out");
                }
                return RedirectToAction(nameof(Payment));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInf(CustomerInf customerInf)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CustomerInf));
            }

            if (checkout.Stage == Stage.customerInf)
            {
                var response = await PostRequest("/Customer/PostCustomer", customerInf);

                if (response.IsSuccessStatusCode)
                {
                    if (customerInf.Id == 0)
                    {
                        var json = await GetRequest(response.Headers.Location.AbsolutePath);
                        CustomerInf customerInfNEW = JsonConvert.DeserializeObject<CustomerInf>(json);
                        checkout.CustomerInf = customerInfNEW;
                    }
                    else
                    {
                        checkout.CustomerInf = customerInf;
                    }

                    checkout.Stage = Stage.shippingDel;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    return RedirectToAction(nameof(ShippingDelivery));
                }
                return NotFound("Failed");
            }
            else
            {
                return RedirectToAction(nameof(CustomerInf));
            }
        }

        [HttpGet("{edit?}")]
        public async Task<IActionResult> ShippingDelivery(bool? edit)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if(checkout == null)
            {
                return RedirectToAction(nameof(CustomerInf));
            }

            if (edit == true)
            {
                checkout.Stage = Stage.shippingDel;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
            }

            if (checkout.Stage == Stage.shippingDel)
            {
                var json = await GetRequest($"/ShippingDelivery/GetShippingDeliveries");
                ViewBag.ShippingDeliveries = JsonConvert.DeserializeObject<List<ShippingDelivery>>(json);
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                return View(checkout);
            }
            else
            {
                return RedirectToAction(nameof(CustomerInf));
            }
        }

        [HttpPost]
        public IActionResult PostShippingDelivery(int shippingDeliveryId)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CustomerInf));
            }

            if (checkout.Stage == Stage.shippingDel)
            {
                checkout.ShippingDeliveryId = shippingDeliveryId;
                checkout.Stage = Stage.payment;
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                return RedirectToAction(nameof(Payment));
            }
            else
            {
                return RedirectToAction(nameof(CustomerInf));
            }
        }

        [HttpGet]
        public IActionResult Payment()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if(checkout == null)
            {
                return RedirectToAction(nameof(CustomerInf));
            }

            if(checkout.Stage == Stage.payment)
            {
                return View(checkout);
            }
            else
            {
                return RedirectToAction(nameof(CustomerInf));
            }
        }

        [HttpGet]
        public IActionResult Success()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return Content("Something went wrong");
            }

            if (checkout.Stage == Stage.completed)
            {
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                return View();
            }
            else
            {
                return Content("Something went wrong");
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
    }
}
