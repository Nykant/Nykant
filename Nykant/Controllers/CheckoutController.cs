using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nykant.Areas.Identity.Data;
using Nykant.Data;
using Nykant.Models;
using Nykant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Controllers
{
    public class CheckoutController : BaseController
    {
        public CheckoutController(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<BaseController> logger) : base(context, signInManager, userManager, logger)
        {
        }

        public IActionResult ShippingInfo(string bagId, int priceSum)
        {
            var bagItems = _context.BagItems
                .Include(b => b.Bag)
                .Include(b => b.Product)
                .Where(x => x.BagId == bagId);

            CheckoutVM checkoutVM = new CheckoutVM
            {
                PriceSum = priceSum,
                BagItems = bagItems
            };

            return View(checkoutVM);
        }

        [HttpPost]
        public IActionResult ShippingInfo(CheckoutVM checkoutVM)
        {
            Shipping shipping = checkoutVM.Shipping;
            if (_signInManager.IsSignedIn(User))
            {
                shipping.UserId = _userManager.GetUserId(User);
            }
            _context.Shippings.Add(shipping);
            _context.SaveChanges();
            checkoutVM.Shipping = shipping;

            return RedirectToAction("InfoCheck", checkoutVM);
        }

        public IActionResult InfoCheck(CheckoutVM checkoutVM)
        {
            return View(checkoutVM);
        }
    }
}
