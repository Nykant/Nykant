using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using System.Collections.Generic;
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

        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            var json = await GetRequest("/Product/GetProducts");
            var searchList = new List<Product>();
            foreach(var product in JsonConvert.DeserializeObject<List<Product>>(json))
            {
                if (product.Title.ToLower().Contains(searchString.ToLower()))
                {
                    searchList.Add(product);
                }
            }
            ViewBag.ProductList = searchList;
            return new PartialViewResult
            {
                ViewName = "_SearchPartial",
                ViewData = this.ViewData
            };
        }
    }
}
