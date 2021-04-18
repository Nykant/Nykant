using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class CheckoutController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public CheckoutController(ILogger<BaseController> logger, IProtectionService protectionService) : base(logger)
        {
            _protectionService = protectionService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            List<BagItem> bagItemsSession = new List<BagItem>();
            List<BagItem> bagItemsDb = new List<BagItem>();

            if (User.Identity.IsAuthenticated)
            {
                var jsonbagItems = await GetRequest($"/BagItem/GetBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
                bagItemsDb = JsonConvert.DeserializeObject<List<BagItem>>(jsonbagItems);
            }
            else
            {
                bagItemsSession = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
            }

            var jsonShippings = await GetRequest("/ShippingDelivery/GetShippingDeliveries");
            var shippingDeliveries = JsonConvert.DeserializeObject<List<ShippingDelivery>>(jsonShippings);

            if (checkout == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (bagItemsDb.Count() == 0)
                    {
                        return RedirectToAction("Details", "Bag");
                    }
                    else
                    {
                        checkout = new Checkout
                        {
                            BagItems = bagItemsDb,
                            Stage = Stage.customerInf,
                            TotalPrice = CalculateAmount(bagItemsDb).ToString(),
                            ShippingDelivery = new ShippingDelivery()
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                        CheckoutVM checkoutVM = new CheckoutVM
                        {
                            CustomerInf = new CustomerInf(),
                            ShippingDeliveries = shippingDeliveries,
                            Checkout = checkout,
                            CardInfo = new CardInfo(),
                        };

                        return View(checkoutVM);
                    }
                }
                else
                {
                    if (bagItemsSession == null)
                    {
                        return RedirectToAction("Details", "Bag");
                    }
                    if (bagItemsSession.Count() == 0)
                    {
                        return RedirectToAction("Details", "Bag");
                    }
                    else
                    {
                        checkout = new Checkout
                        {
                            BagItems = bagItemsSession,
                            Stage = Stage.customerInf,
                            TotalPrice = CalculateAmount(bagItemsSession).ToString(),
                            ShippingDelivery = new ShippingDelivery()
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                        CheckoutVM checkoutVM = new CheckoutVM
                        {
                            CustomerInf = new CustomerInf(),
                            ShippingDeliveries = shippingDeliveries,
                            Checkout = checkout,
                            CardInfo = new CardInfo()
                        };

                        return View(checkoutVM);
                    }
                }
            }
            else
            {
                if (bagItemsSession.Count() == 0 && bagItemsDb.Count() == 0)
                {
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);
                    return RedirectToAction("Details", "Bag");
                }
                CustomerInf customerInf = null;
                if(checkout.CustomerInfId != 0)
                {
                    var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                    customerInf = JsonConvert.DeserializeObject<CustomerInf>(jsonCustomer);
                    customerInf = _protectionService.UnProtectCustomerInf(customerInf);
                }
                else
                {
                    customerInf = new CustomerInf();
                }

                CheckoutVM checkoutVM = new CheckoutVM
                {
                    CustomerInf = customerInf,
                    ShippingDeliveries = shippingDeliveries,
                    Checkout = checkout
                };

                return View(checkoutVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInf(CustomerInf customerInf, bool editCustomer)
        {
            if (ModelState.IsValid)
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

                if (checkout.Stage == Stage.customerInf || editCustomer)
                {
                    customerInf = _protectionService.ProtectCustomerInf(customerInf);
                    var response = await PostRequest("/Customer/PostCustomer", customerInf);

                    if (response.IsSuccessStatusCode)
                    {
                        if (customerInf.Id == 0)
                        {
                            var json = await GetRequest(response.Headers.Location.AbsolutePath);
                            checkout.CustomerInfId = JsonConvert.DeserializeObject<CustomerInf>(json).Id;
                        }
                        else
                        {
                            checkout.CustomerInfId = customerInf.Id;
                        }

                        if (!editCustomer)
                        {
                            checkout.Stage = Stage.shipping;
                        }

                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                        return NoContent();
                    }
                    return Content("Noget gik galt, vær sød og kontakt support hvis det sker igen");
                }
                else
                {
                    return NoContent();
                }
            }
            return Content("Vær sød at udfylde alle nødvendige felter markeret med *");
        }

        [HttpPost]
        public async Task<IActionResult> PostShipping(ShippingDelivery shippingDelivery, bool editShipping)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

            if (checkout.Stage == Stage.shipping || editShipping)
            {
                checkout.ShippingDelivery = shippingDelivery;

                if (!editShipping)
                {
                    checkout.Stage = Stage.payment;
                }

                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                return NoContent();
            }
            else
            {
                return NoContent();
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

        [HttpPost]
        public async Task<IActionResult> CancelCheckout()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

            if(checkout.CustomerInfId != 0)
            {
                var response = await DeleteRequest($"/Customer/DeleteCustomerInf/{checkout.CustomerInfId}");

                if (!response.IsSuccessStatusCode)
                {
                    return Content("error :(");
                }
            }
            
            try
            {
                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                return RedirectToAction("Details", "Bag");
            }
            catch(Exception e)
            {
                return Content(e.Message);
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
