using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NykantAPI.Data;
using NykantAPI.Models;

namespace NykantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BagItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BagItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BagItem>>> GetBagItems()
        {
            return await _context.BagItems.ToListAsync();
        }

        // GET: api/BagItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BagItem>> GetBagItem(string id)
        {
            var bagItem = await _context.BagItems.FindAsync(id);

            if (bagItem == null)
            {
                return NotFound();
            }

            return bagItem;
        }

        // PUT: api/BagItem/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagItem(int id, BagItem bagItem)
        {
            if (id != bagItem.BagId)
            {
                return BadRequest();
            }

            _context.Entry(bagItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BagItem
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BagItem>> PostBagItem(BagItem bagItem)
        {
            _context.BagItems.Add(bagItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BagItemExists(bagItem.BagId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBagItem", new { id = bagItem.BagId }, bagItem);
        }

        // DELETE: api/BagItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BagItem>> DeleteBagItem(string id)
        {
            var bagItem = await _context.BagItems.FindAsync(id);
            if (bagItem == null)
            {
                return NotFound();
            }

            _context.BagItems.Remove(bagItem);
            await _context.SaveChangesAsync();

            return bagItem;
        }

        private bool BagItemExists(int id)
        {
            return _context.BagItems.Any(e => e.BagId == id);
        }
    }
}
