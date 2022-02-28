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

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class OrderController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IProtectionService _protectionService;
        public OrderController(IMailService mailService, ILogger<BaseController> logger, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
            this.mailService = mailService;
            _protectionService = protectionService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UnsentOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            for(int i = 0; i < list.Count; i++)
            {
                list[i] = _protectionService.UnprotectOrder(list[i]);
            }
            return View(list);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AllOrders()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = _protectionService.UnprotectOrder(list[i]);
            }
            return View(list);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> History()
        {
            var json = await GetRequest($"/Order/GetOrders/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }

        [Authorize]
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
                Product product = JsonConvert.DeserializeObject<Product>(productjson);
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
                    _logger.LogError("error: checkout = null - in postorder");
                    return Json(new { ok = false, error = "checkout = null" });
                }

                if (checkout.Stage == Stage.payment)
                {
                    checkout.BagItems = await ValidateAndUpdateProducts(checkout.BagItems);

                    var paymentCapture = new PaymentCapture { Captured = false, PaymentIntent_Id = paymentIntentId };
                    var response = await PostRequest("/PaymentCapture/PostPaymentCapture", paymentCapture);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError("error: could not post paymentCapture");
                        return Json(new { ok = false, error = "could not post paymentCapture" });
                    }
                    var json = await GetRequest(response.Headers.Location.AbsolutePath);
                    paymentCapture.Id = JsonConvert.DeserializeObject<PaymentCapture>(json).Id;

                    var orders = OrderHelpers.MakeOrders(checkout, paymentCapture.Id);

                    for(int i = 0; i < orders.Count(); i++)
                    {
                        orders[i] = _protectionService.ProtectOrder(orders[i]);
                        response = await PostRequest("/Order/PostOrder", orders[i]);
                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError("error: could not post order");
                            return Json(new { ok = false, error = "could not post order" });
                        }

                        json = await GetRequest(response.Headers.Location.AbsolutePath);
                        orders[i].Id = JsonConvert.DeserializeObject<Order>(json).Id;

                        var orderItems = OrderHelpers.MakeOrderItems(orders[i].BagItems, orders[i].Id); // check om info ik er krypteret
                        var postRequest = await PostRequest("/Orderitem/PostOrderItems", orderItems);
                        if (!postRequest.IsSuccessStatusCode)
                        {
                            _logger.LogError("error: could not post order items");
                            return Json(new { ok = false, error = "could not post order items" });
                        }

                        checkout.ShippingDelivery.OrderId = orders[i].Id;
                        var postShipping = await PostRequest("/ShippingDelivery/Post", checkout.ShippingDelivery);
                        if (!postShipping.IsSuccessStatusCode)
                        {
                            _logger.LogError("error: could not post shippingdelivery");
                            return Json(new { ok = false, error = "could not post shipping" });
                        }

                        json = await GetRequest($"/Order/GetOrder/{orders[i].Id}");
                        orders[i] = JsonConvert.DeserializeObject<Models.Order>(json);
                        orders[i] = _protectionService.UnprotectWholeOrder(orders[i]);

                        mailService.SendOrderEmailAsync(orders[i]).ConfigureAwait(false);
                        mailService.SendNykantEmailAsync(orders[i]).ConfigureAwait(false);

                        if (!orders[i].IsBackOrder)
                        {
                            mailService.SendDKIEmailAsync(orders[i]).ConfigureAwait(false);
                        }
                        else
                        {
                            orders[i].Customer = null;
                            orders[i] = _protectionService.ProtectOrder(orders[i]);
                            var updateOrder = await PatchRequest("/Order/UpdateOrder", orders[i]);
                            if (!updateOrder.IsSuccessStatusCode)
                            {
                                _logger.LogError("error: error updating order");
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
                    _logger.LogError("error: wrong stage");
                    return Json(new { ok = false, error = "wrong stage" });
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"error: {e.Message}");
                return Json(new { ok = false, error = e.Message });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BackOrders()
        {
            var jsonResponse = await GetRequest("/Order/GetOrders");
            var list = JsonConvert.DeserializeObject<List<Order>>(jsonResponse);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = _protectionService.UnprotectOrder(list[i]);
            }
            return View(list);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> OrderInStorage(int orderId)
        {
            try
            {
                var orderResponse = await GetRequest($"/Order/GetOrder/{orderId}");
                var order = JsonConvert.DeserializeObject<Order>(orderResponse);
                order = _protectionService.UnprotectWholeOrder(order);
                await mailService.SendDKIEmailAsync(order);

                order.IsBackOrder = false;
                order.Customer = null;
                order = _protectionService.ProtectOrder(order);
                var updateOrder = await PatchRequest("/Order/UpdateOrder", order);
                if (!updateOrder.IsSuccessStatusCode)
                {
                    return Json(new { ok = false, error = "error updating order" });
                }

                var ordersResponse = await GetRequest("/Order/GetOrders");
                var orders = JsonConvert.DeserializeObject<List<Order>>(ordersResponse);
                for (int i = 0; i < orders.Count; i++)
                {
                    orders[i] = _protectionService.UnprotectOrder(orders[i]);
                }
                ViewData.Model = orders;
                return new PartialViewResult
                {
                    ViewName = "/Views/Order/_BackOrderListPartial.cshtml",
                    ViewData = this.ViewData
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return NoContent();
            
        }
    }
}
