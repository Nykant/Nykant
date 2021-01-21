using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantApp.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<HomeController> logger) : base(signInManager, userManager, logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
