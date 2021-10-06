using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using System.Text.Encodings.Web;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ContactController : BaseController
    {
        public ContactController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
