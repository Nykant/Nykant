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
    public abstract partial class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        public readonly ApplicationDbContext _context;
        public readonly SignInManager<AppUser> _signInManager;
        public readonly UserManager<AppUser> _userManager;
        public BaseController(ApplicationDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<BaseController> logger)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _logger = logger;
        }

        public override ViewResult View()
        {
            ViewBag.UserId = _userManager.GetUserId(User);
            return base.View();
        }
        public override ViewResult View(object model)
        {
            ViewBag.UserId = _userManager.GetUserId(User);
            return base.View(model);
        }
        public override ViewResult View(string route, object model)
        {
            ViewBag.UserId = _userManager.GetUserId(User);
            return base.View(route, model);
        }
    }
}
