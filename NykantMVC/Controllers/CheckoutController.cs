using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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
        private readonly IHostEnvironment env;
        private IConfiguration conf;
        public CheckoutController(ILogger<CheckoutController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IHostEnvironment env, IConfiguration conf) : base(logger, urls, htmlEncoder)
        {
            _protectionService = protectionService;
            this.env = env;
            this.conf = conf;
        }

        [Route("Kassen")]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                List<BagItem> bagItemsSession = new List<BagItem>();
                List<BagItem> bagItemsDb = new List<BagItem>();

                ViewBag.StripePKKey = conf["StripePKKey"];

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
                            double.TryParse(CalculateAmount(bagItemsDb), out double total);
                            var taxes = total / 5;
                            var taxlessPrice = total - taxes;
                            checkout = new Checkout
                            {
                                BagItems = bagItemsDb,
                                Stage = Stage.customerInf,
                                TotalPrice = total.ToString(),
                                Taxes = taxes.ToString(),
                                TaxlessPrice = taxlessPrice.ToString()
                            };
                            HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                            CheckoutVM checkoutVM = new CheckoutVM
                            {
                                Customer = new Customer
                                {
                                    BillingAddress = new BillingAddress(),
                                    ShippingAddress = new ShippingAddress()
                                },
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
                            double.TryParse(CalculateAmount(bagItemsSession), out double total);
                            var taxes = total / 5;
                            var taxlessPrice = total - taxes;
                            checkout = new Checkout
                            {
                                BagItems = bagItemsSession,
                                Stage = Stage.customerInf,
                                TotalPrice = total.ToString(),
                                Taxes = taxes.ToString(),
                                TaxlessPrice = taxlessPrice.ToString()
                            };
                            HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                            CheckoutVM checkoutVM = new CheckoutVM
                            {
                                Customer = new Customer
                                {
                                    BillingAddress = new BillingAddress(),
                                    ShippingAddress = new ShippingAddress()
                                },
                                Checkout = checkout
                            };

                            return View(checkoutVM);
                        }
                    }
                }
                else
                {
                    if (checkout.Stage == Stage.completed)
                    {
                        return RedirectToAction("Success", "Checkout");
                    }

                    if (bagItemsSession.Count() == 0 && bagItemsDb.Count() == 0)
                    {
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);
                        return RedirectToAction("Details", "Bag");
                    }

                    if (User.Identity.IsAuthenticated)
                    {
                        double.TryParse(CalculateAmount(bagItemsDb), out double total);
                        var taxes = total / 5;
                        var taxlessPrice = total - taxes;

                        checkout.TotalPrice = total.ToString();
                        checkout.Taxes = taxes.ToString();
                        checkout.TaxlessPrice = taxlessPrice.ToString();

                        checkout.BagItems = bagItemsDb;
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    }
                    else
                    {
                        double.TryParse(CalculateAmount(bagItemsSession), out double total);
                        var taxes = total / 5;
                        var taxlessPrice = total - taxes;

                        checkout.TotalPrice = total.ToString();
                        checkout.Taxes = taxes.ToString();
                        checkout.TaxlessPrice = taxlessPrice.ToString();

                        checkout.BagItems = bagItemsSession;
                        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
                    }

                    Customer customer = null;
                    if (checkout.CustomerInfId != 0)
                    {
                        var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                        customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                        customer = _protectionService.UnprotectCustomer(customer);
                        customer.ShippingAddress = _protectionService.UnprotectShippingAddress(customer.ShippingAddress);
                        customer.BillingAddress = _protectionService.UnprotectBillingAddress(customer.BillingAddress);
                    }
                    else
                    {
                        customer = new Customer { BillingAddress = new BillingAddress(), ShippingAddress = new ShippingAddress() };
                    }

                    customer = EncodeCustomer(customer);

                    CheckoutVM checkoutVM = new CheckoutVM
                    {
                        Customer = customer,
                        Checkout = checkout
                    };

                    return View(checkoutVM);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInf(Customer customer, bool editCustomer)
        {
            try
            {
                if (customer.BillingAddress.Country == "Danmark")
                {
                    customer.BillingAddress.Country = "DK";
                }

                if (customer.PrivacyPolicyConsent == "true")
                {
                    Consent consent = new Consent
                    {
                        Name = customer.BillingAddress.Name,
                        Email = customer.Email,
                        Date = DateTime.Now,
                        ButtonText = "Gem",
                        ConsentText = "For at fortsætte skal du skrive under på at du har læst og accepterer vores (link (håndtering af persondata)) ved at klikke i checkboksen.",
                        How = ConsentHow.Checkbox,
                        Type = ConsentType.PrivacyPolicy,
                        Status = ConsentStatus.Given
                    };
                    consent = _protectionService.ProtectConsent(consent);
                    PostRequest("/Consent/Post", consent).ConfigureAwait(false);
                    //if (!consentResponse.IsSuccessStatusCode)
                    //{
                    //    _logger.LogInformation($"{consentResponse.ReasonPhrase} - {consentResponse.StatusCode}");
                    //    return Json(new { error = "Could not post consent" });
                    //}
                }
                else
                {
                    _logger.LogError("error: User has not consented - an error has occured");
                    return Json(new { error = "User has not consented - an error has occured" });
                }

                if (customer.ShippingAddress.SameAsBilling)
                {
                    customer.ShippingAddress.Postal = customer.BillingAddress.Postal;
                    customer.ShippingAddress.Name = customer.BillingAddress.Name;
                    customer.ShippingAddress.Address = customer.BillingAddress.Address;
                    customer.ShippingAddress.Country = customer.BillingAddress.Country;
                    customer.ShippingAddress.City = customer.BillingAddress.City;
                }

                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                Customer old;
                if (editCustomer)
                {
                    old = await GetCustomerNoUnprotect(checkout.CustomerInfId);
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
                                    checkout.Stage = Stage.payment;
                                }

                                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                                return NoContent();
                            }
                            else
                            {
                                _logger.LogError("error: Could not post billing");
                                return Json(new { error = "Could not post billing" });
                            }
                        }
                        else
                        {
                            _logger.LogError("error: Could not post shipping");
                            return Json(new { error = "Could not post shipping" });
                        }
                    }
                    else
                    {
                        _logger.LogError("error: Could not post customer");
                        return Json(new { error = "Could not post customer" });
                    }
                }
                else
                {
                    _logger.LogError("error: Wrong stage");
                    return Json(new { error = "Wrong stage" });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Json(new { error = e.Message });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> PostShipping(ShippingDelivery shippingDelivery, bool editShipping)
        //{
        //    try
        //    {
        //        var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

        //        if (checkout.Stage == Stage.shipping || editShipping)
        //        {
        //            checkout.ShippingDelivery = shippingDelivery;

        //            if (!editShipping)
        //            {
        //                checkout.Stage = Stage.payment;
        //            }

        //            HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);
        //            return Json(new { shippingPrice = 0 });
        //        }
        //        else
        //        {
        //            return Json(new { error = "checkout stage is not correct" });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogInformation(e.Message);
        //        return Json(new { error = e.Message });
        //    }
        //}

        [Route("Bestilling-Gennemført")]
        [HttpGet]
        public async Task<IActionResult> Success()
        {
            try
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                if (checkout == null)
                {
                    return RedirectToAction("Details", "Bag");
                }

                if (checkout.Stage == Stage.completed)
                {
                    var json = await GetRequest($"/Order/GetOrder/{checkout.ShippingDelivery.OrderId}");
                    var order = JsonConvert.DeserializeObject<Order>(json);
                    order = _protectionService.UnprotectWholeOrder(order);
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                    return View(order);
                }
                else
                {
                    return RedirectToAction("Details", "Bag");
                }
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
            }
            return NoContent();
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
                        _logger.LogError(response.ReasonPhrase);
                    }
                }

                HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                return RedirectToAction("Details", "Bag");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
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

        private async Task<Customer> GetCustomerNoUnprotect(int id)
        {
            Customer customer;
            var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{id}");
            customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
            return customer;
        }

        //[HttpPost]
        //public async Task<ParcelShopSearchResult> GetNearbyShopsJson(GlsAddress glsAddress)
        //{
        //    var shops = await GetNearbyShops(glsAddress);
        //    return shops;
        //}
    }
}
