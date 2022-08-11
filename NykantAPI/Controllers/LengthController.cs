using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NykantAPI.Models;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class LengthController : BaseController
    {
        public LengthController(ILogger<LengthController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpGet]
        public async Task<ActionResult> GetLengths()
        {
            try
            {
                var lengths = await _context.Lengths.Include(x => x.Product).ToListAsync();
                var json = JsonConvert.SerializeObject(lengths, Extensions.JsonOptions.jsonSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<ProductLength>>> PostLengths(List<ProductLength> lengths)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in lengths)
                    {
                        var length = await _context.Lengths.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == item.ProductId && x.ProductReferenceId == item.ProductReferenceId);
                        if (length == default)
                        {
                            _context.Lengths.Add(item);
                        }
                        else
                        {
                            item.Id = length.Id;
                            _context.Lengths.Update(item);
                        }
                    }

                    await _context.SaveChangesAsync();
                    return Accepted();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }
    }
}
