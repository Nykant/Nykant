using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace NykantMVC.Controllers
{
    public class PrivacyController : BaseController
    {
        public PrivacyController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

       
    }
}
