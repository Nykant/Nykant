﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class CouponController : BaseController
    {
        public CouponController(ILogger<CouponController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var json = await GetRequest($"/Coupon/Get");
            var coupons = JsonConvert.DeserializeObject<List<Coupon>>(json);
            return View(coupons);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var json = await GetRequest($"/Product/GetProducts");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            ViewBag.Products = products;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Enable(string code) // dont use the model, it fucks, and go get the whole model and update that 
        {
            try
            {
                var json = await GetRequest($"/Coupon/Get/{code}");
                var coupon = JsonConvert.DeserializeObject<Coupon>(json);
                coupon.Enabled = true;
                var response = await PatchRequest("/Coupon/Update", coupon);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                json = await GetRequest($"/Coupon/Get");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Content("error: Delete Coupon Failed");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Disable(string code) // dont use the model, it fucks, and go get the whole model and update that 
        {
            try
            {
                var json = await GetRequest($"/Coupon/Get/{code}");
                var coupon = JsonConvert.DeserializeObject<Coupon>(json);
                coupon.Enabled = false;
                var response = await PatchRequest("/Coupon/Update", coupon);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode}");
                    return Content("error: Delete Coupon Failed");
                }
                json = await GetRequest($"/Coupon/Get");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Content("error: Delete Coupon Failed");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(Coupon coupon, string couponForProducts)
        {
            try
            {
                coupon.CreatedAt = DateTime.Now;
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Content("error: Delete Coupon Failed");
            }

        }

        [Authorize(Roles = "Admin")]
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Content("error: Delete Coupon Failed");
            }
            
        }
    }
}
