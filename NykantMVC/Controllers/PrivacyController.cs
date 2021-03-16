using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class PrivacyController : BaseController
    {
        public PrivacyController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
