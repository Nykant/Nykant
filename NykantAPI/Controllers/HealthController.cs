using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using System.Threading.Tasks;
using System;

namespace NykantAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class HealthController : ControllerBase
    {
        public HealthController()
        {

        }

        [HttpGet("Health")]
        public ActionResult Health()
        {
            return Ok();
        }
    }
}
