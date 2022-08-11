using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class ImageController : BaseController
    {
        public ImageController(ILogger<ImageController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpGet]
        public async Task<ActionResult> GetImages()
        {
            try
            {
                var images = await _context.Images.Include(x => x.Product).ToListAsync();
                var json = JsonConvert.SerializeObject(images, Extensions.JsonOptions.jsonSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Image>>> PostImages(List<Image> images)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach(var item in images)
                    {
                        var img = await _context.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Source == item.Source);
                        if(img == default)
                        {
                            _context.Images.Add(item);
                        }
                        else
                        {
                            item.Id = img.Id;
                            _context.Images.Update(item);
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
