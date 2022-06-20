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

                ViewBag.PriceSum = OrderHelpers.CalculateTotal(bagItems);

                return View(bagItems);
            }
            else
            {
                HttpContext.Session.Set<string>(CouponCodeKey, null);
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
                    bagItems = OrderHelpers.SetBagItemsPrice(bagItems);
                    HttpContext.Session.Set(BagSessionKey, bagItems);
                    //var couponCode = HttpContext.Session.Get<string>(CouponCodeKey);
                    //if (couponCode != null)
                    //{
                    //    await ManageCoupon(bagItems, couponCode);
                    //    ViewBag.DeliveryInfo = OrderHelpers.DeliveryDateInfo(bagItems);
                    //}
                    //else
                    //{
                        var total = OrderHelpers.CalculateTotal(bagItems);
                        var taxes = total / 5;
                        var taxlessPrice = total - taxes;
                        ViewBag.DeliveryInfo = OrderHelpers.DeliveryDateInfo(bagItems);
                        //var date = OrderHelpers.CalculateDeliveryDate(bagItems);
                        //ViewBag.DeliveryDate = $"{date.Day}-{date.Month}-{date.Year}";
                        ViewBag.Taxes = taxes;
                        ViewBag.TaxlessPrice = taxlessPrice;
                        ViewBag.Discount = OrderHelpers.CalculateDiscount(bagItems);
                        ViewBag.PriceSum = total;
                    //}

                    return View(bagItems);
                }
            }
        }

        public async Task ManageCoupon(List<BagItem> bagItems, string couponCode)
        {
            if (bagItems == null || bagItems.Count == 0)
            {
                ViewBag.CouponResponse = "<p class='red-text'>Der er ingen varer i din kurv</p>";
                ViewBag.Taxes = 0;
                ViewBag.TaxlessPrice = 0;
                ViewBag.Discount = 0;
                ViewBag.PriceSum = 0;

                HttpContext.Session.Set<string>(CouponCodeKey, null);
            }
            else
            {
                var total = OrderHelpers.CalculateTotal(bagItems);
                long discount = OrderHelpers.CalculateDiscount(bagItems);
                var taxes = total / 5;
                var taxlessPrice = total - taxes;
                ViewBag.Discount = discount;
                ViewBag.TaxlessPrice = taxlessPrice;
                ViewBag.Taxes = taxes;
                ViewBag.PriceSum = total;

                if (couponCode != null)
                {
                    var json = await GetRequest($"/Coupon/Get/{couponCode}");
                    if (json == "null")
                    {
                        ViewBag.CouponResponse = $"<p class='red-text'>Rabat koden '{couponCode}' findes ikke</p>";
                        //ViewBag.Discount = discount;
                        //ViewBag.TaxlessPrice = taxlessPrice;
                        //ViewBag.Taxes = taxes;
                        //ViewBag.PriceSum = total;

                        HttpContext.Session.Set<string>(CouponCodeKey, null);
                    }
                    else
                    {
                        var coupon = JsonConvert.DeserializeObject<Coupon>(json);
                        bagItems = OrderHelpers.SetBagItemsPrice(bagItems, coupon);
                        HttpContext.Session.Set(BagSessionKey, bagItems);
                        if (coupon.Enabled)
                        {
                            if (coupon.ForAllProducts)
                            {
                                //long couponDiscount = Convert.ToInt64(Math.Round(Convert.ToDouble(OrderHelpers.CalculateTotalWithoutDiscounts(bagItems)) * (Convert.ToDouble(coupon.Discount) / 100)));


                                ViewBag.Coupon = coupon;
                                ViewBag.DiscountPercentage = coupon.Discount;
                                ViewBag.CouponResponse = $"<p class='green-text'>Rabat koden '{couponCode}' er aktiveret</p>";
                                ViewBag.Discount = OrderHelpers.CalculateDiscount(bagItems);
                                ViewBag.PriceSum = OrderHelpers.CalculateTotal(bagItems);
                                ViewBag.Taxes = ViewBag.PriceSum / 5;
                                ViewBag.TaxlessPrice = ViewBag.PriceSum - ViewBag.Taxes;

                                //ViewBag.PriceSum = total;

                                HttpContext.Session.Set<string>(CouponCodeKey, couponCode);
                            }
                            else
                            {
                                var discountProducts = OrderHelpers.GetDiscountProducts(coupon.CouponForProducts, bagItems);
                                if (discountProducts.Count == 0)
                                {
                                    ViewBag.CouponResponse = $"<p class='red-text'>Rabat koden '{couponCode}' virker ikke på nogen af de produkter du har valgt</p>";
                                    //ViewBag.Discount = discount;
                                    //ViewBag.TaxlessPrice = taxlessPrice;
                                    //ViewBag.Taxes = taxes;
                                    //ViewBag.PriceSum = total;

                                    HttpContext.Session.Set<string>(CouponCodeKey, null);
                                }
                                else
                                {
                                    //long couponDiscount = Convert.ToInt64(Math.Round(Convert.ToDouble(OrderHelpers.CalculateTotalWithoutDiscounts(bagItems)) * (Convert.ToDouble(coupon.Discount) / 100)));
                                    //long discount = OrderHelpers.CalculateDiscount(bagItems) + Convert.ToInt64(Math.Round(Convert.ToDouble(OrderHelpers.CalculateTotalWithoutDiscounts(discountProducts)) * (Convert.ToDouble(coupon.Discount) / 100)));
                                    //total = total - couponDiscount;
                                    //taxes = total / 5;
                                    //taxlessPrice = total - taxes;
                                    //ViewBag.CouponCode = coupon;
                                    //ViewBag.DiscountPercentage = coupon.Discount;
                                    if (discountProducts.Count == bagItems.Count)
                                    {
                                        ViewBag.CouponResponse = $"<p class='green-text'>Rabat koden '{couponCode}' er aktiveret</p>";
                                    }
                                    else
                                    {
                                        ViewBag.CouponResponse = $"<p class='green-text'>Rabat koden '{couponCode}' er aktiveret på nogle af produkterne i din kurv</p>";
                                    }

                                    ViewBag.Discount = OrderHelpers.CalculateDiscount(bagItems);
                                    ViewBag.PriceSum = OrderHelpers.CalculateTotal(bagItems);
                                    ViewBag.Taxes = ViewBag.PriceSum / 5;
                                    ViewBag.TaxlessPrice = ViewBag.PriceSum - ViewBag.Taxes;

                                    HttpContext.Session.Set<string>(CouponCodeKey, couponCode);
                                }
                            }
                        }
                        else
                        {
                            ViewBag.CouponResponse = $"<p class='red-text'>Rabat koden '{couponCode}' er ikke aktiveret</p>";
                            //ViewBag.Discount = OrderHelpers.CalculateDiscount(bagItems);
                            //ViewBag.TaxlessPrice = taxlessPrice;
                            //ViewBag.Taxes = taxes;
                            //ViewBag.PriceSum = total;

                            HttpContext.Session.Set<string>(CouponCodeKey, null);
                        }
                    }
                }
                else
                {
                    //ViewBag.Discount = OrderHelpers.CalculateDiscount(bagItems);
                    //ViewBag.TaxlessPrice = taxlessPrice;
                    //ViewBag.Taxes = taxes;
                    //ViewBag.PriceSum = total;

                    HttpContext.Session.Set<string>(CouponCodeKey, null);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> ActivateCoupon(string couponCode)
        {
            try
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

                await ManageCoupon(bagItems, couponCode);

                bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                ViewData.Model = bagItems;
                return new PartialViewResult
                {
                    ViewName = "/Views/Bag/_BagWrapperPartial.cshtml",
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
                            ViewName = "/Views/Bag/_BagWrapperPartial.cshtml",
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
                            ViewName = "/Views/Bag/_BagWrapperPartial.cshtml",
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
                bagItems = OrderHelpers.SetBagItemsPrice(bagItems);
                HttpContext.Session.Set(BagSessionKey, bagItems);

                var couponCode = HttpContext.Session.Get<string>(CouponCodeKey);
                if(couponCode != null)
                {
                    await ManageCoupon(bagItems, couponCode);
                    bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                }
                else
                {
                    ViewBag.Discount = OrderHelpers.CalculateDiscount(bagItems);
                    ViewBag.PriceSum = OrderHelpers.CalculateTotal(bagItems);
                    ViewBag.Taxes = ViewBag.PriceSum / 5;
                    ViewBag.TaxlessPrice = ViewBag.PriceSum - ViewBag.Taxes;
                }

                ViewData.Model = bagItems;
                return new PartialViewResult
                {
                    ViewName = "_BagWrapperPartial",
                    ViewData = this.ViewData
                };
            }
        }



    }
}
