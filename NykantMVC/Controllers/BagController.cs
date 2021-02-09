using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.DTO;

namespace NykantMVC.Controllers
{
    public class BagController : BaseController
    {

        public BagController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(SessionBagKey);

                if (bagItems == null)
                {
                    return View();
                }
                else
                {
                    BagDetailsDTO bagDetailsDTO = new BagDetailsDTO
                    {
                        BagItems = bagItems,
                    };
                    return View(bagDetailsDTO);
                }
            }

            string subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/BagItems/GetBagItems/" + subject;
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
