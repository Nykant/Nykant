using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class PrivacyController : BaseController
    {
        public PrivacyController(ILogger<BaseController> logger, IOptions<Urls> urls) : base(logger, urls)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
