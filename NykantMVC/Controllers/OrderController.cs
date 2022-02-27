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

        [HttpPost]
        public async Task<IActionResult> PostOrder(string paymentIntentId)
        {
            try
            {
                var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
                checkout.ShippingDelivery = new ShippingDelivery();
                if (checkout == null)
                {
                    _logger.LogError("error: checkout = null - in postorder");
                    return Json(new { ok = false, error = "checkout = null" });
                }

                if (checkout.Stage == Stage.payment)
                {
                    // validate bagItems
                    for (int i = 0; i < checkout.BagItems.Count; i++)
                    {
                        var productjson = await GetRequest($"/Product/GetProduct/{checkout.BagItems[i].ProductId}");
                        Product product = JsonConvert.DeserializeObject<Product>(productjson);
                        checkout.BagItems[i].Product = product;
                        if(product.Amount >= checkout.BagItems[i].Quantity)
                        {
                            product.Amount = product.Amount - checkout.BagItems[i].Quantity;
                            await PatchRequest("/Product/UpdateProduct", product);
                        }
                    }

                    var order = BuildOrder(checkout, paymentIntentId);
                    order = _protectionService.ProtectOrder(order);
                    var response = await PostRequest("/Order/PostOrder", order);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError("error: could not post order");
                        return Json(new { ok = false, error = "could not post order" });
                    }

                    var json = await GetRequest(response.Headers.Location.AbsolutePath);
                    Models.Order newOrder = JsonConvert.DeserializeObject<Models.Order>(json);
                    order = newOrder;

                    var orderItems = new List<Models.OrderItem>();
                    foreach (var item in checkout.BagItems)
                    {
                        orderItems.Add(new Models.OrderItem { Quantity = item.Quantity, ProductId = item.ProductId, OrderId = order.Id });
                        if (item.Product.WeightInKg > 20)
                        {
                            checkout.ShippingDelivery.Type = ShippingType.HomePallegods;
                        }
                    }

                    checkout.ShippingDelivery.OrderId = order.Id;
                    var postShipping = await PostRequest("/ShippingDelivery/Post", checkout.ShippingDelivery);
                    if (!postShipping.IsSuccessStatusCode)
                    {
                        _logger.LogError("error: could not post shippingdelivery");
                        return Json(new { ok = false, error = "could not post shipping" });
                    }

                    var postRequest = await PostRequest("/Orderitem/PostOrderItems", orderItems);
                    if (!postRequest.IsSuccessStatusCode)
                    {_logger.LogError("error: could not post order items");
                        return Json(new { ok = false, error = "could not post order items" });
                    }

                    json = await GetRequest($"/Order/GetOrder/{order.Id}");
                    order = JsonConvert.DeserializeObject<Models.Order>(json);
                    order = _protectionService.UnprotectWholeOrder(order);

                    mailService.SendOrderEmailAsync(order).ConfigureAwait(false);
                    mailService.SendNykantEmailAsync(order).ConfigureAwait(false);

                    var isBackOrder = false;
                    foreach (var item in order.OrderItems)
                    {
                        if (item.Product.Amount <= item.Quantity)
                        {
                            isBackOrder = true;
                            break;
                        }
                    }
                    order.IsBackOrder = isBackOrder;

                    if (!isBackOrder)
                    {
                        mailService.SendDKIEmailAsync(order).ConfigureAwait(false);
                    }
                    else
                    {
                        order.Customer = null;
                        order = _protectionService.ProtectOrder(order);
                        var updateOrder = await PatchRequest("/Order/UpdateOrder", order);
                        if (!updateOrder.IsSuccessStatusCode)
                        {
                            _logger.LogError("error: error updating order");
                            return Json(new { ok = false, error = "error updating order" });
                        }
                    }

                    if (User.Identity.IsAuthenticated)
                    {
                        var url = $"/BagItem/DeleteBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}";
                        var deleteRequest = await DeleteRequest(url);
                        if (!deleteRequest.IsSuccessStatusCode)
                        {
                            _logger.LogError("error: could not delete bag items");
                            return Json(new { ok = false, error = "could not delete bag items" });
                        }
                        else
                        {
                            HttpContext.Session.Set<int>(BagItemAmountKey, 0);
                        }
                    }
                    else
                    {
                        HttpContext.Session.Set<List<BagItem>>(BagSessionKey, null);
                        HttpContext.Session.Set<int>(BagItemAmountKey, 0);
                    }

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

        private Models.Order BuildOrder(Checkout checkout, string paymentIntentId)
        {
            var subtotal = CalculateSubtotal(checkout.BagItems);
            double.TryParse(subtotal, out double subtotalint);
            var total = subtotalint;
            var taxes = total / 5;
            var taxlessPrice = total - taxes;



            double weight = 0;
            var deliveryDate = new DateTime();
            foreach (var item in checkout.BagItems)
            {
                weight += item.Product.WeightInKg * item.Quantity;
                if(item.Product.ExpectedDelivery != new DateTime())
                {
                    if(deliveryDate != new DateTime())
                    {
                        if (DateTime.Compare(deliveryDate, item.Product.ExpectedDelivery) < 0)
                        {
                            deliveryDate = item.Product.ExpectedDelivery;
                        } 
                    }
                    else
                    {
                        deliveryDate = item.Product.ExpectedDelivery;
                    }
                }
            }
            if(deliveryDate == new DateTime())
            {
                deliveryDate = DateTime.Now;
                if (DateTime.Now.Hour < 12)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                    if(deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
                else
                {
                    deliveryDate = deliveryDate.AddDays(2);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
            }
            else
            { 
                deliveryDate = deliveryDate.AddDays(2);
                if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                }
            }

            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                CustomerId = checkout.CustomerInfId,
                PaymentIntent_Id = paymentIntentId,
                Status = Status.Pending,
                TotalPrice = total.ToString(),
                Taxes = taxes.ToString(),
                WeightInKg = weight,
                TaxLessPrice = taxlessPrice.ToString(),
                EstimatedDelivery = deliveryDate
            };

            if (User.Identity.IsAuthenticated)
                order.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            return order;
        }

        private string CalculateSubtotal(List<BagItem> items)
        {
            double price = 0;
            foreach (var item in items)
            {
                price += item.Product.Price * item.Quantity;
            }
            return price.ToString();
        }
    }
}
