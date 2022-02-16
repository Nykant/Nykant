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
using Microsoft.AspNetCore.Localization;
using NykantMVC.Friends;
using System.Text.Encodings.Web;
using NykantMVC.Models.ViewModels;
using NykantMVC.Services;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Hosting;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IProtectionService _protectionService;
        private readonly IMailService mailService;
        private  IHostEnvironment Environment { get; set; }
        public HomeController(ILogger<HomeController> logger, IHostEnvironment _environment, IMailService _mailService, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
            _protectionService = protectionService;
            Environment = _environment;
            mailService = _mailService;
        }

        public async Task<IActionResult> Index()
        {
            var jsonResponse = await GetRequest("/Category/GetCategories");
            var categories = JsonConvert.DeserializeObject<List<Category>>(jsonResponse);

            FrontPageVM frontPageVM = new FrontPageVM()
            {
                Categories = categories
            };
            return View(frontPageVM);
        }

        public async Task<IActionResult> CookiePolicy()
        {
            var json = await GetRequest("/Cookie/GetCookies");
            var cookies = JsonConvert.DeserializeObject<List<Cookie>>(json);
            return View(cookies);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        //public IActionResult Feedback()
        //{
        //    return View();
        //}
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        public IActionResult TermsAndConditions()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> SendEmail(SimpleMail simpleMail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if(simpleMail.Body == null)
        //        {
        //            return Json("Error");
        //        }
        //        else
        //        {
        //            try
        //            {
        //                await mailService.SendEmailAsync(simpleMail);
        //                return Json("Success");
        //            }
        //            catch (Exception e)
        //            {
        //                _logger.LogInformation(e.Message);
        //                return Json("Error");
        //            }
        //        }
        //    }
        //    return Json("Error");
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateConsent(int functionalCookies, int statisticsCookies)
        //{
        //    var json = await GetRequest("/Cookie/GetCookies");
        //    var cookies = JsonConvert.DeserializeObject<List<Cookie>>(json);
        //    CookieConsent consent = new CookieConsent();

        //    switch (functionalCookies)
        //    {
        //        case 1:
        //            consent.Functional = true;
        //            break;

        //        case 0:
        //            foreach(var cookie in cookies)
        //            {
        //                if(cookie.Category == CookieCategory.Functional)
        //                {
        //                    Response.Cookies.Delete(cookie.Name);
        //                }
        //            }
        //            consent.Functional = false;
        //            break;
        //    }
        //    switch (statisticsCookies)
        //    {
        //        case 1:
        //            consent.Statistics = true;
        //            break;

        //        case 0:
        //            foreach (var cookie in cookies)
        //            {
        //                if (cookie.Category == CookieCategory.Statistics)
        //                {
        //                    Response.Cookies.Delete(cookie.Name);
        //                }
        //            }
        //            consent.Statistics = false;
        //            break;
        //    }
        //    if(functionalCookies == 1 || statisticsCookies == 1)
        //    {
        //        consent.OnlyEssential = false;
        //    }
        //    else
        //    {
        //        consent.OnlyEssential = true;
        //    }
        //    consent.ShowBanner = false;
            
        //    HttpContext.Session.Set<CookieConsent>(ConsentCookieKey, consent);

        //    ViewBag.Functional = consent.Functional;
        //    ViewBag.Statistics = consent.Statistics;
        //    return new PartialViewResult
        //    {
        //        ViewName = "_CookieSettingsPartial",
        //        ViewData = this.ViewData
        //    };
        //}

        [HttpPost]
        public async Task<IActionResult> AllowAllConsent()
        {
            var clientIP = Request.HttpContext.Connection.RemoteIpAddress;
            Consent consent = new Consent
            {
                IPAddress = clientIP.ToString(),
                Date = DateTime.Now,
                ButtonText = "Accepter Alle",
                ConsentText = "Vi bruger cookies til forbedring af din oplevelse, og essentielle funktioner, samt sender statistiske data til google analytics om hvad vores brugere foretager sig på hjemmesiden, i den hensigt at kunne forbedre den. Trykker du Accepter Alle, giver du dit samtykke til vores brug af disse. (link(her kan du læse mere om vores cookies))",
                How = ConsentHow.Button,
                Type = ConsentType.Cookie,
                Status = ConsentStatus.Given
            };
            consent = _protectionService.ProtectConsent(consent);
            PostRequest("/Consent/Post", consent).ConfigureAwait(false);

            var cookieConsent = new CookieConsent
            {
                OnlyEssential = false,
                ShowBanner = false,
                NonEssential = true
            };
            HttpContext.Session.Set<CookieConsent>(ConsentCookieKey, cookieConsent);

            //ViewBag.NonEssential = cookieConsent.NonEssential;
            //return new PartialViewResult
            //{
            //    ViewName = "_CookieSettingsPartial",
            //    ViewData = this.ViewData
            //};

            return NoContent();
        }

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }

        [HttpPost]
        public async Task<IActionResult> OnlyEssentialConsent()
        {
            var clientIP = Request.HttpContext.Connection.RemoteIpAddress;
            Consent consent = new Consent
            {
                IPAddress = clientIP.ToString(),
                Date = DateTime.Now,
                ButtonText = "Kun Nødvendige",
                ConsentText = "Vi bruger cookies til forbedring af din oplevelse, og essentielle funktioner, samt sender statistiske data til google analytics om hvad vores brugere foretager sig på hjemmesiden, i den hensigt at kunne forbedre den. Trykker du Accepter Alle, giver du dit samtykke til vores brug af disse. (link(her kan du læse mere om vores cookies))",
                How = ConsentHow.Button,
                Type = ConsentType.Cookie,
                Status = ConsentStatus.Retrieved
            };
            consent = _protectionService.ProtectConsent(consent);
            PostRequest("/Consent/Post", consent).ConfigureAwait(false);

            var jsonCookies = await GetRequest("/Cookie/GetCookies");
            var cookies = JsonConvert.DeserializeObject<List<Cookie>>(jsonCookies);
            foreach (var cookie in cookies)
            {
                if (cookie.Category == CookieCategory.Functional || cookie.Category == CookieCategory.Statistics)
                {
                    Response.Cookies.Delete(cookie.Name);
                }
            }

            var cookieConsent = new CookieConsent
            {
                OnlyEssential = true,
                ShowBanner = false,
                NonEssential = false
            };
            HttpContext.Session.Set<CookieConsent>(ConsentCookieKey, cookieConsent);

            //ViewBag.NonEssential = cookieConsent.NonEssential;
            //return new PartialViewResult
            //{
            //    ViewName = "_CookieSettingsPartial",
            //    ViewData = this.ViewData
            //};
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            if (ModelState.IsValid)
            {
                if (searchString != null)
                {
                    var json = await GetRequest("/Product/GetProducts");
                    var searchList = new List<Product>();
                    foreach (var product in JsonConvert.DeserializeObject<List<Product>>(json))
                    {
                        if (product.Description.ToLower().Contains(searchString.ToLower()) || product.Category.Name.ToLower().Contains(searchString.ToLower()))
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
            else
            {
                return null;
            }
        }

        [HttpPost]
        public IActionResult UpdateCulture(string culture, string redirectController, string redirectAction)
        {
            if(culture == "Dansk")
            {
                culture = "da-DK";
            }
            else
            {
                culture = "en-GB";
            }

            try
            {
                if (Environment.IsDevelopment())
                {
                    Response.Cookies.Append(
                        "Culture",
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture)),
                            new CookieOptions
                            {
                                Expires = DateTimeOffset.UtcNow.AddYears(1),
                                SameSite = SameSiteMode.Lax,
                                IsEssential = true,
                                HttpOnly = true,
                                Secure = true,
                                Domain = "localhost"

                            });
                }
                else
                {
                    Response.Cookies.Append(
                        "Culture",
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture, culture)),
                            new CookieOptions
                            {
                                Expires = DateTimeOffset.UtcNow.AddYears(1),
                                SameSite = SameSiteMode.Lax,
                                IsEssential = true,
                                HttpOnly = true,
                                Secure = true,
                                Domain = ".nykant.dk"

                            });
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
            }

            return RedirectToAction(redirectAction, redirectController);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewsSub(string email)
        {
            try
            {
                NewsSub newsSub = new NewsSub { Email = email };
                Consent consent = new Consent
                {
                    Email = email,
                    Date = DateTime.Now,
                    ButtonText = "Tilmeld",
                    ConsentText = "Når du trykke tilmeld, abonnerer du på nykants nyhedsbreve. For at afmelde igen, tryk afmeld, i en nyhedsemail.",
                    How = ConsentHow.Button,
                    Type = ConsentType.Newsletter,
                    Status = ConsentStatus.Given
                };
                consent = _protectionService.ProtectConsent(consent);
                PostRequest("/Consent/Post", consent).ConfigureAwait(false);
                //if (!consentResponse.IsSuccessStatusCode)
                //{
                //    _logger.LogInformation($"{consentResponse.ReasonPhrase} - {consentResponse.StatusCode}");
                //    return Json("Error");
                //}

                newsSub = _protectionService.ProtectNewsSub(newsSub);
                var newsResponse = await PostRequest("/NewsSub/Post", newsSub);
                if (!newsResponse.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"{newsResponse.ReasonPhrase} - {newsResponse.StatusCode}");
                    return Json("Error");
                }

                return Json("Success");
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                return Json("Error");
            }
        }
    }
}
