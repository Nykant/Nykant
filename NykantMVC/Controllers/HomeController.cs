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
    public class HomeController : BaseController
    {
        private readonly IProtectionService _protectionService;
        private readonly IMailService mailService;
        private  IHostEnvironment Environment { get; set; }
        public HomeController(ILogger<HomeController> logger, IHostEnvironment _environment, IMailService _mailService, IProtectionService protectionService, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
            _protectionService = protectionService;
            Environment = _environment;
            mailService = _mailService;
        }

        [Authorize(Roles = "Admin,Raffler")]
        public IActionResult Claims()
        {
            return View();
        }

        //[Route("Hjem")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var jsonResponse = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonResponse);
                jsonResponse = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);
                var viewModel = new FrontPageVM()
                {
                    Categories = categories,
                    Products = products
                };
                return View(viewModel);
            }
            catch (Exception e) {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
            }
            return View(new List<Category>());
        }

        [Route("Cookiepolitik")]
        public async Task<IActionResult> CookiePolicy()
        {
            var json = await GetRequest("/Cookie/GetCookies");
            var cookies = JsonConvert.DeserializeObject<List<Cookie>>(json);
            return View(cookies);
        }

        [Route("Kontakt")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet("Om-Os")]
        //[Route("Om-Os")]
        public IActionResult About()
        {
            return View();
        }

        [Route("Handlevejledning")]
        public IActionResult HowToOrder()
        {
            return View();
        }
        //public IActionResult Feedback()
        //{
        //    return View();
        //}

        [Route("Persondatapolitik")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("Handelsbetingelser")]
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

        //[HttpPost]
        //public async Task AllowAllConsent()
        //{
        //    try
        //    {
        //        var clientIP = Request.HttpContext.Connection.RemoteIpAddress;
        //        Consent consent = new Consent
        //        {
        //            IPAddress = clientIP.ToString(),
        //            Date = DateTime.Now,
        //            ButtonText = "Accepter",
        //            ConsentText = "Vi bruger google analytics cookies til at indsamle anonyme data om dig, så vi kan se hvad du foretager dig på hjemmesiden, for at forbedre den. (link til cookie politik:(her kan du læse mere om vores cookies)). Trykker du Accepter, giver du dit samtykke til at vi må bruge google analytics.",
        //            How = ConsentHow.Button,
        //            Type = ConsentType.Cookie,
        //            Status = ConsentStatus.Given
        //        };

        //        PostRequest("/Consent/Post", consent).ConfigureAwait(false);

        //        var cookieConsent = new CookieConsent
        //        {
        //            OnlyEssential = false,
        //            ShowBanner = false,
        //            NonEssential = true
        //        };
        //        HttpContext.Session.Set<CookieConsent>(ConsentCookieKey, cookieConsent);

        //        //ViewBag.NonEssential = cookieConsent.NonEssential;
        //        //return new PartialViewResult
        //        //{
        //        //    ViewName = "_CookieSettingsPartial",
        //        //    ViewData = this.ViewData
        //        //};
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError($"consent error - time: {DateTime.Now} - {e.Message}");
        //    }
        //}

        [HttpPost]
        public void Log(string message)
        {
            _logger.LogError(message);
        }

        //[HttpPost]
        //public async Task OnlyEssentialConsent()
        //{
        //    try
        //    {
        //        var clientIP = Request.HttpContext.Connection.RemoteIpAddress;
        //        Consent consent = new Consent
        //        {
        //            IPAddress = clientIP.ToString(),
        //            Date = DateTime.Now,
        //            ButtonText = "Afvis",
        //            ConsentText = "Vi bruger google analytics cookies til at indsamle anonyme data om dig, så vi kan se hvad du foretager dig på hjemmesiden, for at forbedre den. (link til cookie politik:(her kan du læse mere om vores cookies)). Trykker du Accepter, giver du dit samtykke til at vi må bruge google analytics.",
        //            How = ConsentHow.Button,
        //            Type = ConsentType.Cookie,
        //            Status = ConsentStatus.Retrieved
        //        };

        //        PostRequest("/Consent/Post", consent).ConfigureAwait(false);

        //        var jsonCookies = await GetRequest("/Cookie/GetCookies");
        //        var cookies = JsonConvert.DeserializeObject<List<Cookie>>(jsonCookies);
        //        foreach (var cookie in cookies)
        //        {
        //            if (cookie.Category == CookieCategory.Functional || cookie.Category == CookieCategory.Statistics)
        //            {
        //                Response.Cookies.Delete(cookie.Name);
        //            }
        //        }

        //        var cookieConsent = new CookieConsent
        //        {
        //            OnlyEssential = true,
        //            ShowBanner = false,
        //            NonEssential = false
        //        };
        //        HttpContext.Session.Set<CookieConsent>(ConsentCookieKey, cookieConsent);

        //        //ViewBag.NonEssential = cookieConsent.NonEssential;
        //        //return new PartialViewResult
        //        //{
        //        //    ViewName = "_CookieSettingsPartial",
        //        //    ViewData = this.ViewData
        //        //};
                
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError($"consent error - time: {DateTime.Now} - {e.Message}");
        //    }
        //}

        [HttpPost]
        public IActionResult UpdateCulture(string culture, string redirectController, string redirectAction)
        {
            try
            {
                if (culture == "Dansk")
                {
                    culture = "da-DK";
                }
                else
                {
                    culture = "en-GB";
                }
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
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
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

                PostRequest("/Consent/Post", consent).ConfigureAwait(false);
                //if (!consentResponse.IsSuccessStatusCode)
                //{
                //    _logger.LogInformation($"{consentResponse.ReasonPhrase} - {consentResponse.StatusCode}");
                //    return Json("Error");
                //}

                var newsResponse = await PostRequest("/NewsSub/Post", newsSub);
                if (!newsResponse.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - {newsResponse.ReasonPhrase} - {newsResponse.StatusCode}");
                    return Json("Error");
                }

                return Json("Success");
            }
            catch(Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return Json("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegretFormular(Regret regret)
        {
            try
            {
                await mailService.SendRegretEmailAsync(regret);

                return Json("Success");
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return Json("Error");
            }
        }
    }
}
