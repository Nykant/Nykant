using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BagItemController : BaseController
    {
        public BagItemController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpGet("api/{controller}/{action}/{subject}")]
        public ActionResult<BagDetailsDTO> GetBagItems(string subject)
        {
            var subjectTest = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
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

        [HttpPatch("api/{controller}/{action}/{productId}/{subject}/{productQuantity}")]
        public async Task<ActionResult<BagItem>> UpdateBagItem(int productId, string subject, int productQuantity)
        {
            if(BagItemExists(subject, productId))
            {
                var bagItem = await _context.BagItems.FirstOrDefaultAsync(x => x.Subject == subject && x.ProductId == productId);

                try
                {
                    bagItem.Quantity = productQuantity;
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

        [HttpPost("api/{controller}/{action}/{productId}/{sub}/{productQuantity}")]
        public async Task<ActionResult<BagItem>> PostBagItem(int productId, string sub, int productQuantity)
        {
            if (BagItemExists(sub, productId))
            {
                var bagItem = await _context.BagItems.FirstOrDefaultAsync(x => x.Subject == sub && x.ProductId == productId);
                bagItem.Quantity += productQuantity;
                _context.BagItems.Update(bagItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                try
                {
                    var bagItem = new BagItem { ProductId = productId, Subject = sub, Quantity = productQuantity };
                    await _context.BagItems.AddAsync(bagItem);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception e)
                {
                    return Conflict(e.Message);
                }
            }
        }

        //[HttpDelete("api/{controller}/{action}/{productId}/{bagId}")]
        //public async Task<IActionResult> DeleteBagItem(int productId, string sub)
        //{
        //    var bagItem = await _context.BagItems.FindAsync(sub, productId);

        //    _context.BagItems.Remove(bagItem);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    return Ok();
        //}

        private bool BagItemExists(string sub, int productId)
        {
            return _context.BagItems.Any(e => e.Subject == sub && e.ProductId == productId);
        }

    }
}
