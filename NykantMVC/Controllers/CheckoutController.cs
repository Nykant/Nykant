using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        public CheckoutController(ILogger<BaseController> logger, IProtectionService protectionService, IOptions<Urls> urls) : base(logger, urls)
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
                            Customer = new Customer 
                            { 
                                InvoiceAddress = new InvoiceAddress(),
                                ShippingAddress = new ShippingAddress()
                            },
                            ShippingDeliveries = shippingDeliveries,
                            Checkout = checkout
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
                            Customer = new Customer
                            {
                                InvoiceAddress = new InvoiceAddress(),
                                ShippingAddress = new ShippingAddress()
                            },
                            ShippingDeliveries = shippingDeliveries,
                            Checkout = checkout
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
                Customer customerInf = null;
                if(checkout.CustomerInfId != 0)
                {
                    var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                    customerInf = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                    customerInf = _protectionService.UnProtectCustomer(customerInf);
                }
                else
                {
                    customerInf = new Customer();
                }

                CheckoutVM checkoutVM = new CheckoutVM
                {
                    Customer = new Customer
                    {
                        InvoiceAddress = new InvoiceAddress(),
                        ShippingAddress = new ShippingAddress()
                    },
                    ShippingDeliveries = shippingDeliveries,
                    Checkout = checkout
                };

                return View(checkoutVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInf(Customer customer, bool editCustomer)
        {
            if (customer.ShippingAddress.SameAsInvoice)
            {
                customer.ShippingAddress.Address = customer.InvoiceAddress.Address;
                customer.ShippingAddress.City = customer.InvoiceAddress.City;
                customer.ShippingAddress.Country = customer.InvoiceAddress.Country;
                customer.ShippingAddress.FirstName = customer.InvoiceAddress.FirstName;
                customer.ShippingAddress.LastName = customer.InvoiceAddress.LastName;
                customer.ShippingAddress.Postal = customer.InvoiceAddress.Postal;
            }
            if (ModelState.IsValid)
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

                if (checkout.Stage == Stage.customerInf || editCustomer)
                {
                    customer = _protectionService.ProtectCustomer(customer);
                    var response = await PostRequest("/Customer/PostCustomer/", new Customer { Email = customer.Email, Phone = customer.Phone });
                    if (response.IsSuccessStatusCode)
                    {
                        if (customer.Id == 0)
                        {
                            var json = await GetRequest(response.Headers.Location.AbsolutePath);
                            checkout.CustomerInfId = JsonConvert.DeserializeObject<Customer>(json).Id;
                        }
                        else
                        {
                            checkout.CustomerInfId = customer.Id;
                        }

                        var shippingAddress = _protectionService.ProtectShippingAddress(customer.ShippingAddress);
                        shippingAddress.CustomerId = checkout.CustomerInfId;
                        var postResponse = await PostRequest("/Customer/PostShippingAddress", shippingAddress);

                        var invoiceAddress = _protectionService.ProtectInvoiceAddress(customer.InvoiceAddress);
                        invoiceAddress.CustomerId = checkout.CustomerInfId;
                        var postResponse2 = await PostRequest("/Customer/PostInvoiceAddress", invoiceAddress);

                        hmmmm
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
                return Json(new { error = "checkout stage is not correct" });
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
