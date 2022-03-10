using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class FacebookController : BaseController
    {
        public FacebookController(ILogger<FacebookController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        { }

        [Authorize("Raffle Permission")]
        [HttpGet]
        public async Task<IActionResult> Raffle()
        {
            var json = await GetRequest("/Order/GetOrders");
            List<Models.Order> list = JsonConvert.DeserializeObject<List<Models.Order>>(json);
            return View(list);
        }
    }
}
