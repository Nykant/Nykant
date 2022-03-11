using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    public abstract partial class BaseController : ControllerBase
    {
        public const string BagSessionKey = "verysecretbagsessionkey";
        public const string CheckoutSessionKey = "verysecretseriouscheckoutsessionkey";
        public const string BagItemAmountKey = "verysecretseriouscheckoutsessionkeyspecial";
        public readonly ILogger<BaseController> _logger;
        public readonly IHostingEnvironment env;
        public BaseController(ILogger<BaseController> logger, IHostingEnvironment env)
        {

            _logger = logger;
            this.env = env;
        }
    }
}
