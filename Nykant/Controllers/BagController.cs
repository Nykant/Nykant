using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nykant.Data;
using Nykant.Models;

namespace Nykant.Controllers
{
    
    public class BagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BagController(ApplicationDbContext context)
        {
            _context = context;
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

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.UserId == id);
        }

    }
}
