using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantIS.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public ProfileController()
        {

        }

        public async Task<IActionResult> Profile()
        {
            var email = User.Claims.FirstOrDefault(x => x.Type == "email").Value;
            return View();
        }
    }
}
