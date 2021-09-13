using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NykantMVC.Extensions;
using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class NykantController : BaseController
    {
        //private readonly IStringLocalizer<NykantController> localizer;
        public NykantController(ILogger<NykantController> logger, IOptions<Urls> urls/*, IStringLocalizer<NykantController> localizer*/) : base(logger, urls)
        {
            //this.localizer = localizer;
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
            //ViewData["PrivacyPolicyTitle"] = localizer["PrivacyPolicyTitle"];
            return View();
        }
        public IActionResult TermsAndConditions()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConsent(int functionalCookies)
        {
            Consent consent = new Consent();
            switch (functionalCookies)
            {
                case 1:
                    consent.Functional = true;
                    consent.OnlyEssential = false;
                    consent.ShowBanner = false;
                    break;

                case 0:
                    consent.Functional = false;
                    consent.OnlyEssential = true;
                    consent.ShowBanner = false;
                    break;
            }
            
            HttpContext.Session.Set<Consent>(ConsentCookieKey, consent);

            ViewBag.ShowBanner = consent.OnlyEssential;
            ViewBag.OnlyEssential = consent.ShowBanner;
            ViewBag.Functional = consent.Functional;

            return new PartialViewResult
            {
                ViewName = "_CookieSettingsPartial",
                ViewData = this.ViewData
            };
        }

        [HttpPost]
        public IActionResult AllowAllConsent()
        {
            var consent = new Consent
            {
                OnlyEssential = false,
                ShowBanner = false,
                Functional = true
            };
            HttpContext.Session.Set<Consent>(ConsentCookieKey, consent);

            ViewBag.ShowBanner = consent.OnlyEssential;
            ViewBag.OnlyEssential = consent.ShowBanner;
            ViewBag.Functional = consent.Functional;

            return new PartialViewResult
            {
                ViewName = "_CookieSettingsPartial",
                ViewData = this.ViewData
            };
        }

        [HttpPost]
        public async Task<IActionResult> OnlyEssentialConsent()
        {

            var consent = new Consent
            {
                OnlyEssential = true,
                ShowBanner = false,
                Functional = false
            };
            HttpContext.Session.Set<Consent>(ConsentCookieKey, consent);

            ViewBag.ShowBanner = consent.OnlyEssential;
            ViewBag.OnlyEssential = consent.ShowBanner;
            ViewBag.Functional = consent.Functional;

            return new PartialViewResult
            {
                ViewName = "_CookieSettingsPartial",
                ViewData = this.ViewData
            };
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            if(searchString != null)
            {
                var json = await GetRequest("/Product/GetProducts");
                var searchList = new List<Product>();
                foreach (var product in JsonConvert.DeserializeObject<List<Product>>(json))
                {
                    if (product.Title.ToLower().Contains(searchString.ToLower()))
                    {
                        searchList.Add(product);
                    }
                }
                ViewBag.SearchProductList = searchList;
            }
            else
            {
                ViewBag.SearchProductList = new List<Product>();
            }
            
            return new PartialViewResult
            {
                ViewName = "_SearchPartial",
                ViewData = this.ViewData
            };
        }
    }
}
