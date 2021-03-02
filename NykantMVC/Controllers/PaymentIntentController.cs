using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using NykantMVC.Services;
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
        private readonly IProtectionService _protectionService;
        public PaymentIntentController(ILogger<BaseController> logger, IConfiguration configuration, IProtectionService protectionService) : base(logger)
        {
            _configuration = (IConfigurationRoot)configuration;
            _protectionService = protectionService;
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

                checkout.CustomerInf = _protectionService.UnProtectCustomerInf(checkout.CustomerInf);

                var chargeShippingOptions = new ChargeShippingOptions
                {
                    Address = new AddressOptions
                    {
                        City = checkout.CustomerInf.City,
                        Country = checkout.CustomerInf.Country,
                        Line1 = checkout.CustomerInf.Address1,
                        Line2 = checkout.CustomerInf.Address2,
                        PostalCode = checkout.CustomerInf.Postal
                    },
                    Name = checkout.CustomerInf.FirstName + " " + checkout.CustomerInf.LastName,
                    Phone = checkout.CustomerInf.Phone,
                };

                var PIoptions = new PaymentIntentCreateOptions
                {
                    Shipping = chargeShippingOptions,
                    Amount = checkout.TotalPrice,
                    Currency = "dkk",
                    Metadata = new Dictionary<string, string>
                    {
                        { "integration_check", "accept_a_payment" },
                    },
                };

                try
                {
                    PaymentIntentService PIservice = new PaymentIntentService();
                    PaymentIntent paymentIntent = PIservice.Create(PIoptions);

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
    }
}
