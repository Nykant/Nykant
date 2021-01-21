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
    public class BagController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
        {
            return await _context.Bags.ToListAsync();
        }

        // GET: api/Bag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bag>> GetBag(string id)
        {
            var bag = await _context.Bags.FindAsync(id);

            if (bag == null)
            {
                return NotFound();
            }

            return bag;
        }

        // PUT: api/Bag/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBag(string id, Bag bag)
        {
            if (id != bag.UserId)
            {
                return BadRequest();
            }

            _context.Entry(bag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagExists(id))
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

        // POST: api/Bag
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bag>> PostBag(Bag bag)
        {
            _context.Bags.Add(bag);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BagExists(bag.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBag", new { id = bag.UserId }, bag);
        }

        // DELETE: api/Bag/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bag>> DeleteBag(string id)
        {
            var bag = await _context.Bags.FindAsync(id);
            if (bag == null)
            {
                return NotFound();
            }

            _context.Bags.Remove(bag);
            await _context.SaveChangesAsync();

            return bag;
        }

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.UserId == id);
        }
    }
}
