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
        public ActionResult<BagDTO> GetBagItems(string subject)
        {
            int priceSum = 0;
            var bagItems = _context.BagItems
                .Include(x => x.Product)
                .Where(x => x.Subject == subject);

            foreach (var bagItem in bagItems)
            {
                priceSum += bagItem.Product.Price;
            }

            BagDTO bagDetails = new BagDTO
            {
                BagItems = bagItems.ToList(),
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

        [HttpDelete]
        public async Task<ActionResult<BagItem>> DeleteBagItem(BagItem bagItem)
        {
            try
            {
                _context.BagItems.Remove(bagItem);
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
                if (BagItemExists(bagItem.Subject, bagItem.ProductId))
                {
                    try
                    {
                        var bagItemDB = _context.BagItems.Find(bagItem.Subject, bagItem.ProductId);
                        bagItemDB.Quantity += bagItem.Quantity;
                        _context.BagItems.Update(bagItemDB);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    catch(Exception e)
                    {
                        return Conflict(e.Message);
                    }
                }
                else
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
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{subject}/{productId}")]
        public async Task<ActionResult<BagItem>> GetBagItem(string subject, int productId)
        {
            return Ok(JsonConvert.SerializeObject(await _context.Customers.FindAsync(subject, productId)));
        }

        private bool BagItemExists(string sub, int productId)
        {
            return _context.BagItems.Any(e => e.Subject == sub && e.ProductId == productId);
        }

    }
}
