using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {

        }

        [HttpGet]
        public IActionResult Logout()
        {
            int bagItemsCount = 0;
            if (HttpContext.Session.Get<List<BagItem>>(BagSessionKey) != null)
            {
                bagItemsCount = HttpContext.Session.Get<List<BagItem>>(BagSessionKey).Count();
            }
            HttpContext.Session.Set<int>(BagItemAmountKey, bagItemsCount);
            return SignOut("Cookies", "oidc");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string redirectaction = null, string redirectcontroller = null)
        {
            var json = await GetRequest($"/BagItem/GetBagItemsQuantity/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}");
            int bagItemsQuantity = JsonConvert.DeserializeObject<int>(json);
            HttpContext.Session.Set<int>(BagItemAmountKey, bagItemsQuantity);

            if(redirectaction == null || redirectcontroller == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction(redirectaction, redirectcontroller);
        }
    }
}
