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
    public class CouponForProductController : BaseController
    {
        public CouponForProductController(ILogger<CouponForProductController> logger, ApplicationDbContext _context) : base(logger, _context)
        {

        }

        [HttpPost]
        public async Task<ActionResult<CouponForProduct>> Post(CouponForProduct couponForProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _context.CouponForProducts.Add(couponForProduct).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("Get", new { code = entity.Id }, entity);
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
        public async Task<ActionResult<CouponForProduct>> Update(CouponForProduct couponForProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.CouponForProducts.Update(couponForProduct);
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
        public async Task<ActionResult> Delete(string code)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var listToDelete = await _context.CouponForProducts.Where(x => x.CouponCode == code).ToListAsync();
                    foreach(var item in listToDelete)
                    {
                        _context.CouponForProducts.Remove(item);
                    }
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var couponForProduct = await _context.CouponForProducts.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(JsonConvert.SerializeObject(couponForProduct, Extensions.JsonOptions.jsonSettings));
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
                var couponForProducts = await _context.CouponForProducts.Where(x => x.CouponCode == code).ToListAsync();
                return Ok(JsonConvert.SerializeObject(couponForProducts, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }
    }
}
