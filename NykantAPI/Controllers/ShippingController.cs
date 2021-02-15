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

        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Shippings.Add(shipping).Entity;
                await _context.SaveChangesAsync();
                return Ok(JsonConvert.SerializeObject(entity));
            }
            return NotFound();
        }
    }
}
