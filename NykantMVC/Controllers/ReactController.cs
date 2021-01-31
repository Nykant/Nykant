using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult Tutorial()
        {
            return View();
        }
    }
}
