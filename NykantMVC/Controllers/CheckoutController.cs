using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.DTO;
using NykantMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet("{controller}/{action}/{bagItems}")]
        public async Task<IActionResult> CustomerInfo()
        {
            var subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Bag", new { subject });
            }

            
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Bag/GetBag/" + subject;
            var result = await client.GetStringAsync(uri);

            BagDetailsDTO bagd = JsonConvert.DeserializeObject<BagDetailsDTO>(result);

            if (bagd == null)
            {
                return NotFound();
            }

            CheckoutVM checkoutVM = new CheckoutVM
            {
                PriceSum = bagd.PriceSum,
                BagItems = bagd.BagItems
            };

            return View(checkoutVM);
        }

        //[HttpPost]
        //public IActionResult CustomerInfo(CheckoutVM checkoutVM)
        //{
        //    CustomerInfo shipping = checkoutVM.CustomerInfo;
        //    if (_signInManager.IsSignedIn(User))
        //    {
        //        shipping.UserId = _userManager.GetUserId(User);
        //    }
        //    _context.CustomerInfos.Add(shipping);
        //    _context.SaveChanges();
        //    checkoutVM.CustomerInfo = shipping;

        //    return RedirectToAction("Payment", checkoutVM);
        //}

        //public IActionResult Payment(CheckoutVM checkoutVM)
        //{

        //    return View(checkoutVM);
        //}
    }
}
