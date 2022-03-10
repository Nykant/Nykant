using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Services;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class PaymentController : BaseController
    {
        private readonly IProtectionService _protectionService;
        private readonly IMailService mailService;
        private readonly IHostEnvironment env;
        public PaymentController(ILogger<PaymentController> logger, IHostEnvironment _env, IConfiguration conf, IMailService mailService, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder, conf)
        {
            _protectionService = protectionService;
            this.mailService = mailService;
            env = _env;
        }

        [HttpPost]
        public async Task<IActionResult> PostConsent(string name, string email)
        {
            try
            {
                Consent consent = new Consent
                {
                    Name = name,
                    Email = email,
                    Date = DateTime.Now,
                    ButtonText = "Gem",
                    ConsentText = "For at færdiggøre ordren, skal du skrive under på at du har læst og accepterer vores (link (Salgs- og leveringsbetingelser)) ved at klikke i checkboksen.",
                    How = ConsentHow.Checkbox,
                    Type = ConsentType.TermsAndConditions,
                    Status = ConsentStatus.Given
                };
                PostRequest("/Consent/Post", consent).ConfigureAwait(false);
                //if (!consentResponse.IsSuccessStatusCode)
                //{
                //    _logger.LogInformation($"{consentResponse.ReasonPhrase} - {consentResponse.StatusCode}");
                //    return Json(new { error = "Could not post consent" });
                //}
            }
            catch (Exception err) { _logger.LogError($"time: {DateTime.Now} - {err.Message}"); }
            return NoContent();
        }

        [HttpPost]
        public IActionResult Payment(string paymentMethodId)
        {
            try
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                if (checkout == null)
                {
                    _logger.LogError($"time: {DateTime.Now} - checkout = null");
                    return Json(new { error = "checkout = null" });
                }

                if (checkout.Stage == Stage.payment)
                {
                    StripeConfiguration.ApiKey = conf["StripeSKKey"];
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

                        if (paymentMethodId != null)
                        {
                            int.TryParse(checkout.TotalPrice, out int amount);
                            amount = amount * 100;
                            var PIoptions = new PaymentIntentCreateOptions
                            {
                                PaymentMethod = paymentMethodId,
                                //Shipping = chargeShippingOptions,
                                Amount = amount,
                                Currency = "dkk",
                                ConfirmationMethod = "manual",
                                Confirm = true,
                                CaptureMethod = "manual",
                            };

                            paymentIntent = paymentIntentService.Create(PIoptions);
                        }
                    }
                    catch (StripeException e)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
                        return Json(new { error = e.StripeError.Message });
                    }


                    return generatePaymentResponse(paymentIntent);
                }
                else
                {
                    _logger.LogError($"time: {DateTime.Now} - error: stage not = payment");
                    return Json(new { error = "stage not = payment" });
                }
            }
            catch (Exception e) 
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
            }

            return Json(new { error = "Payment error" });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(string paymentIntentId)
        {
            try
            {
                StripeConfiguration.ApiKey = conf["StripeSKKey"];

                PaymentIntentService paymentIntentService = new PaymentIntentService();
                PaymentIntent paymentIntent = null;

                if (paymentIntentId != null)
                {
                    var confirmOptions = new PaymentIntentConfirmOptions { };
                    paymentIntent = paymentIntentService.Confirm(
                        paymentIntentId,
                        confirmOptions
                    );
                }

                return generatePaymentResponse(paymentIntent);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
            }
            return Json(new { error = "ConfirmPayment Error" });
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
            else if (intent.Status == "requires_capture")
            {
                // The payment didn’t need any additional actions and completed!
                // Handle post-payment fulfillment
                return Json(new { success = true, intentId = intent.Id });
            }
            else
            {
                // Invalid status
                return StatusCode(500, new { error = "Invalid PaymentIntent status" });
            }
        }

        
    }
}
