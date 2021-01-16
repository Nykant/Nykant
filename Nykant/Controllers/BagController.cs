using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nykant.Areas.Identity.Data;
using Nykant.Data;
using Nykant.Models;

namespace Nykant.Controllers
{
    
    public class BagController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        public BagController(ApplicationDbContext context, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
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

            var bag = await _context.Bags
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // GET: Bag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId")] Bag bag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bag);
        }

        // GET: Bag/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }
            return View(bag);
        }

        // POST: Bag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId")] Bag bag)
        {
            if (id != bag.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagExists(bag.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bag);
        }

        // GET: Bag/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bag = await _context.Bags
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (bag == null)
            {
                return NotFound();
            }

            return View(bag);
        }

        // POST: Bag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bag = await _context.Bags.FindAsync(id);
            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
            else if (BagItemExist(productId, bagId)) 
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

        private bool BagItemExist(int productId, string bagId)
        {
            foreach (var bagItem in _context.BagItems)
            {
                if (bagItem.BagId == bagId && bagItem.ProductId == productId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.UserId == id);
        }

    }
}
