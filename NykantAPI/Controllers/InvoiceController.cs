using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NykantAPI.Services;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class InvoiceController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public InvoiceController(ILogger<InvoiceController> logger, ApplicationDbContext context, IProtectionService protectionService) : base(logger, context)
        { _protectionService = protectionService; }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _context.Invoices.Add(invoice).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetInvoice", new { id = entity.Id }, entity);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            try
            {
                var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(JsonConvert.SerializeObject(invoice));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }


        }
    }
}
