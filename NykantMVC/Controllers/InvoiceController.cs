using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Friends;
using NykantMVC.Models;
using NykantMVC.Services;
using System.Collections.Generic;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin")]
    public class InvoiceController : BaseController
    {
        private readonly Services.IMailService mailService;
        private readonly IRazorViewToStringRenderer razorViewToStringRenderer;
        public InvoiceController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, Services.IMailService mailService, ITokenService _tokenService, IRazorViewToStringRenderer razorViewToStringRenderer) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
            this.razorViewToStringRenderer = razorViewToStringRenderer;
            this.mailService = mailService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var json = await GetRequest("/Product/GetProducts");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            ViewBag.Products = products;

            return View();
        }

        private async Task<int> PostCustomer(Models.Customer customer)
        {
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

        private static ShippingType CalculateDeliveryType(List<Product> products)
        {
            foreach (var item in products)
            {
                if (double.Parse(item.WeightInKg) > 20)
                {
                    return ShippingType.HomePallegods;
                }
            }
            return ShippingType.Home;
        }

        private static List<OrderItem> MakeOrderItems(List<Product> products, int orderId)
        {
            var orderItems = new List<OrderItem>();
            foreach (var item in products)
            {
                orderItems.Add(new OrderItem { Quantity = 1, ProductId = item.Id, OrderId = orderId, Price = item.Price });
            }
            return orderItems;
        }

        private async Task<Models.Order> PostOrder(Models.Order order)
        {
            var response = await PostRequest("/Order/PostOrder", order);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: could not post order");
                return default;
            }

            var json = await GetRequest(response.Headers.Location.AbsolutePath);
            order.Id = JsonConvert.DeserializeObject<Models.Order>(json).Id;

            var shippingDelivery = new ShippingDelivery { OrderId = order.Id, Type = CalculateDeliveryType(order.InvoiceProducts) };
            var postShipping = await PostRequest("/ShippingDelivery/Post", shippingDelivery);
            if (!postShipping.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: could not post shippingdelivery");
                return default;
            }

            var orderItems = MakeOrderItems(order.InvoiceProducts, order.Id); // check om info ik er krypteret
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

        private static long CalculateTotal(List<Product> items)
        {
            long total = 0;
            foreach (var item in items)
            {
                total += item.Price;
            }
            return total;
        }

        private static long CalculateDiscount(List<Product> items)
        {
            double discount = 0;
            foreach (var item in items)
            {
                if (item.Discount > 0)
                {
                    double realDiscount = (double.Parse(item.Price.ToString()) - double.Parse(item.SalePrice.ToString())) / double.Parse(item.Price.ToString()) * 100;
                    double divide = double.Parse(item.Price.ToString()) / 100;
                    discount += divide * realDiscount;
                }
            }
            long result = long.Parse(Math.Round(discount).ToString());
            return result;
        }

        private static Order BuildOrder2(int paymentCaptureId, List<Product> products)
        {
            long discount = CalculateDiscount(products);
            double weight = 0;
            foreach (var item in products)
            {
                weight += double.Parse(item.WeightInKg);
            }
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].SalePrice > 0)
                {
                    products[i].Price = products[i].SalePrice;
                }
            }
            long total = CalculateTotal(products);
            long taxes = total / 5;
            long taxlessPrice = total - taxes;
            Order order = new Order();

            order = new Order
            {
                Discount = discount.ToString(),
                CouponCode = null,
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                PaymentCaptureId = paymentCaptureId,
                Status = Status.Pending,
                TotalPrice = total.ToString(),
                Taxes = taxes.ToString(),
                WeightInKg = weight,
                TaxLessPrice = taxlessPrice.ToString(),
                InvoiceProducts = products
            };


            return order;
        }

        private async Task OrderError(Models.Order order)
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
        public async Task<IActionResult> Create(PaymentCapture pc)
        {
            try
            {
                pc.Customer.BillingAddress = new BillingAddress();
                pc.Customer.ShippingAddress.Country = "DK";
                pc.Customer.BillingAddress.Country = "DK";
                pc.Customer.BillingAddress.Postal = pc.Customer.ShippingAddress.Postal;
                pc.Customer.BillingAddress.Name = pc.Customer.ShippingAddress.Name;
                pc.Customer.BillingAddress.Address = pc.Customer.ShippingAddress.Address;
                pc.Customer.BillingAddress.Country = pc.Customer.ShippingAddress.Country;
                pc.Customer.BillingAddress.City = pc.Customer.ShippingAddress.City;

                var products = new List<Product>();
                var customProducts = pc.Order.CustomProducts;
                if (customProducts.Product1.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product1.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product1.Discount; product.SalePrice = pc.Order.CustomProducts.Product1.SalePrice; products.Add(product); }
                if (customProducts.Product2.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product2.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product2.Discount; product.SalePrice = pc.Order.CustomProducts.Product2.SalePrice; products.Add(product); }
                if (customProducts.Product3.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product3.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product3.Discount; product.SalePrice = pc.Order.CustomProducts.Product3.SalePrice; products.Add(product); }
                if (customProducts.Product4.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product4.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product4.Discount; product.SalePrice = pc.Order.CustomProducts.Product4.SalePrice; products.Add(product); }
                if (customProducts.Product5.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product5.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product5.Discount; product.SalePrice = pc.Order.CustomProducts.Product5.SalePrice; products.Add(product); }
                if (customProducts.Product6.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product6.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product6.Discount; product.SalePrice = pc.Order.CustomProducts.Product6.SalePrice; products.Add(product); }
                if (customProducts.Product7.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product7.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product7.Discount; product.SalePrice = pc.Order.CustomProducts.Product7.SalePrice; products.Add(product); }
                if (customProducts.Product8.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product8.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product8.Discount; product.SalePrice = pc.Order.CustomProducts.Product8.SalePrice; products.Add(product); }
                if (customProducts.Product9.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product9.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product9.Discount; product.SalePrice = pc.Order.CustomProducts.Product9.SalePrice; products.Add(product); }
                if (customProducts.Product10.UrlName != null) { var productJson = await GetRequest($"/Product/GetProductWithUrlName/{customProducts.Product10.UrlName}"); Product product = JsonConvert.DeserializeObject<Product>(productJson); product.Discount = pc.Order.CustomProducts.Product10.Discount; product.SalePrice = pc.Order.CustomProducts.Product10.SalePrice; products.Add(product); }

                // ------------------------Post Customer-------------------------

                var customerId = await PostCustomer(pc.Customer);
                if (customerId == 0)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: could not post customer");
                    return Json(new { ok = false, error = "could not post customer" });
                }

                pc.Customer.Id = customerId;

                // ------------------------Post Payment Capture-------------------------

                var paymentCapture = new PaymentCapture { Captured = true, MobilePay = true, CustomerId = customerId };
                var response = await PostRequest("/PaymentCapture/PostPaymentCapture", paymentCapture);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: could not post paymentCapture");
                    return Json(new { ok = false, error = "could not post paymentCapture" });
                }
                var json = await GetRequest(response.Headers.Location.AbsolutePath);
                paymentCapture.Id = JsonConvert.DeserializeObject<PaymentCapture>(json).Id;
                paymentCapture.Customer = pc.Customer;

                // ------------------------Post Order-------------------------

                var order = BuildOrder2(paymentCapture.Id, products);

                var orderResult = await PostOrder(order);
                if (orderResult == default)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: could not post order");
                    return Json(new { ok = false, error = "could not post order" });
                }

                order = orderResult;

                paymentCapture.Order = order;
                // Post Invoice

                Models.Invoice invoice = new Models.Invoice
                {
                    CreatedAt = DateTime.Now,
                    PaymentCaptureId = paymentCapture.Id,
                    TotalPrice = paymentCapture.Order.TotalPrice,
                    TaxLessPrice = paymentCapture.Order.TaxLessPrice,
                    Taxes = paymentCapture.Order.Taxes
                };

                response = await PostRequest("/Invoice/PostInvoice", invoice);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
                    return Json(new { ok = false, error = "could not post invoice" });
                }
                json = await GetRequest(response.Headers.Location.AbsolutePath);
                invoice = JsonConvert.DeserializeObject<Models.Invoice>(json);
                paymentCapture.Invoice = invoice;

                var fileName = "Faktura-" + paymentCapture.Customer.BillingAddress.Name;
                var viewString = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/InvoiceEmail.cshtml", paymentCapture);
                var invoicePdf = await razorViewToStringRenderer.PdfSharpConvert(viewString, fileName);
                if (invoicePdf == null)
                {
                    return Json(new { ok = false, error = "could not create invoice" });
                }

                // ------------------------Send Emails-------------------------

                var emailResponse = await mailService.SendNykantEmailAsync(order);
                if (emailResponse == "fail")
                {
                    _logger.LogError($"time: {DateTime.Now} - error: could not send nykant email");
                    await OrderError(order);
                    return Json(new { ok = false, error = "email error" });
                }

                emailResponse = await mailService.SendOrderEmailAsync(order, invoicePdf);
                if (emailResponse == "fail")
                {
                    _logger.LogError($"time: {DateTime.Now} - error: could not send order email");
                    await OrderError(order);
                    return Json(new { ok = false, error = "email error" });
                }

                if (!pc.Test)
                {
                    emailResponse = await mailService.SendDKIEmailAsync(order);
                    if (emailResponse == "fail")
                    {
                        _logger.LogError($"time: {DateTime.Now} - error: could not send DKi email");
                        await OrderError(order);
                        return Json(new { ok = false, error = "email error" });
                    }
                }

                json = await GetRequest("/Product/GetProducts");
                products = JsonConvert.DeserializeObject<List<Product>>(json);

                ViewBag.Products = products;

                return View();
            }

            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Json(new { ok = false, error = e.Message });
            }
        }
    }
}
