using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;

namespace NykantMVC.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(ILogger<BaseController> logger, IOptions<Urls> urls) : base(logger, urls)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
