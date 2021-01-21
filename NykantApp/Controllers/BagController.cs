//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using NykantApp.Models;

//namespace NykantApp.Controllers
//{

//    public class BagController : BaseController
//    {
//        public BagController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<BaseController> logger) : base(signInManager, userManager, logger)
//        {
//        }

//        public IActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var bagItems = _context.BagItems
//                .Include(b => b.Bag)
//                .Include(b => b.Product)
//                .Where(x => x.BagId == id);

//            int priceSum = 0;
//            foreach (var bagItem in bagItems)
//            {
//                priceSum += bagItem.Product.Price;
//            }

//            if (bagItems == null)
//            {
//                return NotFound();
//            }

//            ViewBag.PriceSum = priceSum;
//            ViewBag.BagId = id;

//            return View(bagItems);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AddProduct(int productId, string bagId, int productQuantity)
//        {
//            if (!_signInManager.IsSignedIn(User))
//            {
//                return Content("Must be signed in");
//            }
//            else if (BagItemExists(bagId, productId))
//            {
//                var bagItem = _context.BagItems.FirstOrDefault(x => x.BagId == bagId && x.ProductId == productId);
//                bagItem.Quantity += productQuantity;
//                _context.BagItems.Update(bagItem);
//                _context.SaveChanges();
//                return Content($"You already had this product in your bag, but now added {productQuantity} to the quantity");
//            }
//            else
//            {
//                var bagItem = new BagItem { ProductId = productId, BagId = bagId, Quantity = productQuantity };
//                _context.BagItems.Add(bagItem);
//                _context.SaveChanges();
//                return Content("Success");
//            }
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteBagItem(int productId, string bagId)
//        {
//            var bagItem = await _context.BagItems.FindAsync(bagId, productId);
//            _context.BagItems.Remove(bagItem);
//            await _context.SaveChangesAsync();
//            return Redirect($"Details/{bagId}");
//        }

//        private bool BagItemExists(string bagId, int productId)
//        {
//            return _context.BagItems.Any(e => e.BagId == bagId && e.ProductId == productId);
//        }

//        private bool BagExists(string id)
//        {
//            return _context.Bags.Any(e => e.UserId == id);
//        }

//    }
//}
