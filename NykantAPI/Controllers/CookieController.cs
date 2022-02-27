using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class CookieController : BaseController
    {
        public CookieController(ILogger<BaseController> logger, ApplicationDbContext context) : base(logger, context)
        { }

        [HttpGet]
        public async Task<ActionResult> GetCookies()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(_context.Cookies));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }
    }
}
