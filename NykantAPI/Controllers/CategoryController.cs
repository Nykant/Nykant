using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class CategoryController : BaseController
    {
        public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext context) : base(logger, context)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(_context.Categories));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }

        }
    }
}
