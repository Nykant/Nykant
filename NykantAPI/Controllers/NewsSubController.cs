using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class NewsSubController : BaseController
    {

        public NewsSubController(ILogger<NewsSubController> logger, ApplicationDbContext _context)
            : base(logger, _context)
        {

        }

        [HttpPost]
        public async Task<ActionResult<NewsSub>> Post(NewsSub newsSub)
        {
            NewsSub sub = newsSub;
            try
            {
                if (ModelState.IsValid)
                {
                    if (!NewsSubExist(newsSub.Email))
                    {
                        _context.NewsSubs.Add(sub);
                        await _context.SaveChangesAsync();
                    }
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return NotFound(e.Message); 
            }
        }

        private bool NewsSubExist(string email)
        {
            var exists = _context.NewsSubs.Find(email);
            if(exists == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
