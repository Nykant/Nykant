using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class PaymentIntentController : BaseController
    {
        private IConfigurationRoot _configuration; 
        public PaymentIntentController(ILogger<BaseController> logger, IConfiguration configuration) : base(logger)
        {
            _configuration = (IConfigurationRoot)configuration;
        }

        [HttpGet]
        public ActionResult GetCardInformation()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }

            if(checkout.Stage == Stage.payment)
            {
                return Json(new
                {
                    Name = checkout.CustomerInf.FirstName,
                    Email = checkout.CustomerInf.Email,
                    Address = checkout.CustomerInf.Address,
                    City = checkout.CustomerInf.City,
                    Country = checkout.CustomerInf.Country,
                    Phone = checkout.CustomerInf.Phone,
                    Postal = checkout.CustomerInf.Postal
                });
            }
            else
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }
        }

        public class CardInformation
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Postal { get; set; }
        }

        [HttpPost]
        public ActionResult CreatePaymentIntent()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }

            if (checkout.Stage == Stage.payment)
            {
                StripeConfiguration.ApiKey = _configuration["StripeTESTKey"];

                var totalPrice = checkout.TotalPrice;
                var customers = new CustomerService();
                var customer = customers.Create(new CustomerCreateOptions
                {
                    Name = checkout.CustomerInf.FirstName + " " + checkout.CustomerInf.LastName,
                    Email = checkout.CustomerInf.Email,
                    Phone = checkout.CustomerInf.Phone,
                    Address = new AddressOptions
                    {
                        Line1 = checkout.CustomerInf.Address,
                        City = checkout.CustomerInf.City,
                        Country = checkout.CustomerInf.Country,
                        PostalCode = checkout.CustomerInf.Postal
                    },
                });

                var options = new PaymentIntentCreateOptions
                {
                    Customer = customer.Id,
                    Amount = totalPrice,
                    Currency = "dkk",
                    Metadata = new Dictionary<string, string>
                    {
                        { "integration_check", "accept_a_payment" },
                    },
                };

                try
                {
                    PaymentIntentService service = new PaymentIntentService();
                    PaymentIntent paymentIntent = service.Create(options);

                    return Json(new { clientSecret = paymentIntent.ClientSecret });
                }
                catch (StripeException e)
                {
                    return NotFound(e.InnerException.Message);
                }
            }
            else
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }
        }

        private int CalculateOrderAmount(List<BagItem> items)
        {
            int price = 0;
            foreach(var item in items)
            {
                price += item.Product.Price;
            }
            return price;
        }
    }
}
