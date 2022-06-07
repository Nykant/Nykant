using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class CouponController : BaseController
    {
        public CouponController(ILogger<CouponController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var json = await GetRequest($"/Coupon/Get");
            var coupons = JsonConvert.DeserializeObject<List<Coupon>>(json);
            return View(coupons);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var json = await GetRequest($"/Product/GetProducts");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enable(Coupon coupon) // dont use the model, it fucks, and go get the whole model and update that 
        {
            try
            {
                coupon.Enabled = true;
                var response = await PatchRequest("/Coupon/Update", coupon);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                var json = await GetRequest($"/Coupon/Get");
                var coupons = JsonConvert.DeserializeObject<List<Coupon>>(json);
                ViewData.Model = coupons;
                return new PartialViewResult
                {
                    ViewName = "/Views/Coupon/_CouponListPartial.cshtml",
                    ViewData = this.ViewData
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
                return Content("error: Delete Coupon Failed");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Disable(Coupon coupon) // dont use the model, it fucks, and go get the whole model and update that 
        {
            try
            {
                coupon.Enabled = false;
                var response = await PatchRequest("/Coupon/Update", coupon);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                var json = await GetRequest($"/Coupon/Get");
                var coupons = JsonConvert.DeserializeObject<List<Coupon>>(json);
                ViewData.Model = coupons;
                return new PartialViewResult
                {
                    ViewName = "/Views/Coupon/_CouponListPartial.cshtml",
                    ViewData = this.ViewData
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
                return Content("error: Delete Coupon Failed");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(Coupon coupon, string couponForProducts)
        {
            try
            {
                var response = await PostRequest("/Coupon/Post", coupon);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                if (!coupon.ForAllProducts)
                {
                    var productIds = couponForProducts.Split(',');
                    foreach (var item in productIds)
                    {
                        CouponForProduct couponForProduct = new CouponForProduct
                        {
                            CouponCode = coupon.Code,
                            ProductId = int.Parse(item)
                        };
                        response = await PostRequest("/CouponForProduct/Post", couponForProduct);
                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                            return Content("error: Delete Coupon Failed");
                        }
                    }
                }

                var json = await GetRequest($"/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                ViewBag.Products = products;
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
                return Content("error: Delete Coupon Failed");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                var response = await DeleteRequest($"/CouponForProduct/Delete/{code}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                response = await DeleteRequest($"/Coupon/Delete/{code}");
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                var json = await GetRequest($"/Coupon/Get");
                var coupons = JsonConvert.DeserializeObject<List<Coupon>>(json);
                ViewData.Model = coupons;
                return new PartialViewResult
                {
                    ViewName = "/Views/Coupon/_CouponListPartial.cshtml",
                    ViewData = this.ViewData
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {e.Message}");
                return Content("error: Delete Coupon Failed");
            }
            
        }
    }
}
