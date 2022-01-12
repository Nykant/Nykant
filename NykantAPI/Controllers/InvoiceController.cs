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

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class InvoiceController : BaseController
    {
        public InvoiceController(ILogger<BaseController> logger, ApplicationDbContext context) : base(logger, context)
        { }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _context.Invoices.Add(invoice).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetInvoice", new { id = entity.Id }, entity);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("Invalid ModelState");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(JsonConvert.SerializeObject(invoice));
        }
    }
}
