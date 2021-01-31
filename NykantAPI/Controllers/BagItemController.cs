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
    [ApiController]
    public class BagItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BagItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("api/{controller}/{action}/{productId}/{bagId}/{productQuantity}")]
        public async Task<ActionResult<BagItem>> AddBagItem(int productId, int bagId, int productQuantity)
        {
            if (BagItemExists(bagId, productId))
            {
                var bagItem = _context.BagItems.FirstOrDefault(x => x.BagId == bagId && x.ProductId == productId);
                bagItem.Quantity += productQuantity;
                _context.BagItems.Update(bagItem);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                try
                {
                    var bagItem = new BagItem { ProductId = productId, BagId = bagId, Quantity = productQuantity };
                    _context.BagItems.Add(bagItem);
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception e)
                {
                    return Conflict(e.Message);
                }
            }
        }

        [HttpDelete("api/{controller}/{action}/{productId}/{bagId}")]
        public async Task<IActionResult> DeleteBagItem(int productId, int bagId)
        {
            var bagItem = await _context.BagItems.FindAsync(bagId, productId);
            _context.BagItems.Remove(bagItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            return Ok();
        }

        private bool BagItemExists(int bagId, int productId)
        {
            return _context.BagItems.Any(e => e.BagId == bagId && e.ProductId == productId);
        }

        //// GET: api/BagItem
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BagItem>>> GetBagItems()
        //{
        //    return await _context.BagItems.ToListAsync();
        //}

        // GET: api/BagItem/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BagItem>> GetBagItem(string id)
        //{
        //    var bagItem = await _context.BagItems.FindAsync(id);

        //    if (bagItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return bagItem;
        //}

        //// PUT: api/BagItem/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBagItem(int id, BagItem bagItem)
        //{
        //    if (id != bagItem.BagId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bagItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BagItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/BagItem
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<BagItem>> PostBagItem(BagItem bagItem)
        //{
        //    _context.BagItems.Add(bagItem);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (BagItemExists(bagItem.BagId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetBagItem", new { id = bagItem.BagId }, bagItem);
        //}

        //// DELETE: api/BagItem/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<BagItem>> DeleteBagItem(string id)
        //{
        //    var bagItem = await _context.BagItems.FindAsync(id);
        //    if (bagItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.BagItems.Remove(bagItem);
        //    await _context.SaveChangesAsync();

        //    return bagItem;
        //}

        //private bool BagItemExists(int id)
        //{
        //    return _context.BagItems.Any(e => e.BagId == id);
        //}
    }
}
