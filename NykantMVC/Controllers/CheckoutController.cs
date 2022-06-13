using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Friends;
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
        public CheckoutController(ILogger<CheckoutController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IHostEnvironment env, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
            _protectionService = protectionService;
            this.env = env;
        }

        [Route("Kassen")]
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                Coupon coupon = null;
                var couponCode = HttpContext.Session.Get<string>(CouponCodeKey);
                if(couponCode != null)
                {
                    var json = await GetRequest($"/Coupon/Get/{couponCode}");
                    if (json != "null")
                    {
                        coupon = JsonConvert.DeserializeObject<Coupon>(json);
                    }
                }

                List<BagItem> bagItems = new List<BagItem>();

                ViewBag.StripePKKey = conf["StripePKKey"];

                if (User.Identity.IsAuthenticated)
                {
                    var jsonbagItems = await GetRequest($"/BagItem/GetBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
                    bagItems = JsonConvert.DeserializeObject<List<BagItem>>(jsonbagItems);
                }
                else
                {
                    bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                }

                if(bagItems == null || bagItems.Count() == 0)
                {
                    return RedirectToAction("Details", "Bag");
                }

                Checkout checkout = new Checkout();

                var total = OrderHelpers.CalculateTotal(bagItems);
                long discount = OrderHelpers.CalculateDiscount(bagItems);
                var taxes = total / 5;
                var taxlessPrice = total - taxes;

                if (coupon == null)
                {
                    checkout = new Checkout
                    {
                        BagItems = bagItems,
                        Stage = Stage.customerInf,
                        Discount = discount.ToString(),
                        TotalPrice = total.ToString(),
                        Taxes = taxes.ToString(),
                        TaxlessPrice = taxlessPrice.ToString()
                    };
                    ViewBag.DeliveryType = OrderHelpers.CalculateDeliveryTypeString(bagItems);
                }
                else
                {
                    checkout = new Checkout
                    {
                        Coupon = coupon,
                        BagItems = bagItems,
                        Stage = Stage.customerInf,
                        Discount = discount.ToString(),
                        TotalPrice = total.ToString(),
                        Taxes = taxes.ToString(),
                        TaxlessPrice = taxlessPrice.ToString()
                    };
                    ViewBag.DeliveryType = OrderHelpers.CalculateDeliveryTypeString(bagItems);
                }

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

                //if (checkout == null)
                //{

                //}
                //else
                //{
                //    if (checkout.Stage == Stage.completed)
                //    {
                //        return RedirectToAction("Success", "Checkout");
                //    }

                //    checkout.TotalPrice = total.ToString();
                //    checkout.Taxes = taxes.ToString();
                //    checkout.TaxlessPrice = taxlessPrice.ToString();
                //    ViewBag.DeliveryType = OrderHelpers.CalculateDeliveryTypeString(bagItems);
                //    checkout.BagItems = bagItems;
                //    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                //    Customer customer = null;
                //    if (checkout.CustomerId != 0)
                //    {
                //        var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerId}");
                //        customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                //    }
                //    else
                //    {
                //        customer = new Customer { BillingAddress = new BillingAddress(), ShippingAddress = new ShippingAddress() };
                //    }

                //    //customer = EncodeCustomer(customer);

                //    CheckoutVM checkoutVM = new CheckoutVM
                //    {
                //        Customer = customer,
                //        Checkout = checkout
                //    };

                //    return View(checkoutVM);
                //}
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
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

                //if (customer.PrivacyPolicyConsent == "true")
                //{
                //    Consent consent = new Consent
                //    {
                //        Name = customer.BillingAddress.Name,
                //        Email = customer.Email,
                //        Date = DateTime.Now,
                //        ButtonText = "Gem",
                //        ConsentText = "For at fortsætte skal du skrive under på at du har læst og accepterer vores (link (håndtering af persondata)) ved at klikke i checkboksen.",
                //        How = ConsentHow.Checkbox,
                //        Type = ConsentType.PrivacyPolicy,
                //        Status = ConsentStatus.Given
                //    };
                //    PostRequest("/Consent/Post", consent).ConfigureAwait(false);
                //    //if (!consentResponse.IsSuccessStatusCode)
                //    //{
                //    //    _logger.LogInformation($"{consentResponse.ReasonPhrase} - {consentResponse.StatusCode}");
                //    //    return Json(new { error = "Could not post consent" });
                //    //}
                //}
                //else
                //{
                //    _logger.LogError($"time: {DateTime.Now} - error: User has not consented - an error has occured");
                //    return Json(new { error = "User has not consented - an error has occured" });
                //}

                if (customer.ShippingAddress.SameAsBilling)
                {
                    customer.ShippingAddress.Postal = customer.BillingAddress.Postal;
                    customer.ShippingAddress.Name = customer.BillingAddress.Name;
                    customer.ShippingAddress.Address = customer.BillingAddress.Address;
                    customer.ShippingAddress.Country = customer.BillingAddress.Country;
                    customer.ShippingAddress.City = customer.BillingAddress.City;
                }

                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

                if (checkout.Stage == Stage.customerInf || editCustomer)
                {
                   
                    checkout.Customer = _protectionService.ProtectCustomer(customer);

                    if (!editCustomer)
                    {
                        checkout.Stage = Stage.payment;
                    }

                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                    return NoContent();
                }
                else
                {
                    _logger.LogError($"time: {DateTime.Now} - error: Wrong stage");
                    return Json(new { error = "Wrong stage" });
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
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
                    var json = await GetRequest($"/Order/GetOrder/{checkout.OrderId}");
                    var order = JsonConvert.DeserializeObject<Order>(json);
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

                    return View(order);
                }
                else
                {
                    return RedirectToAction("Details", "Bag");
                }
            }
            catch (Exception e) {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
            }
            return NoContent();
        }

        //[HttpGet]
        //public async Task<IActionResult> CancelCheckout()
        //{
        //    try
        //    {
        //        var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);

        //        if (checkout.CustomerId != 0)
        //        {
        //            var response = await DeleteRequest($"/Customer/DeleteCustomerInf/{checkout.CustomerId}");

        //            if (!response.IsSuccessStatusCode)
        //            {
        //                _logger.LogError($"time: {DateTime.Now} - {response.ReasonPhrase}");
        //            }
        //        }

        //        HttpContext.Session.Set<Checkout>(CheckoutSessionKey, null);

        //        return RedirectToAction("Details", "Bag");
        //    }
        //    catch(Exception e)
        //    {
        //        _logger.LogError($"time: {DateTime.Now} - {e.Message}");
        //        return RedirectToAction("Details", "Bag");
        //    }
        //}

        //private async Task<Customer> GetCustomerNoUnprotect(int id)
        //{
        //    Customer customer;
        //    var jsonCustomer = await GetRequest($"/Customer/GetCustomer/{id}");
        //    customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
        //    return customer;
        //}

        //[HttpPost]
        //public async Task<ParcelShopSearchResult> GetNearbyShopsJson(GlsAddress glsAddress)
        //{
        //    var shops = await GetNearbyShops(glsAddress);
        //    return shops;
        //}
    }
}
