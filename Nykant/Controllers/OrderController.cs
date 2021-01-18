using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nykant.Areas.Identity.Data;
using Nykant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<HomeController> logger) : base(context, signInManager, userManager, logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
