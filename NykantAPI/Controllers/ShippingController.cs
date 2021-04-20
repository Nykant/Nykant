using Microsoft.AspNetCore.Mvc;
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
    public class ShippingController : BaseController
    {
        public ShippingController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        //[HttpPost]
        //public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (ShippingExists(shipping.ShippingId))
        //        {
        //            _context.Shippings.Update(shipping);
        //            await _context.SaveChangesAsync();
        //            return Ok();
        //        }
        //        else
        //        {
        //            var entity = _context.Shippings.Add(shipping).Entity;
        //            await _context.SaveChangesAsync();
        //            return CreatedAtAction("GetShipping", new { id = entity.ShippingId }, shipping);
        //        }
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Shipping>> GetShipping(int id)
        //{
        //    return Ok(JsonConvert.SerializeObject(await _context.Shippings.FindAsync(id)));
        //}

        //private bool ShippingExists(int id)
        //{
        //    return _context.Shippings.Any(e => e.ShippingId  == id);
        //}
    }
}
