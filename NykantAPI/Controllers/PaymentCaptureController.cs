using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
    public class PaymentCaptureController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public PaymentCaptureController(ILogger<PaymentCaptureController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpGet]
        public async Task<ActionResult> GetPaymentCaptures()
        {
            try
            {
                var captures = await _context.PaymentCaptures.Include(x => x.Order).ToListAsync();

                return Ok(JsonConvert.SerializeObject(captures, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPaymentCapture(int id)
        {
            try
            {
                var capture = await _context.PaymentCaptures.Include(x => x.Order).ThenInclude(x => x.OrderItems).ThenInclude(x => x.Product).Include(x => x.Customer).ThenInclude(x => x.BillingAddress).Include(x => x.Invoice).Include(x => x.Refund).FirstOrDefaultAsync(x => x.Id == id);
                return Ok(JsonConvert.SerializeObject(capture, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<ActionResult<PaymentCapture>> PostPaymentCapture(PaymentCapture paymentCapture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _context.PaymentCaptures.Add(paymentCapture).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetPaymentCapture", new { id = entity.Id }, entity);
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

        [HttpPatch]
        public async Task<ActionResult<PaymentCapture>> UpdatePaymentCapture(PaymentCapture paymentCapture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.PaymentCaptures.Update(paymentCapture);
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
