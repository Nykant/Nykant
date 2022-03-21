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
                        facebookSession.Feed.Posts[i].Winner = new Winner
                        {
                            Name = "",
                            Id = ""
                        };
                        LikesData likesData = await FacebookGetPostLikes(facebookSession.AccessToken, postId);
                        facebookSession.Feed.Posts[i].LikesData = likesData;
                        likesData.Likes.List.Add(new Like { CreatedTime = DateTime.Now.ToString(), Id = "123", Name = "Test Name" });
                        likesData.Likes.List.Add(new Like { CreatedTime = DateTime.Now.ToString(), Id = "124", Name = "Test Name1" });
                        likesData.Likes.List.Add(new Like { CreatedTime = DateTime.Now.ToString(), Id = "125", Name = "Test Name2" });
                        facebookSession.Feed.Posts[i].Comments = new Comments
                        {
                            List = new List<Comment>
                             {
                                 new Comment { Id = "234", From = new From { Id = "321", Name = "Test Name" }, CreatedTime = DateTime.Now.ToString() },
                                 new Comment { Id = "235", From = new From { Id = "322", Name = "Test Name1" }, CreatedTime = DateTime.Now.ToString() }
                             }
                        };
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
            return View("Posts", feed);
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
                bool found = false;
                for(int j = 0; j < 20; j++)
                {
                    int i = random.Next(comments.Count);
                    foreach (var like in post.Likes.List)
                    {
                        if (like.Name == comments[i].From.Name)
                        {
                            found = true;
                            post.Winner.Name = comments[i].From.Name;
                            post.Winner.Id = comments[i].From.Id;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
            }

            return View("Post", post);
        }
    }
}
