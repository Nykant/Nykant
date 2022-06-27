using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Configuration;
using NykantMVC.Services;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class PrivacyController : BaseController
    {
        public PrivacyController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


    }
}
