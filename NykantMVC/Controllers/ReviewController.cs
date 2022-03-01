using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class ReviewController : BaseController
    {
        public ReviewController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
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
