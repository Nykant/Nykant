using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class PrivacyController : BaseController
    {
        public PrivacyController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
