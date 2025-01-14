﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext _context) : base(logger, _context)
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }

        }
    }
}
