using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nykant.Areas.Identity.Data;
using Nykant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Controllers
{
    [Route("{controller}/{action}/{bagId?}/{priceSum?}")]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<BaseController> logger) : base(context, signInManager, userManager, logger)
        {
        }

        public IActionResult Checkout(string bagId, int priceSum)
        {
            var bagItems = _context.BagItems
                .Include(b => b.Bag)
                .Include(b => b.Product)
                .Where(x => x.BagId == bagId);

            ViewBag.PriceSum = priceSum;

            return View(bagItems);
        }
    }
}
