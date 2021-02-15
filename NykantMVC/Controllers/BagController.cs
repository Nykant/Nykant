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
using NykantMVC.Models.ViewModels;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

                if (bagItems == null)
                {
                    BagVM bagVM = new BagVM
                    {
                        BagItems = new List<BagItem>()
                    };
                    return View(bagVM);
                }
                else
                {
                    int priceSum = 0;
                    foreach (var bagItem in bagItems)
                    {
                        priceSum += bagItem.Product.Price;
                    }
                    BagVM bagVM = new BagVM
                    {
                        BagItems = bagItems,
                        PriceSum = priceSum
                    };
                    return View(bagVM);
                }
            }

            string subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            var json = await GetRequest($"BagItem/GetBagItems/{subject}");

            BagVM bogVM = JsonConvert.DeserializeObject<BagVM>(json);

            return View(bogVM);
        }
    }
}
