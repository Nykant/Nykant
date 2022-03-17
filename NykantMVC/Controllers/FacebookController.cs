using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
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
        [HttpGet("/Facebook/Post/{postId}")]
        public async Task<IActionResult> Post(string postId)
        {
            var facebookSession = HttpContext.Session.Get<FacebookSession>(FacebookSessionKey);
            if (facebookSession.Feed != null)
            {
                for(int i = 0; i < facebookSession.Feed.Posts.Count(); i++)
                {
                    if(facebookSession.Feed.Posts[i].Id == postId)
                    {
                        LikesData likesData = await FacebookGetPostLikes(facebookSession.AccessToken, postId);
                        if (likesData != null)
                        {
                            facebookSession.Feed.Posts[i].Likes = likesData.Likes;
                            HttpContext.Session.Set<FacebookSession>(FacebookSessionKey, facebookSession);
                            return View(facebookSession.Feed.Posts[i]);
                        }
                    }
                }

            }
            return View(new Post());
        }

        [Authorize(Roles = "Admin,Raffler")]
        [HttpPost]
        public async Task<IActionResult> PostAccessToken(string accessToken)
        {
            Feed feed = await FacebookGetFeed(accessToken);
            FacebookSession facebookSession = new FacebookSession
            {
                Feed = feed,
                AccessToken = accessToken
            };
            HttpContext.Session.Set<FacebookSession>(FacebookSessionKey, facebookSession);
            return View("Posts", feed.Posts);
        }

        [Authorize(Roles = "Admin,Raffler")]
        [HttpPost("/Facebook/Post/{postId}")]
        public IActionResult PickRandom(string postId)
        {
            var facebookSession = HttpContext.Session.Get<FacebookSession>(FacebookSessionKey);
            Post post = facebookSession.Feed.Posts.Find(x => x.Id == postId);
           
            if(post.Comments != null && post.Likes != null)
            {
                var random = new Random();
                var comments = post.Comments.List;
                Winner winner = new Winner();
                bool found = false;
                for(int j = 0; j < 20; j++)
                {
                    int i = random.Next(comments.Count);
                    foreach (var like in post.Likes.List)
                    {
                        if (like.Name == comments[i].From.Name)
                        {
                            found = true;
                            winner.Name = comments[i].From.Name;
                            winner.Id = comments[i].From.Id;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
                if (found)
                {
                    ViewBag.Winner = winner;
                    return new PartialViewResult
                    {
                        ViewName = "/Views/Facebook/_RandomWinnerPartial.cshtml",
                        ViewData = this.ViewData
                    };
                }
            }

            ViewBag.Winner = null;
            return new PartialViewResult
            {
                ViewName = "/Views/Facebook/_RandomWinnerPartial.cshtml",
                ViewData = this.ViewData
            };
        }
    }
}
