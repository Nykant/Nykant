using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using NykantMVC.Friends;
using Stripe;
using Microsoft.Extensions.Configuration;
using NykantMVC.Models.Helpers;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class OrderController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IProtectionService _protectionService;
        public OrderController(IMailService mailService, ILogger<OrderController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
            this.mailService = mailService;
            _protectionService = protectionService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> UnsentOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> SentOrders()
        {
            var json = await GetRequest("/PaymentCapture/GetPaymentCaptures");
            List<PaymentCapture> list = JsonConvert.DeserializeObject<List<PaymentCapture>>(json);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> History()
        {
            var json = await GetRequest($"/Order/GetOrders/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var json = await GetRequest($"/Order/GetOrder/{id}");
            var order = JsonConvert.DeserializeObject<Models.Order>(json);
            return View(order);
        }

        private async Task<List<BagItem>> ValidateAndUpdateProducts(List<BagItem> bagItems)
        {
            for (int i = 0; i < bagItems.Count; i++)
            {
                var productjson = await GetRequest($"/Product/GetProduct/{bagItems[i].ProductId}");
                Models.Product product = JsonConvert.DeserializeObject<Models.Product>(productjson);
                bagItems[i].Product = product;
                if (product.Amount >= bagItems[i].Quantity)
                {
                    if(product.Id == 1 || product.Id == 2 || product.Id == 3)
                    {
                        product.Amount = product.Amount - (bagItems[i].Quantity * 3);
                    }
                    else
                    {
                        product.Amount = product.Amount - bagItems[i].Quantity;
                    }
                    await PatchRequest("/Product/UpdateProduct", product);
                }
            }
            return bagItems;
        }

        public async Task<int> PostCustomer(Models.Customer customerProtected)
        {
            var customer = _protectionService.UnprotectCustomer(customerProtected);
            var response = await PostRequest("/Customer/PostCustomer", new Models.Customer { Email = customer.Email, Phone = customer.Phone });
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: could not post customer");
                return 0;
            }
            _logger.LogInformation($"path: {response.Headers.Location}");
            _logger.LogInformation($"path: {response.Headers.Location.AbsolutePath}");
            var json = await GetRequest(response.Headers.Location.AbsolutePath);
            customer.Id = JsonConvert.DeserializeObject<Models.Customer>(json).Id;

            customer.ShippingAddress.CustomerId = customer.Id;
            response = await PostRequest("/Customer/PostShippingAddress", customer.ShippingAddress);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: Could not post shipping");
                return 0;
            }

            customer.BillingAddress.CustomerId = customer.Id;
            response = await PostRequest("/Customer/PostBillingAddress", customer.BillingAddress);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: Could not post billing");
                return 0;
            }

            return customer.Id;
        }

        public async Task<Models.Order> PostOrder(Models.Order order)
        {
            var response = await PostRequest("/Order/PostOrder", order);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: could not post order");
                return default;
            }

            var json = await GetRequest(response.Headers.Location.AbsolutePath);
            order.Id = JsonConvert.DeserializeObject<Models.Order>(json).Id;

            var shippingDelivery = new ShippingDelivery { OrderId = order.Id, Type = OrderHelpers.CalculateDeliveryType(order.BagItems) };
            var postShipping = await PostRequest("/ShippingDelivery/Post", shippingDelivery);
            if (!postShipping.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: could not post shippingdelivery");
                return default;
            }

            var orderItems = OrderHelpers.MakeOrderItems(order.BagItems, order.Id); // check om info ik er krypteret
            var postRequest = await PostRequest("/Orderitem/PostOrderItems", orderItems);
            if (!postRequest.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: could not post order items");
                return default;
            }

            json = await GetRequest($"/Order/GetOrder/{order.Id}");
            order = JsonConvert.DeserializeObject<Models.Order>(json);

            return order;
        }

        public async Task OrderError(Models.Order order)
        {
            order.Status = Status.Error;
            bool success = false;
            while (!success)
            {
                var response = await PatchRequest("/order/updateorder", order);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: could not update order to error order, trying again...");
                }
                else
                {
                    _logger.LogInformation($"time: {DateTime.Now} - success: updated order to error order");
                    success = true;
                }
            }
        } 

        [HttpPost]
        public async Task<IActionResult> PostOrder(string paymentIntentId)
        {
            try
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                if (checkout == null)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: checkout = null - in postorder");
                    return Json(new { ok = false, error = "checkout = null" });
                }

                if (checkout.Stage == Stage.payment)
                {

                    // ------------------------Post Customer-------------------------

                    var customerResult = await PostCustomer(checkout.Customer);
                    if(customerResult == 0)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not post customer");
                        return Json(new { ok = false, error = "could not post customer" });
                    }

                    checkout.Customer.Id = customerResult;
                    checkout.BagItems = await ValidateAndUpdateProducts(checkout.BagItems);

                    // ------------------------Post Payment Capture-------------------------

                    var paymentCapture = new PaymentCapture { Captured = false, PaymentIntent_Id = paymentIntentId, CustomerId = customerResult };
                    var response = await PostRequest("/PaymentCapture/PostPaymentCapture", paymentCapture);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not post paymentCapture");
                        return Json(new { ok = false, error = "could not post paymentCapture" });
                    }
                    var json = await GetRequest(response.Headers.Location.AbsolutePath);
                    paymentCapture.Id = JsonConvert.DeserializeObject<PaymentCapture>(json).Id;

                    // ------------------------Post Order-------------------------

                    var order = OrderHelpers.BuildOrder(checkout, paymentCapture.Id);

                    var orderResult = await PostOrder(order);
                    if(orderResult == default)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not post order");
                        return Json(new { ok = false, error = "could not post order" });
                    }

                    order = orderResult;

                    // ------------------------Send Emails-------------------------

                    var emailResponse = await mailService.SendNykantEmailAsync(order);
                    if (emailResponse == "fail")
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not send nykant email");
                        await OrderError(order);
                        return Json(new { ok = false, error = "email error" });
                    }
                    emailResponse = await mailService.SendOrderEmailAsync(order);
                    if(emailResponse == "fail")
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not send order email");
                        await OrderError(order);
                        return Json(new { ok = false, error = "email error" });
                    }
                    emailResponse = await mailService .SendDKIEmailAsync(order);
                    if (emailResponse == "fail")
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not send DKi email");
                        await OrderError(order);
                        return Json(new { ok = false, error = "email error" });
                    }

                    HttpContext.Session.Set<List<BagItem>>(BagSessionKey, null);
                    HttpContext.Session.Set<int>(BagItemAmountKey, 0);

                    checkout.Stage = Stage.completed;
                    checkout.OrderId = order.Id;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                    List<string> productIds = new List<string>();
                    foreach(var orderItem in order.OrderItems)
                    {
                        productIds.Add(orderItem.Product.Number);
                    }

                    List<trustpilot_product> productList = new List<trustpilot_product>();
                    foreach(var orderItem in order.OrderItems)
                    {
                        productList.Add(new trustpilot_product
                        {
                            SKU = orderItem.Product.Number,
                            ProductUrl = $"https://www.nykant.dk/møbler/{orderItem.Product.Category.Name}/{orderItem.Product.UrlName}",
                            ImageUrl = orderItem.Product.GalleryImage1,
                            Name = orderItem.Product.Name
                        });
                    }

                    return Json(new { ok = true, order = order, productIds = productIds.ToArray(), productList = productList.ToArray() });
                }
                else
                {
                    _logger.LogError("time: {DateTime.Now} - error: wrong stage");
                    return Json(new { ok = false, error = "wrong stage",  });
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Json(new { ok = false, error = e.Message });
            }
        }

        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        //public async Task<IActionResult> BackOrders()
        //{
        //    var jsonResponse = await GetRequest("/Order/GetOrders");
        //    var list = JsonConvert.DeserializeObject<List<Models.Order>>(jsonResponse);
        //    return View(list);
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public async Task<IActionResult> OrderInStorage(int orderId)
        //{
        //    try
        //    {
        //        var orderResponse = await GetRequest($"/Order/GetOrder/{orderId}");
        //        var order = JsonConvert.DeserializeObject<Models.Order>(orderResponse);
        //        mailService.SendDKIEmailAsync(order).ConfigureAwait(false);

        //        //order.IsBackOrder = false;
        //        var updateOrder = await PatchRequest("/Order/UpdateOrder", order);
        //        if (!updateOrder.IsSuccessStatusCode)
        //        {
        //            return Json(new { ok = false, error = "error updating order" });
        //        }

        //        var ordersResponse = await GetRequest("/Order/GetOrders");
        //        var orders = JsonConvert.DeserializeObject<List<Models.Order>>(ordersResponse);
        //        ViewData.Model = orders;
        //        return new PartialViewResult
        //        {
        //            ViewName = "/Views/Order/_BackOrderListPartial.cshtml",
        //            ViewData = this.ViewData
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError($"time: {DateTime.Now} - {e.Message}");
        //    }
        //    return NoContent();
            
        //}

        [Authorize( Roles = "Admin" )]
        [HttpPost]
        public async Task<IActionResult> OrderSent(int orderId)
        {
            try
            {
                var json = await GetRequest($"/Order/GetOrder/{orderId}");
                var order = JsonConvert.DeserializeObject<Models.Order>(json);
                //mailService.SendOrderSentEmailAsync(order).ConfigureAwait(false);
                order.Status = Status.Sent;
                var response = await PatchRequest("/Order/UpdateOrder", order);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Json(new { ok = false, error = "error updating order" });
                }

                await CapturePaymentIntent(order.PaymentCaptureId);

                var json2 = await GetRequest("/Order/GetOrders");
                var orders = JsonConvert.DeserializeObject<List<Models.Order>>(json2);

                ViewData.Model = orders;
                return new PartialViewResult
                {
                    ViewName = "/Views/Order/_UnsentOrderListPartial.cshtml",
                    ViewData = this.ViewData
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
            }
            return Content("error: Capture Payment Intent");
        }

        [Authorize(Roles = "Admin")]
        public async Task CapturePaymentIntent(int paymentCaptureId)
        {
            try
            {
                var json = await GetRequest($"/PaymentCapture/GetPaymentCapture/{paymentCaptureId}");
                var paymentCapture = JsonConvert.DeserializeObject<PaymentCapture>(json); // check customer data we need

                StripeConfiguration.ApiKey = conf["StripeSKKey"];
                var service = new PaymentIntentService();
                var paymentIntent = await service.CaptureAsync(paymentCapture.PaymentIntent_Id);
                if (paymentIntent.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    paymentCapture.Captured = true;

                    Models.Invoice invoice = new Models.Invoice
                    {
                        CreatedAt = DateTime.Now,
                        PaymentCaptureId = paymentCapture.Id,
                        TotalPrice = paymentCapture.Order.TotalPrice,
                        TaxLessPrice = paymentCapture.Order.TaxLessPrice,
                        Taxes = paymentCapture.Order.Taxes
                    };

                    var response = await PostRequest("/Invoice/PostInvoice/", invoice);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
                    }
                    var invoiceJson = await GetRequest(response.Headers.Location.AbsolutePath);
                    invoice = JsonConvert.DeserializeObject<Models.Invoice>(invoiceJson);
                    paymentCapture.Invoice = invoice;

                    await mailService.SendInvoiceEmailAsync(paymentCapture);

                    response = await PatchRequest("/PaymentCapture/UpdatePaymentCapture", paymentCapture);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
                    }
                }
                else
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {paymentIntent.StripeResponse.StatusCode}");
                }

                end:;
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RefundPaymentIntent(int paymentCaptureId, string refundedProducts, int refundAmount, int qualityFee, int returnFee)
        {
            try
            {
                var json = await GetRequest($"/PaymentCapture/GetPaymentCapture/{paymentCaptureId}");
                var paymentCapture = JsonConvert.DeserializeObject<PaymentCapture>(json); // check customer data we need

                StripeConfiguration.ApiKey = conf["StripeSKKey"];
                var service = new RefundService();
                var stripeRefund = await service.CreateAsync(new RefundCreateOptions
                {
                     PaymentIntent = paymentCapture.PaymentIntent_Id,
                     Amount = refundAmount * 100,
                     Reason = "requested_by_customer"
                });

                if (stripeRefund.StripeResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    paymentCapture.Refunded = true;

                    var refund = new Models.Refund
                    {
                        PaymentCaptureId = paymentCapture.Id,
                        Products = refundedProducts,
                        Amount = refundAmount,
                        QualityFee = qualityFee,
                        ReturnFee = returnFee
                    };

                    var response = await PostRequest("/Refund/PostRefund/", refund);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
                    }
                    var refundJson = await GetRequest(response.Headers.Location.AbsolutePath);
                    refund = JsonConvert.DeserializeObject<Models.Refund>(refundJson);
                    paymentCapture.Refund = refund;

                    await mailService.SendRefundEmailAsync(paymentCapture);

                    response = await PatchRequest("/PaymentCapture/UpdatePaymentCapture", paymentCapture);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
                    }

                    json = await GetRequest($"/PaymentCapture/GetPaymentCaptures");
                    var paymentCaptures = JsonConvert.DeserializeObject<List<PaymentCapture>>(json);
                    ViewData.Model = paymentCaptures;
                    return new PartialViewResult
                    {
                        ViewName = "/Views/Order/_SentOrderListPartial.cshtml",
                        ViewData = this.ViewData
                    };
                }
                else
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {stripeRefund.StripeResponse.StatusCode}");
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
            }
            return Content("error: Refund Payment Intent");
        }
    }
}
