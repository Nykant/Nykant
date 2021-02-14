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
using NykantAPI.Models;
using NykantAPI.Models.DTO;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class BagItemController : BaseController
    {
        public BagItemController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpGet("{subject}")]
        public ActionResult<BagDetailsDTO> GetBagItems(string subject)
        {
            int priceSum = 0;
            var bagItems = _context.BagItems
                .Include(x => x.Product)
                .Where(x => x.Subject == subject);

            foreach (var bagItem in bagItems)
            {
                priceSum += bagItem.Product.Price;
            }

            BagDetailsDTO bagDetails = new BagDetailsDTO
            {
                BagItems = bagItems,
                PriceSum = priceSum
            };

            var json = JsonConvert.SerializeObject(bagDetails, Extensions.JsonOptions.jsonSettings);

            return Ok(json);
        }

        [HttpPatch]
        public async Task<ActionResult<BagItem>> UpdateBagItem(BagItem bagItem)
        {
            if(BagItemExists(bagItem.Subject, bagItem.ProductId))
            {
                try
                {
                    _context.BagItems.Update(bagItem);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return NotFound(e);
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

        [HttpPost]
        public async Task<ActionResult<BagItem>> PostBagItem(BagItem bagItem)
        {
            if (BagItemExists(bagItem.Subject, bagItem.ProductId))
            {
                _context.BagItems.Update(bagItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                try
                {
                    await _context.BagItems.AddAsync(bagItem);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetBagItems", new { subject = bagItem.Subject }, bagItem);
                }
                catch (Exception e)
                {
                    return Conflict(e.Message);
                }
            }
        }

        private bool BagItemExists(string sub, int productId)
        {
            return _context.BagItems.Any(e => e.Subject == sub && e.ProductId == productId);
        }

    }
}
