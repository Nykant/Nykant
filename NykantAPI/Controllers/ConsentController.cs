using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class ConsentController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public ConsentController(ILogger<BaseController> logger, ApplicationDbContext context, IProtectionService protectionService)
            : base(logger, context)
        {
            _protectionService = protectionService;
        }

        [HttpPost]
        public async Task<ActionResult<Consent>> Post(Consent consent)
        {
            try
            {
                consent = _protectionService.UnprotectConsent(consent);
                if (ModelState.IsValid)
                {
                    consent = _protectionService.ProtectConsent(consent);
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
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
