using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
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
    public class CookieController : BaseController
    {
        public CookieController(ILogger<CookieController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpGet]
        public async Task<ActionResult> GetCookies()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(_context.Cookies));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }


        }
    }
}
