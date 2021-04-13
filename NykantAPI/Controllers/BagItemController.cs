using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Extensions;
using NykantAPI.Models;
using NykantAPI.Models.DTO;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]/")]
    public class BagItemController : BaseController
    {
        public BagItemController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpGet("{subject}")]
        public async Task<ActionResult<List<BagItem>>> GetBagItems(string subject)
        {
            var bagItems = _context.BagItems
                .Include(x => x.Product)
                .Where(x => x.Subject == subject);

            var json = JsonConvert.SerializeObject(bagItems, Extensions.JsonOptions.jsonSettings);

            return Ok(json);
        }

        [HttpPatch]
        public async Task<ActionResult<BagItem>> UpdateBagItem(BagItem bagItem)
        {
            if (BagItemExists(bagItem.Subject, bagItem.ProductId))
            {
                try
                {
                    var entity = _context.BagItems.Update(bagItem).Entity;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return Conflict(e.Message);
                }
            }
            return NotFound();
        }

        [HttpPatch]
        public async Task<ActionResult<BagItem>> AddBagItem(BagItem bagItem)
        {
            if (BagItemExists(bagItem.Subject, bagItem.ProductId))
            {
                try
                {
                    var bagitemDb = await _context.BagItems.FindAsync(bagItem.Subject, bagItem.ProductId);
                    bagitemDb.Quantity += 1;
                    _context.BagItems.Update(bagitemDb);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return Conflict(e.Message);
                }
            }
            return NotFound();
        }

        [HttpDelete("{subject}")]
        public async Task<ActionResult<BagItem>> DeleteBagItems(string subject)
        {
            try
            {
                foreach (var item in _context.BagItems)
                {
                    _context.BagItems.Remove(item);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok();
        }

        [HttpDelete("{subject}/{productId}")]
        public async Task<ActionResult<BagItem>> DeleteBagItem(string subject, int productId)
        {
            try
            {
                _context.BagItems.Remove(await _context.BagItems.FindAsync(subject, productId));
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<BagItem>> PostBagItem(BagItem bagItem)
        {

            if (ModelState.IsValid)
            {

                if(!BagItemExists(bagItem.Subject, bagItem.ProductId))
                {
                    try
                    {
                        _context.BagItems.Add(bagItem);
                        await _context.SaveChangesAsync();
                        return CreatedAtAction("GetBagItem", new { subject = bagItem.Subject, productId = bagItem.ProductId }, bagItem);
                    }
                    catch (Exception e)
                    {
                        return Conflict(e.Message);
                    }
                }
                else
                {
                    return await AddBagItem(bagItem);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{subject}/{productId}")]
        public async Task<ActionResult<BagItem>> GetBagItem(string subject, int productId)
        {
            return Ok(JsonConvert.SerializeObject(await _context.BagItems.FindAsync(subject, productId)));
        }

        [HttpGet("{subject}")]
        public async Task<ActionResult<int>> GetBagItemsQuantity(string subject)
        {
            return Ok(JsonConvert.SerializeObject(await _context.BagItems.Where(x => x.Subject == subject).CountAsync()));
        }

        private bool BagItemExists(string sub, int productId)
        {
            return _context.BagItems.Any(e => e.Subject == sub && e.ProductId == productId);
        }

    }
}
