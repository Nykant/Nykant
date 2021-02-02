using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }


    }
}
