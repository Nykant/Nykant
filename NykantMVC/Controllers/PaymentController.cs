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
    public class PaymentController : BaseController
    {
        private IConfigurationRoot _configuration;
        private readonly IProtectionService _protectionService;
        public PaymentController(ILogger<BaseController> logger, IConfiguration configuration, IProtectionService protectionService) : base(logger)
        {
            _configuration = (IConfigurationRoot)configuration;
            _protectionService = protectionService;
        }

        public class ConfirmPaymentRequest
        {
            [JsonProperty("payment_method_id")]
            public string PaymentMethodId { get; set; }

            [JsonProperty("payment_intent_id")]
            public string PaymentIntentId { get; set; }
        }


        [HttpPost]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] ConfirmPaymentRequest request)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }

            if (checkout.Stage == Stage.payment)
            {
                //StripeConfiguration.ApiKey = _configuration["StripeTESTKey"];
                //var json = await GetRequest($"/Customer/GetCustomer/{checkout.CustomerInfId}");
                //var customerInf = JsonConvert.DeserializeObject<CustomerInf>(json);
                //customerInf = _protectionService.UnProtectCustomerInf(customerInf);

                PaymentIntentService paymentIntentService = new PaymentIntentService();
                PaymentIntent paymentIntent = null;

                try
                {
                    //var chargeShippingOptions = new ChargeShippingOptions
                    //{
                    //    Address = new AddressOptions
                    //    {
                    //        City = customerInf.City,
                    //        Country = customerInf.Country,
                    //        Line1 = customerInf.Address1,
                    //        Line2 = customerInf.Address2,
                    //        PostalCode = customerInf.Postal
                    //    },
                    //    Name = customerInf.FirstName + " " + customerInf.LastName,
                    //    Phone = customerInf.Phone,
                    //};

                    if (request.PaymentMethodId != null)
                    {
                        int.TryParse(checkout.TotalPrice, out int amount);
                        var PIoptions = new PaymentIntentCreateOptions
                        {
                            PaymentMethod = request.PaymentMethodId,
                            //Shipping = chargeShippingOptions,
                            Amount = amount,
                            Currency = "dkk",
                            ConfirmationMethod = "manual",
                            Confirm = true,
                            CaptureMethod = "manual",
                        };

                        paymentIntent = paymentIntentService.Create(PIoptions);
                    }

                    if (request.PaymentIntentId != null)
                    {
                        var confirmOptions = new PaymentIntentConfirmOptions { };
                        paymentIntent = paymentIntentService.Confirm(
                            request.PaymentIntentId,
                            confirmOptions
                        );
                    }
                }
                catch (StripeException e)
                {
                    return Json(new { error = e.StripeError.Message });
                }

                return generatePaymentResponse(paymentIntent);

            }
            else
            {
                return RedirectToAction(nameof(CheckoutController.CustomerInf));
            }
        }

        private IActionResult generatePaymentResponse(PaymentIntent intent)
        {
            // Note that if your API version is before 2019-02-11, 'requires_action'
            // appears as 'requires_source_action'.
            if (intent.Status == "requires_action" &&
                intent.NextAction.Type == "use_stripe_sdk")
            {
                // Tell the client to handle the action
                return Json(new
                {
                    requires_action = true,
                    payment_intent_client_secret = intent.ClientSecret
                });
            }
            else if (intent.Status == "succeeded")
            {
                // The payment didn’t need any additional actions and completed!
                // Handle post-payment fulfillment
                return Json(new { success = true });
            }
            else
            {
                // Invalid status
                return StatusCode(500, new { error = "Invalid PaymentIntent status" });
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

                var json2 = await GetRequest("/Order/GetOrders");
                var orders = JsonConvert.DeserializeObject<List<Models.Order>>(json2);

                ViewData.Model = orders;
                return new PartialViewResult
                {
                    ViewName = "_OrderListPartial",
                    ViewData = this.ViewData
                };
            }
            else
            {
                return Content(paymentIntent.StripeResponse.StatusCode.ToString());
            }
        }
    }
}
