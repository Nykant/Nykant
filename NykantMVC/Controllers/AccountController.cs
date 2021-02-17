﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [HttpGet]
        public IActionResult Login(string redirectUrl)
        {
            return Redirect(redirectUrl);
        }
    }
}
