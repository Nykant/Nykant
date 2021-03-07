using IdentityModel.Client;
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
        public readonly ApplicationDbContext _context;
        public readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger, ApplicationDbContext context)
        {

            _logger = logger;
            _context = context;
        }
    }
}
