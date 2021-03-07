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
            if (User.Identity.IsAuthenticated)
            {
                string subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                var json = await GetRequest($"/BagItem/GetBagItems/{subject}");
                List<BagItem> bagItems = JsonConvert.DeserializeObject<List<BagItem>>(json);

                ViewBag.PriceSum = CalculateAmount(bagItems);

                return View(bagItems);
            }
            else
            {
                var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                if (bagItems == null)
                {

                    bagItems = new List<BagItem>();

                    ViewBag.PriceSum = CalculateAmount(bagItems);
                    return View(bagItems);
                }
                else
                {
                    int priceSum = 0;
                    foreach (var bagItem in bagItems)
                    {
                        priceSum += bagItem.Product.Price;
                    }

                    ViewBag.PriceSum = CalculateAmount(bagItems);
                    return View(bagItems);
                }
            }
        }

        private int CalculateAmount(List<BagItem> items)
        {
            int price = 0;
            foreach (var item in items)
            {
                for(int i = 0; i < item.Quantity; i++)
                    price += item.Product.Price;
            }
            return price;
        }
    }
}
