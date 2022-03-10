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

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class ConsentController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public ConsentController(ILogger<ConsentController> logger, ApplicationDbContext context, IProtectionService protectionService)
            : base(logger, context)
        {
            _protectionService = protectionService;
        }

        [HttpPost]
        public async Task<ActionResult<Consent>> Post(Consent consent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Consents.Add(consent);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }
    }
}
