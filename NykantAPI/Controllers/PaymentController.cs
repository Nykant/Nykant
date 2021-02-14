using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.Serialization;
using NykantAPI.Data;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [ApiController]
    public class PaymentController : BaseController
    {
        public PaymentController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }


    }

}
