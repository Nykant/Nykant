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

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class OrderController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IProtectionService _protectionService;
        public OrderController(IMailService mailService, ILogger<OrderController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
            this.mailService = mailService;
            _protectionService = protectionService;
        }

        [Authorize("Admin Permission")]
        [HttpGet]
        public async Task<IActionResult> UnsentOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize("Admin Permission")]
        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize("Admin Permission")]
        [HttpGet]
        public async Task<IActionResult> History()
        {
            var json = await GetRequest($"/Order/GetOrders/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize("Admin Permission")]
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
                    product.Amount = product.Amount - bagItems[i].Quantity;
                    await PatchRequest("/Product/UpdateProduct", product);
                }
            }
            return bagItems;
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
                    checkout.BagItems = await ValidateAndUpdateProducts(checkout.BagItems);

                    var paymentCapture = new PaymentCapture { Captured = false, PaymentIntent_Id = paymentIntentId, CustomerId = checkout.CustomerInfId };
                    var response = await PostRequest("/PaymentCapture/PostPaymentCapture", paymentCapture);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not post paymentCapture");
                        return Json(new { ok = false, error = "could not post paymentCapture" });
                    }
                    var json = await GetRequest(response.Headers.Location.AbsolutePath);
                    paymentCapture.Id = JsonConvert.DeserializeObject<PaymentCapture>(json).Id;

                    var orders = OrderHelpers.MakeOrders(checkout, paymentCapture.Id);

                    for(int i = 0; i < orders.Count(); i++)
                    {
                        response = await PostRequest("/Order/PostOrder", orders[i]);
                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError($"time: {DateTime.Now} - error: could not post order");
                            return Json(new { ok = false, error = "could not post order" });
                        }

                        json = await GetRequest(response.Headers.Location.AbsolutePath);
                        orders[i].Id = JsonConvert.DeserializeObject<Models.Order>(json).Id;

                        var shippingDelivery = new ShippingDelivery { OrderId = orders[i].Id, Type = OrderHelpers.CalculateDeliveryType(orders[i].BagItems) };
                        var postShipping = await PostRequest("/ShippingDelivery/Post", shippingDelivery);
                        if (!postShipping.IsSuccessStatusCode)
                        {
                            _logger.LogError($"time: {DateTime.Now} - error: could not post shippingdelivery");
                            return Json(new { ok = false, error = "could not post shipping" });
                        }

                        var orderItems = OrderHelpers.MakeOrderItems(orders[i].BagItems, orders[i].Id); // check om info ik er krypteret
                        var postRequest = await PostRequest("/Orderitem/PostOrderItems", orderItems);
                        if (!postRequest.IsSuccessStatusCode)
                        {
                            _logger.LogError($"time: {DateTime.Now} - error: could not post order items");
                            return Json(new { ok = false, error = "could not post order items" });
                        }

                        json = await GetRequest($"/Order/GetOrder/{orders[i].Id}");
                        orders[i] = JsonConvert.DeserializeObject<Models.Order>(json);

                        mailService.SendOrderEmailAsync(orders[i]).ConfigureAwait(false);
                        mailService.SendNykantEmailAsync(orders[i]).ConfigureAwait(false);

                        if (!orders[i].IsBackOrder)
                        {
                            mailService.SendDKIEmailAsync(orders[i]).ConfigureAwait(false);
                        }
                        else
                        {
                            var updateOrder = await PatchRequest("/Order/UpdateOrder", orders[i]);
                            if (!updateOrder.IsSuccessStatusCode)
                            {
                                _logger.LogError($"time: {DateTime.Now} - error: error updating order");
                                return Json(new { ok = false, error = "error updating order" });
                            }
                        }
                    }

                    HttpContext.Session.Set<List<BagItem>>(BagSessionKey, null);
                    HttpContext.Session.Set<int>(BagItemAmountKey, 0);

                    checkout.Stage = Stage.completed;
                    HttpContext.Session.Set<Checkout>(CheckoutSessionKey, checkout);

                    return Json(new { ok = true });
                }
                else
                {
                    _logger.LogError("time: {DateTime.Now} - error: wrong stage");
                    return Json(new { ok = false, error = "wrong stage" });
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
                return Json(new { ok = false, error = e.Message });
            }
        }

        [Authorize("Admin Permission")]
        [HttpGet]
        public async Task<IActionResult> BackOrders()
        {
            var jsonResponse = await GetRequest("/Order/GetOrders");
            var list = JsonConvert.DeserializeObject<List<Models.Order>>(jsonResponse);
            return View(list);
        }

        [Authorize("Admin Permission")]
        [HttpPost]
        public async Task<IActionResult> OrderInStorage(int orderId)
        {
            try
            {
                var orderResponse = await GetRequest($"/Order/GetOrder/{orderId}");
                var order = JsonConvert.DeserializeObject<Models.Order>(orderResponse);
                mailService.SendDKIEmailAsync(order).ConfigureAwait(false);

                order.IsBackOrder = false;
                var updateOrder = await PatchRequest("/Order/UpdateOrder", order);
                if (!updateOrder.IsSuccessStatusCode)
                {
                    return Json(new { ok = false, error = "error updating order" });
                }

                var ordersResponse = await GetRequest("/Order/GetOrders");
                var orders = JsonConvert.DeserializeObject<List<Models.Order>>(ordersResponse);
                ViewData.Model = orders;
                return new PartialViewResult
                {
                    ViewName = "/Views/Order/_BackOrderListPartial.cshtml",
                    ViewData = this.ViewData
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
            }
            return NoContent();
            
        }

        [Authorize("Admin Permission")]
        [HttpPost]
        public async Task<IActionResult> OrderSent(int orderId)
        {
            try
            {
                var json = await GetRequest($"/Order/GetOrder/{orderId}");
                var order = JsonConvert.DeserializeObject<Models.Order>(json);
                mailService.SendOrderSentEmailAsync(order).ConfigureAwait(false);
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
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
            }
            return Content("error: Capture Payment Intent");
        }

        [Authorize("Admin Permission")]
        public async Task CapturePaymentIntent(int paymentCaptureId)
        {
            try
            {
                var json = await GetRequest($"/PaymentCapture/GetPaymentCapture/{paymentCaptureId}");
                var paymentCapture = JsonConvert.DeserializeObject<PaymentCapture>(json); // check customer data we need

                foreach (var order in paymentCapture.Orders)
                {
                    if(order.Status != Status.Sent)
                    {
                        goto end;
                    }
                }

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
                        TotalPrice = OrderHelpers.CalculateTotalPrice(paymentCapture.Orders).ToString(),
                        TaxLessPrice = OrderHelpers.CalculateTaxlessPrice(paymentCapture.Orders).ToString(),
                        Taxes = OrderHelpers.CalculateTaxes(paymentCapture.Orders).ToString()
                    };

                    var response = await PostRequest("/Invoice/PostInvoice/", invoice);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
                    }
                    var invoiceJson = await GetRequest(response.Headers.Location.AbsolutePath);
                    invoice = JsonConvert.DeserializeObject<Models.Invoice>(invoiceJson);
                    paymentCapture.Invoice = invoice;

                    mailService.SendInvoiceEmailAsync(paymentCapture).ConfigureAwait(false);

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
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
            }
        }
    }
}
