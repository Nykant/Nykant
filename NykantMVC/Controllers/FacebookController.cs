using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FacebookController : BaseController
    {
        public FacebookController(ILogger<FacebookController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        { }

        [Authorize(Roles = "Admin,Raffler")]
        [HttpGet]
        public IActionResult Posts()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Raffler")]
        [HttpGet]
        public IActionResult Post(Post post)
        {
            return View(post);
        }

        [Authorize(Roles = "Admin,Raffler")]
        [HttpPost]
        public async Task<IActionResult> PostAccessToken(string accessToken)
        {
            Feed feed = await FacebookGetFeed(accessToken);
            return View("Posts", feed.Posts);
        }

        [Authorize(Roles = "Admin,Raffler")]
        [HttpPost]
        public IActionResult PickRandom(List<Comment> comments)
        {
            var random = new Random();
            int i = random.Next(comments.Count);

            ViewBag.Winner = comments[i];
            return new PartialViewResult
            {
                ViewName = "/Views/Facebook/_RandomWinnerPartial.cshtml",
                ViewData = this.ViewData
            };
        }
    }
}
