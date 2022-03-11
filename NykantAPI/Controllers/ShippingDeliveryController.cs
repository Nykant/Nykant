using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;
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
    public class ShippingDeliveryController : BaseController
    {
        public ShippingDeliveryController(ILogger<ShippingDeliveryController> logger, IHostingEnvironment env)
            : base(logger, env)
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }
    }
}
