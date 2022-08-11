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
    public class ColorController : BaseController
    {
        public ColorController(ILogger<ColorController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpGet]
        public async Task<ActionResult> GetColors()
        {
            try
            {
                var colors = await _context.Colors.Include(x => x.Product).ToListAsync();
                var json = JsonConvert.SerializeObject(colors, Extensions.JsonOptions.jsonSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Color>>> PostColors(List<Color> colors)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in colors)
                    {
                        var color = await _context.Colors.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == item.ProductId && x.ProductSourceId == item.ProductSourceId);
                        if (color == default)
                        {
                            _context.Colors.Add(item);
                        }
                        else
                        {
                            item.Id = color.Id;
                            _context.Colors.Update(item);
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
