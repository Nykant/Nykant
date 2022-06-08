using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Friends;
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
    public class BagController : BaseController
    {
        public BagController(ILogger<BagController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
        }

        [Route("Kurv")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            if (User.Identity.IsAuthenticated)
            {
                string subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                var json = await GetRequest($"/BagItem/GetBagItems/{subject}");
                List<BagItem> bagItems = JsonConvert.DeserializeObject<List<BagItem>>(json);

                ViewBag.PriceSum = OrderHelpers.CalculateAmount(bagItems);

                return View(bagItems);
            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                if (bagItems == null)
                {
                    bagItems = new List<BagItem>();
                    ViewBag.DeliveryInfo = null;
                    //ViewBag.DeliveryDate = null;
                    ViewBag.Taxes = 0;
                    ViewBag.TaxlessPrice = 0;
                    ViewBag.Discount = 0;
                    ViewBag.PriceSum = 0;
                    return View(bagItems);
                }
                else
                {
                    var total = OrderHelpers.CalculateAmount(bagItems);
                    var taxes = total / 5;
                    var taxlessPrice = total - taxes;
                    ViewBag.DeliveryInfo = OrderHelpers.DeliveryDateInfo(bagItems);
                    //var date = OrderHelpers.CalculateDeliveryDate(bagItems);
                    //ViewBag.DeliveryDate = $"{date.Day}-{date.Month}-{date.Year}";
                    ViewBag.Taxes = taxes;
                    ViewBag.TaxlessPrice = taxlessPrice;
                    ViewBag.Discount = 0;
                    ViewBag.PriceSum = total;
                    return View(bagItems);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActivateCoupon(string couponCode)
        {
            try
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                if (bagItems == null)
                {
                    ViewBag.CouponResponse = "<p class='red-text'>Der er ingen varer i din kurv</p>";
                    ViewBag.Taxes = 0;
                    ViewBag.TaxlessPrice = 0;
                    ViewBag.Discount = 0;
                    ViewBag.PriceSum = 0;
                }
                else
                {
                    var total = OrderHelpers.CalculateAmount(bagItems);
                    var taxes = total / 5;
                    var taxlessPrice = total - taxes;
                    var json = await GetRequest($"/Coupon/Get/{couponCode}");
                    if (json == "null")
                    {
                        ViewBag.CouponResponse = "<p class='red-text'>Rabat koden findes ikke</p>";
                        ViewBag.Discount = 0;
                        ViewBag.TaxlessPrice = taxlessPrice;
                        ViewBag.Taxes = taxes;
                        ViewBag.PriceSum = total;
                    }
                    else
                    {
                        var coupon = JsonConvert.DeserializeObject<Coupon>(json);

                        if (coupon.Enabled)
                        {
                            if (coupon.ForAllProducts)
                            {
                                double discount = total * (double.Parse(coupon.Discount.ToString()) / 100);
                                total = total - discount;
                                taxes = total / 5;
                                taxlessPrice = total - taxes;
                                ViewBag.CouponCode = couponCode;
                                ViewBag.DiscountPercentage = coupon.Discount;
                                ViewBag.CouponResponse = "<p class='green-text'>Rabat koden er aktiveret</p>";
                                ViewBag.Discount = discount;
                                ViewBag.TaxlessPrice = taxlessPrice;
                                ViewBag.Taxes = taxes;
                                ViewBag.PriceSum = total;
                            }
                            else
                            {
                                var discountProducts = OrderHelpers.GetDiscountProducts(coupon.CouponForProducts, bagItems);
                                if(discountProducts.Count == 0)
                                {
                                    ViewBag.CouponResponse = "<p class='red-text'>Rabat koden virker ikke på nogen af de produkter du har valgt</p>";
                                    ViewBag.Discount = 0;
                                    ViewBag.TaxlessPrice = taxlessPrice;
                                    ViewBag.Taxes = taxes;
                                    ViewBag.PriceSum = total;
                                }
                                else
                                {
                                    double discount = OrderHelpers.CalculateAmount(discountProducts) * (double.Parse(coupon.Discount.ToString()) / 100);
                                    total = total - discount;
                                    taxes = total / 5;
                                    taxlessPrice = total - taxes;
                                    ViewBag.CouponCode = couponCode;
                                    ViewBag.DiscountPercentage = coupon.Discount;
                                    if(discountProducts.Count == bagItems.Count)
                                    {
                                        ViewBag.CouponResponse = "<p class='green-text'>Rabat koden er aktiveret</p>";
                                    }
                                    else
                                    {
                                        ViewBag.CouponResponse = "<p class='green-text'>Rabat koden er aktiveret for nogle af produkterne i din kurv</p>";
                                    }
                                    
                                    ViewBag.Discount = discount;
                                    ViewBag.TaxlessPrice = taxlessPrice;
                                    ViewBag.Taxes = taxes;
                                    ViewBag.PriceSum = total;
                                }
                            }
                        }
                        else
                        {
                            ViewBag.CouponResponse = "<p class='red-text'>Rabat koden er ikke aktiveret</p>";
                            ViewBag.Discount = 0;
                            ViewBag.TaxlessPrice = taxlessPrice;
                            ViewBag.Taxes = taxes;
                            ViewBag.PriceSum = total;
                        }
                    }
                }

                

                return new PartialViewResult
                {
                    ViewName = "/Views/Bag/_OrderInfoPartial.cshtml",
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
        public async Task<IActionResult> UpdateBagItem(BagItem bagItem, int selection)
        {
            int bagItemQuantity = HttpContext.Session.Get<int>(BagItemAmountKey);
            if (User.Identity.IsAuthenticated)
            {
                if (selection == 1)
                {
                    bagItem.Quantity += 1;
                }
                else if (selection == 2)
                {
                    bagItem.Quantity -= 1;
                }
                else
                {
                    return NoContent();
                }

                if (bagItem.Quantity <= 0)
                {
                    var response = await DeleteRequest($"/BagItem/DeleteBagItem/{bagItem.Subject}/{bagItem.ProductId}");

                    if (response.IsSuccessStatusCode)
                    {
                        bagItemQuantity -= 1;
                        HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                        ViewData.Model = JsonConvert.DeserializeObject<List<BagItem>>(await GetRequest($"/bagitem/getbagitems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}"));
                        return new PartialViewResult
                        {
                            ViewName = "_BagTablePartial",
                            ViewData = this.ViewData
                        };
                    }
                    return Content("Failed");
                }
                else
                {
                    var response = await PatchRequest("/BagItem/UpdateBagItem", bagItem);

                    if (response.IsSuccessStatusCode)
                    {
                        ViewData.Model = JsonConvert.DeserializeObject<List<BagItem>>(await GetRequest($"/bagitem/getbagitems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}"));
                        return new PartialViewResult
                        {
                            ViewName = "_BagTablePartial",
                            ViewData = this.ViewData
                        };
                    }
                    return Content("Failed");
                }

            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

                for (int i = 0; i < bagItems.Count(); i++)
                {
                    if (bagItems[i].ProductId == bagItem.ProductId)
                    {
                        switch (selection)
                        {
                            case 1:
                                bagItems[i].Quantity += 1;
                                if (bagItems[i].Quantity <= 0)
                                {
                                    bagItems.RemoveAt(i);
                                    bagItemQuantity -= 1;
                                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                                }
                                break;

                            case 2:
                                bagItems[i].Quantity -= 1;
                                if (bagItems[i].Quantity <= 0)
                                {
                                    bagItems.RemoveAt(i);
                                    bagItemQuantity -= 1;
                                    HttpContext.Session.Set<int>(BagItemAmountKey, bagItemQuantity);
                                }
                                break;
                        }
                    }
                }
                ViewData.Model = bagItems;
                HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                return new PartialViewResult
                {
                    ViewName = "_BagTablePartial",
                    ViewData = this.ViewData
                };
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPrice()
        {
            if (User.Identity.IsAuthenticated)
            {
                var sub = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                var bagitemList = JsonConvert.DeserializeObject<List<BagItem>>(await GetRequest($"/BagItem/GetBagItems/{sub}"));
                var price = OrderHelpers.CalculateAmount(bagitemList);
                return Json( new { price });
            }
            else
            {
                var bagitemList = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                var price = OrderHelpers.CalculateAmount(bagitemList);
                return Json(new { price });
            }
        }


    }
}
