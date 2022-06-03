using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class RefundController : BaseController
    {
        public RefundController(ILogger<RefundController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpPost]
        public async Task<ActionResult<Refund>> PostRefund(Refund refund)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _context.Refunds.Add(refund).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetRefund", new { id = entity.Id }, entity);
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRefund(int id)
        {
            try
            {
                var refund = await _context.Refunds.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(JsonConvert.SerializeObject(refund, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }
    }
}
