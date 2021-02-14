using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {

        }

        [HttpGet]
        public IActionResult CustomerInfo(BagVM bagVM)
        {
            if (ModelState.IsValid)
            {
                CheckoutVM checkoutVM = new CheckoutVM
                {
                    BagItems = bagVM.BagItems,
                    PriceSum = bagVM.PriceSum
                };
                return View(checkoutVM);  
            }

            return RedirectToAction("Details", "Bag");
        }

        [HttpGet]
        public IActionResult CustomerInfoCrumb(CheckoutVM checkoutVM)
        {
            return View("CustomerInfo", checkoutVM);
        }

        [HttpGet]
        public IActionResult ShippingCrumb(CheckoutVM checkoutVM)
        {
            return View("Shipping", checkoutVM);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerInfo(CheckoutVM checkoutVM)
        {
            if (User.Identity.IsAuthenticated)
            {
                checkoutVM.CustomerInfo.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

                var order = BuildOrder(checkoutVM);
                checkoutVM.Order = order;

                var response = await PostRequest("CustomerInfo/PostCustomerInfo", checkoutVM);

                if (response.IsSuccessStatusCode)
                {
                    return View("Shipping", checkoutVM);
                }
                return Content("Failed");
            }

            return View("Shipping", checkoutVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddShipping(CheckoutVM checkoutVM)
        {

            Models.Order order = new Models.Order
            {
                 CustomerInfoEmail = checkoutVM.CustomerInfo.Email,
                 ShippingOptionName = checkoutVM.ShippingOption.Name,
            };

            var response = await PatchRequest("Order/UpdateOrder", order);
            checkoutVM.ClientSecret = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return View("Payment", checkoutVM);
            }
            return Content("Failed to create order");
        }



        private Models.Order BuildOrder(CheckoutVM checkoutVM)
        {
            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Status = Status.Created,
                Subject = checkoutVM.Subject,
                TotalPrice = checkoutVM.PriceSum,
                CustomerInfoEmail = checkoutVM.CustomerInfo.Email
            };
            return order;
        }

        
    }
}
