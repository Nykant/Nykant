using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {

        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CookiePolicy()
        {
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        public IActionResult TermsAndConditions()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConsent(int consent)
        {
            if (consent == 0)
            {
                var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
                consentFeature.WithdrawConsent();
                return NoContent();
            }
            else
            {
                var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
                consentFeature.GrantConsent();
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AllowAllConsent()
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            consentFeature.GrantConsent();
            return Content("Du har givet os tilladelse til at bruge alle cookies.");
        }

        [HttpPost]
        public async Task<IActionResult> AllowNoneConsent()
        {
            var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
            consentFeature.WithdrawConsent();
            return Content("Du har fravalgt brugen af alle cookies, og cookies du før havde tilladt, er blevet slettet.");
        }
    }
}
