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

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class PaymentCaptureController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public PaymentCaptureController(ILogger<PaymentCaptureController> logger, ApplicationDbContext context, IProtectionService _protectionService) : base(logger, context)
        {
            this._protectionService = _protectionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPaymentCaptures()
        {
            try
            {
                var captures = await _context.PaymentCaptures.Include(x => x.Orders).ToListAsync();
                for(int i = 0; i < captures.Count(); i++)
                {
                    captures[i] = _protectionService.UnprotectPaymentCapture(captures[i]);
                }

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
                var capture = await _context.PaymentCaptures.Include(x => x.Orders).ThenInclude(x => x.OrderItems).ThenInclude(x => x.Product).Include(x => x.Customer).ThenInclude(x => x.BillingAddress).Include(x => x.ShippingDelivery).Include(x => x.Invoice).FirstOrDefaultAsync(x => x.Id == id);
                capture = _protectionService.UnprotectPaymentCapture(capture);
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
                    _protectionService.ProtectPaymentCapture(paymentCapture);
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
                    paymentCapture = _protectionService.ProtectPaymentCapture(paymentCapture);
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
