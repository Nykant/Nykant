using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NykantMVC.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(ILogger<BaseController> logger) : base(logger)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
