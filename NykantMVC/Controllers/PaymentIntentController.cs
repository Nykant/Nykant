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
        public async Task<IActionResult> CreatePaymentIntent()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }

            if (checkout.Stage == Stage.payment)
            {
                StripeConfiguration.ApiKey = _configuration["StripeTESTKey"];
                var json = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                var customerInf = JsonConvert.DeserializeObject<CustomerInf>(json);
                customerInf = _protectionService.UnProtectCustomerInf(customerInf);

                var chargeShippingOptions = new ChargeShippingOptions
                {
                    Address = new AddressOptions
                    {
                        City = customerInf.City,
                        Country = customerInf.Country,
                        Line1 = customerInf.Address1,
                        Line2 = customerInf.Address2,
                        PostalCode = customerInf.Postal
                    },
                    Name = customerInf.FirstName + " " + customerInf.LastName,
                    Phone = customerInf.Phone,
                };

                int.TryParse(checkout.TotalPrice, out int result);
                var PIoptions = new PaymentIntentCreateOptions
                {
                    Shipping = chargeShippingOptions,
                    Amount = result,
                    Currency = "dkk",
                    Metadata = new Dictionary<string, string>
                    {
                        { "integration_check", "accept_a_payment" },
                    },
                    CaptureMethod = "manual",
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

        public async Task<IActionResult> CapturePaymentIntent(int orderId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeTESTKey"];

            var json = await GetRequest($"/Order/GetOrder/{orderId}");
            var order = JsonConvert.DeserializeObject<Models.Order>(json);

            var service = new PaymentIntentService();
            var paymentIntent = await service.CaptureAsync(order.PaymentIntent_Id);

            if(paymentIntent.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                order.Status = Status.Succeeded;
                await PatchRequest("/Order/UpdateOrder", order);

                return Content(paymentIntent.StripeResponse.StatusCode.ToString());
            }
            else
            {
                return Content(paymentIntent.StripeResponse.StatusCode.ToString());
            }
        }
    }
}
