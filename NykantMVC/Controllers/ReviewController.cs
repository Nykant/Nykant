using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [Authorize]
    public class ReviewController : BaseController
    {
        public ReviewController(ILogger<BaseController> logger) : base(logger)
        {

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ContentResult> PostReview(Review review)
        {
            if (ModelState.IsValid)
            {
                var response = await PostRequest("/Review/Create", review);
                if (response.IsSuccessStatusCode)
                {
                    return Content("Thank you, your review has been submitted.");
                }
                else
                {
                    return Content("Sorry, something went wrong.");
                }
            }
            return Content("Sorry, something went wrong.");
        }

    }
}
