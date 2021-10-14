using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using NykantMVC.Models.XmlModels;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class CheckoutController : BaseController
    {
        private readonly IProtectionService _protectionService;

        public CheckoutController(ILogger<CheckoutController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
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
                        int.TryParse(CalculateAmount(bagItemsDb), out int total);
                        var taxes = total / 5;
                        checkout = new Checkout
                        {
                            BagItems = bagItemsDb,
                            Stage = Stage.customerInf,
                            TotalPrice = total.ToString(),
                            ShippingDelivery = new ShippingDelivery { ParcelshopData = new ParcelshopData() },
                            Taxes = taxes.ToString(),
                            SubTotalPrice = total.ToString()
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                        CheckoutVM checkoutVM = new CheckoutVM
                        {
                            Customer = new Customer 
                            { 
                                BillingAddress = new BillingAddress(),
                                ShippingAddress = new ShippingAddress()
                            },
                            Checkout = checkout,
                            ShippingDelivery = new ShippingDelivery { ParcelshopData = new ParcelshopData() }
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
                        int.TryParse(CalculateAmount(bagItemsSession), out int total);
                        var taxes = total / 5;
                        checkout = new Checkout
                        {
                            BagItems = bagItemsSession,
                            Stage = Stage.customerInf,
                            TotalPrice = total.ToString(),
                            ShippingDelivery = new ShippingDelivery { ParcelshopData = new ParcelshopData() },
                            Taxes = taxes.ToString(),
                            SubTotalPrice = total.ToString()
                        };
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                        CheckoutVM checkoutVM = new CheckoutVM
                        {
                            Customer = new Customer
                            {
                                BillingAddress = new BillingAddress(),
                                ShippingAddress = new ShippingAddress()
                            },
                            Checkout = checkout,
                            ShippingDelivery = new ShippingDelivery { ParcelshopData = new ParcelshopData() }
                        };

                        return View(checkoutVM);
                    }
                }
            }
            else
            {
                double taxes = 0;
                double total = 0;
                if (User.Identity.IsAuthenticated)
                {
                    double.TryParse(CalculateAmount(bagItemsDb), out double subtotal);
                    if(checkout.ShippingDelivery.Price != 0)
                    {
                        total = subtotal + checkout.ShippingDelivery.Price;
                    }
                    else
                    {
                        total = subtotal;
                    }
                    taxes = total / 5;

                    checkout.TotalPrice = subtotal.ToString();
                    checkout.Taxes = taxes.ToString();
                    checkout.SubTotalPrice = subtotal.ToString();

                    checkout.BagItems = bagItemsDb;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                }
                else
                {
                    double.TryParse(CalculateAmount(bagItemsSession), out double subtotal);
                    if (checkout.ShippingDelivery.Price != 0)
                    {
                        total = subtotal + checkout.ShippingDelivery.Price;
                    }
                    else
                    {
                        total = subtotal;
                    }
                    taxes = total / 5;

                    checkout.TotalPrice = subtotal.ToString();
                    checkout.Taxes = taxes.ToString();
                    checkout.SubTotalPrice = subtotal.ToString();

                    checkout.BagItems = bagItemsSession;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                }

                if (bagItemsSession.Count() == 0 && bagItemsDb.Count() == 0)
                {
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);
                    return RedirectToAction("Details", "Bag");
                }

                Customer customer = null;
                if(checkout.CustomerInfId != 0)
                {
                    var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                    customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                    customer = _protectionService.UnprotectCustomer(customer);
                }
                else
                {
                    customer = new Customer { BillingAddress = new BillingAddress(), ShippingAddress = new ShippingAddress() };
                }

                customer = EncodeCustomer(customer);

                CheckoutVM checkoutVM = new CheckoutVM
                {
                    Customer = customer,
                    Checkout = checkout,
                    ShippingDelivery = checkout.ShippingDelivery
                };

                return View(checkoutVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInf(Customer customer, bool editCustomer)
        {
            try
            {
                if (customer.ShippingAddress.SameAsBilling)
                {
                    customer.ShippingAddress.Postal = customer.BillingAddress.Postal;
                    customer.ShippingAddress.LastName = customer.BillingAddress.LastName;
                    customer.ShippingAddress.FirstName = customer.BillingAddress.FirstName;
                    customer.ShippingAddress.Address = customer.BillingAddress.Address;
                    customer.ShippingAddress.Country = customer.BillingAddress.Country;
                    customer.ShippingAddress.City = customer.BillingAddress.City;
                }

                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                Customer old;
                if (editCustomer)
                {
                    old = await GetCustomer(checkout.CustomerInfId);
                    customer.ShippingAddress.Id = old.ShippingAddress.Id;
                    customer.BillingAddress.Id = old.BillingAddress.Id;
                    customer.Id = old.Id;
                }
                if (checkout.Stage == Stage.customerInf || editCustomer)
                {
                    customer = _protectionService.ProtectCustomer(customer);
                    var response = await PostRequest("/Customer/PostCustomer/", new Customer { Email = customer.Email, Phone = customer.Phone, Id = customer.Id });
                    if (response.IsSuccessStatusCode)
                    {
                        if (!editCustomer)
                        {
                            if (customer.Id == 0)
                            {
                                var json = await GetRequest(response.Headers.Location.AbsolutePath);
                                checkout.CustomerInfId = JsonConvert.DeserializeObject<Customer>(json).Id;
                                customer.Id = checkout.CustomerInfId;
                            }
                            else
                            {
                                checkout.CustomerInfId = customer.Id;
                                customer.Id = checkout.CustomerInfId;
                            }
                        }

                        var shippingAddress = _protectionService.ProtectShippingAddress(customer.ShippingAddress);
                        shippingAddress.CustomerId = customer.Id;
                        var postResponse = await PostRequest("/Customer/PostShippingAddress", shippingAddress);
                        if (postResponse.IsSuccessStatusCode)
                        {

                            var invoiceAddress = _protectionService.ProtectBillingAddress(customer.BillingAddress);
                            invoiceAddress.CustomerId = customer.Id;
                            var postResponse2 = await PostRequest("/Customer/PostBillingAddress", invoiceAddress);
                            if (postResponse2.IsSuccessStatusCode)
                            {
                                if (!editCustomer)
                                {
                                    checkout.Stage = Stage.shipping;
                                }

                                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                                return NoContent();
                            }
                            else
                            {
                                return Json(new { error = "Could not post billing" });
                            }
                        }
                        else
                        {
                            return Json(new { error = "Could not post shipping" });
                        }
                    }
                    else
                    {
                        return Json(new { error = "Could not post customer" });
                    }
                }
                else
                {
                    return Json(new { error = "Wrong stage" });
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return Json(new { error = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostShipping(ShippingDelivery shippingDelivery, bool editShipping)
        {
            try
            {
                if(shippingDelivery.Type == "Home")
                {
                    shippingDelivery.Price = 65;
                }
                else if(shippingDelivery.Type == "Shop")
                {
                    shippingDelivery.Price = 0;
                }
                else
                {
                    return Json(new { error = "An unexpected error has occured" });
                }

                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

                if (checkout.Stage == Stage.shipping || editShipping)
                {
                    checkout.ShippingDelivery = shippingDelivery;

                    if (!editShipping)
                    {
                        checkout.Stage = Stage.payment;
                    }

                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    return Json(new { shippingPrice = shippingDelivery.Price });
                }
                else
                {
                    return Json(new { error = "checkout stage is not correct" });
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return Json(new { error = e.Message });
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

        [HttpGet]
        public async Task<IActionResult> CancelCheckout()
        {
            try
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

                if (checkout.CustomerInfId != 0)
                {
                    var response = await DeleteRequest($"/Customer/DeleteCustomerInf/{checkout.CustomerInfId}");

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation(response.ReasonPhrase);
                    }
                }

                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                return RedirectToAction("Details", "Bag");
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                return RedirectToAction("Details", "Bag");
            }
        }

        private string CalculateAmount(List<BagItem> items)
        {
            double price = 0;
            foreach (var item in items)
            {
                price += item.Product.Price * item.Quantity;
            }
            return price.ToString();
        }

        private async Task<Customer> GetCustomer(int id)
        {
            Customer customer;
            var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{id}");
            customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
            customer = _protectionService.UnprotectCustomer(customer);
            return customer;
        }

        [HttpGet]
        public async Task<ParcelShopSearchResult> GetNearbyShopsJson(GlsAddress glsAddress)
        {
            var shops = await GetNearbyShops(glsAddress);
            return shops;
        }
    }
}
