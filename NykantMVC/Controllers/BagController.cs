using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NykantMVC.Models;
using NykantMVC.Models.DTO;

namespace NykantMVC.Controllers
{
    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Details(string subject)
        {
            if (subject == null)
            {
                return NotFound();
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Bag/Details/" + subject;
            var result = await client.GetStringAsync(uri);

            BagDetailsDTO bagd = JsonConvert.DeserializeObject<BagDetailsDTO>(result);

            if (bagd == null)
            {
                return NotFound();
            }
            return View(bagd);
        }
    }
}
