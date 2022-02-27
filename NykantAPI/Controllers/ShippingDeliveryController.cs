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
    public class ShippingDeliveryController : BaseController
    {
        public ShippingDeliveryController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        public ActionResult<ShippingDelivery> GetShippingDeliveries()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(_context.ShippingDeliveries.ToList()));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }


        [HttpPost]
        public async Task<ActionResult<ShippingDelivery>> Post(ShippingDelivery shippingDelivery)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await _context.ShippingDeliveries.AddAsync(shippingDelivery);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }
    }
}
