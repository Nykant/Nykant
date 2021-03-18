using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantMVC.Models;
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
        public async Task<IActionResult> PostReview(Review review)
        {
            if (ModelState.IsValid)
            {
                var response = await PostRequest("/Review/Create", review);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Details", "Product", new { id = review.ProductId, reviewSent = true });
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
