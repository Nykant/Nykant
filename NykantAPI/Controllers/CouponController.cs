using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class CouponController : BaseController
    {
        public CouponController(ILogger<CouponController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpPost]
        public async Task<ActionResult<Coupon>> Post(Coupon coupon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _context.Coupons.Add(coupon).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("Get", new { code = entity.Code }, entity);
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
        public async Task<ActionResult<Coupon>> Update(Coupon coupon)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Coupons.Update(coupon);
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

        [HttpDelete("{code}")]
        public async Task<ActionResult<Coupon>> Delete(string code)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Coupons.Remove(await _context.Coupons.FindAsync(code));
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

        [HttpGet("{code}")]
        public async Task<ActionResult> Get(string code)
        {
            try
            {
                var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Code == code);
                return Ok(JsonConvert.SerializeObject(coupon, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var coupons = await _context.Coupons.ToListAsync();
                return Ok(JsonConvert.SerializeObject(coupons, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }
    }
}
