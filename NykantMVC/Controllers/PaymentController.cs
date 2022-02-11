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
    [AllowAnonymous]
    public class PaymentController : BaseController
    {
        private IConfigurationRoot _configuration;
        private readonly IProtectionService _protectionService;
        private readonly IMailService mailService;
        private readonly IHostEnvironment env;
        public PaymentController(ILogger<BaseController> logger, IHostEnvironment _env, IConfiguration configuration, IMailService mailService, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
            _configuration = (IConfigurationRoot)configuration;
            _protectionService = protectionService;
            this.mailService = mailService;
            env = _env;
        }

        [HttpPost]
        public IActionResult Payment(string paymentMethodId)
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            if (checkout == null)
            {
                return Json(new { error = "checkout = null" });
            }

            if (checkout.Stage == Stage.payment)
            {
                StripeConfiguration.ApiKey = _configuration["StripeLIVEKey"];
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
                    return Json(new { error = e.StripeError.Message });
                }

                return generatePaymentResponse(paymentIntent);

            }
            else
            {
                return Json(new { error = "stage not = payment" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(string paymentIntentId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeLIVEKey"];

            PaymentIntentService paymentIntentService = new PaymentIntentService();
            PaymentIntent paymentIntent = null;

            try
            {
                if (paymentIntentId != null)
                {
                    var confirmOptions = new PaymentIntentConfirmOptions { };
                    paymentIntent = paymentIntentService.Confirm(
                        paymentIntentId,
                        confirmOptions
                    );
                }
            }
            catch(StripeException e)
            {
                return Json(new { error = e.StripeError.Message });
            }

            return generatePaymentResponse(paymentIntent);
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

        public async Task<IActionResult> CapturePaymentIntent(int orderId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeLIVEKey"];

            var json = await GetRequest($"/Order/GetOrder/{orderId}");
            var order = JsonConvert.DeserializeObject<Models.Order>(json);
            order.Customer = _protectionService.UnprotectCustomer(order.Customer);
            order.Customer.ShippingAddress = _protectionService.UnprotectShippingAddress(order.Customer.ShippingAddress);
            if(order.Customer.BillingAddress != null)
            {
                order.Customer.BillingAddress = _protectionService.UnprotectBillingAddress(order.Customer.BillingAddress);
            }

            var service = new PaymentIntentService();
            var paymentIntent = await service.CaptureAsync(order.PaymentIntent_Id);

            if (paymentIntent.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                order.Status = Status.Sent;

                var now = DateTime.Now;
                var deliveryDate = now.AddDays(2);
                order.EstimatedDelivery = deliveryDate;

                Models.Invoice invoice = new Models.Invoice
                {
                    CreatedAt = DateTime.Now,
                    OrderId = order.Id
                };
                var response = await PostRequest("/Invoice/PostInvoice/", invoice);
                var invoiceJson = await GetRequest(response.Headers.Location.AbsolutePath);
                invoice = JsonConvert.DeserializeObject<Models.Invoice>(invoiceJson);
                order.Invoice = invoice;

                await PatchRequest("/Order/UpdateOrder", order);

                await mailService.SendInvoiceEmailAsync(order);

                var json2 = await GetRequest("/Order/GetOrders");
                var orders = JsonConvert.DeserializeObject<List<Models.Order>>(json2);

                ViewData.Model = orders;
                return new PartialViewResult
                {
                    ViewName = "/Views/Order/_UnsentOrderListPartial.cshtml",
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
