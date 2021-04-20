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
            return Ok(JsonConvert.SerializeObject(_context.ShippingDeliveries.ToList()));
        }
    }
}
