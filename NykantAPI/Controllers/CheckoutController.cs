using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }


    }
}
