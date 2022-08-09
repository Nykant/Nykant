using Google.Apis.ShoppingContent.v2_1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.JsonModels;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;
using DateTime = System.DateTime;
using Google.Apis.ShoppingContent.v2_1;
using Google.Apis.Services;
using Google;
using Google.Apis.Auth;
using Google.Apis.Http;
using Google.Apis.Requests;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IGoogleApiService googleApiService;
        public AccountController(ILogger<AccountController> logger, IOptions<Urls> urls, IGoogleApiService googleApiService, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
            this.googleApiService = googleApiService;
        }

        [HttpGet]

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GoogleSignIn()
        {
            try
            {
                var mvc = _urls.Mvc;
                var uri = $"https://accounts.google.com/o/oauth2/v2/auth?client_id=343993388893-k059du29n273jacmdp5qno97es2k8jpl.apps.googleusercontent.com&redirect_uri=" + $"{mvc}/account/googlegetaccesstoken&response_type=code&scope=https://www.googleapis.com/auth/content";
                return Redirect(uri);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Content("error");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GoogleGetAccessToken(string code = null)
        {
            try
            {
                var mvc = _urls.Mvc;
                var flow = new Google.Apis.Auth.OAuth2.Flows.GoogleAuthorizationCodeFlow(new Google.Apis.Auth.OAuth2.Flows.GoogleAuthorizationCodeFlow.Initializer { ClientSecrets = new Google.Apis.Auth.OAuth2.ClientSecrets { ClientId = "343993388893-k059du29n273jacmdp5qno97es2k8jpl.apps.googleusercontent.com", ClientSecret = "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" }, IncludeGrantedScopes = true, Scopes = new List<string> { "https://www.googleapis.com/auth/content" } });
                var res = await flow.ExchangeCodeForTokenAsync("nykant-358409", code, $"{mvc}/account/googlegetaccesstoken", new System.Threading.CancellationToken());

                googleApiService.SetTokens(res.AccessToken);
                return Redirect("/");
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return Content("error");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task GoogleAccessToken()
        {
            try
            {
                var t = "";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");

            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                int bagItemsCount = 0;
                if (HttpContext.Session.Get<List<BagItem>>(BagSessionKey) != null)
                {
                    bagItemsCount = HttpContext.Session.Get<List<BagItem>>(BagSessionKey).Count();
                }
                HttpContext.Session.Set<int>(BagItemAmountKey, bagItemsCount);
                return SignOut("Cookies", "oidc");

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Login(string redirectaction = null, string redirectcontroller = null)
        {
            try
            {
                var json = await GetRequest($"/BagItem/GetBagItemsQuantity/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
                int bagItemsQuantity = JsonConvert.DeserializeObject<int>(json);
                HttpContext.Session.Set<int>(BagItemAmountKey, bagItemsQuantity);

                if (redirectaction == null || redirectcontroller == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction(redirectaction, redirectcontroller);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
            
        }
    }
}
