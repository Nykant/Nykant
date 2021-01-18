using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nykant.Areas.Identity.Data;
using Nykant.Data;
using Nykant.Models;

namespace Nykant.Controllers
{
    
    public class BagController : BaseController
    {
        public BagController(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<BaseController> logger) : base(context, signInManager, userManager, logger)
        {
        }

        // GET: Bag
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bags.ToListAsync());
        }

        // GET: Bag/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagItems = _context.BagItems
                .Include(b => b.Bag)
                .Include(b => b.Product)
                .Where(x => x.BagId == id);

            if (bagItems == null)
            {
                return NotFound();
            }

            return View(bagItems);
        }

        [Route("{controller}/{action}/{productId?}/{bagId?}/{productQuantity?}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(int productId, string bagId, int productQuantity)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return Content("Must be signed in");
            }
            else if (BagItemExists(bagId, productId)) 
            {
                var bagItem = _context.BagItems.FirstOrDefault(x => x.BagId == bagId && x.ProductId == productId);
                bagItem.Quantity += productQuantity;
                _context.BagItems.Update(bagItem);
                _context.SaveChanges();
                return Content($"You already had this product in your bag, but now added {productQuantity} to the quantity");
            }
            else
            {
                var bagItem = new BagItem { ProductId = productId, BagId = bagId, Quantity = productQuantity};
                _context.BagItems.Add(bagItem);
                _context.SaveChanges();
                return Content("Success");
            }
        }

        [Route("{controller}/{action}/{productId?}/{bagId?}")]
        // POST: BagItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBagItem(int productId, string bagId)
        {
            var bagItem = await _context.BagItems.FindAsync(bagId, productId);
            _context.BagItems.Remove(bagItem);
            await _context.SaveChangesAsync();
            return Redirect($"Details/{bagId}");
        }

        private bool BagItemExists(string bagId, int productId)
        {
            return _context.BagItems.Any(e => e.BagId == bagId && e.ProductId == productId);
        }

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.UserId == id);
        }

    }
}
