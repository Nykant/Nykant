using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderItemController : BaseController
    {
        public OrderItemController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }
    }
}
