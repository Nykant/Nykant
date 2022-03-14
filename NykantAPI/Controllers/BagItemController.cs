using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Extensions;
using NykantAPI.Models;
using NykantAPI.Models.DTO;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class BagItemController : BaseController
    {
        public BagItemController(ILogger<BagItemController> logger, ApplicationDbContext _context)
            : base(logger, _context)
        {

        }



[HttpGet("{subject}")]
        public async Task<ActionResult<List<BagItem>>> GetBagItems(string subject)
        {
            try
            {
                var bagItems = _context.BagItems
                    .Include(x => x.Product)
                    .Where(x => x.Subject == subject);

                var json = JsonConvert.SerializeObject(bagItems, Extensions.JsonOptions.jsonSettings);

                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<ActionResult<BagItem>> UpdateBagItem(BagItem bagItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _context.BagItems.Update(bagItem).Entity;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<ActionResult<BagItem>> AddBagItem(BagItem bagItem)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var bagitemDb = await _context.BagItems.FindAsync(bagItem.Subject, bagItem.ProductId);
                    bagitemDb.Quantity += 1;
                    _context.BagItems.Update(bagitemDb);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
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
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }

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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BagItem>> PostBagItem(BagItem bagItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!BagItemExists(bagItem.Subject, bagItem.ProductId))
                    {
                        _context.BagItems.Add(bagItem);
                        await _context.SaveChangesAsync();
                        return CreatedAtAction("GetBagItem", new { subject = bagItem.Subject, productId = bagItem.ProductId }, bagItem);
                    }
                    else
                    {
                        return await AddBagItem(bagItem);
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{subject}/{productId}")]
        public async Task<ActionResult<BagItem>> GetBagItem(string subject, int productId)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _context.BagItems.FindAsync(subject, productId)));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{subject}")]
        public async Task<ActionResult<int>> GetBagItemsQuantity(string subject)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(await _context.BagItems.Where(x => x.Subject == subject).CountAsync()));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        private bool BagItemExists(string sub, int productId)
        {
            return _context.BagItems.Any(e => e.Subject == sub && e.ProductId == productId);
        }

    }
}
