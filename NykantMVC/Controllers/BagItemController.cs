using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class BagItemController : BaseController
    {

        public BagItemController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> UpdateBagItem(int productId, string sub, int productQuantity, int selection)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            BagItem bagItem = new BagItem
            {
                Subject = sub,
                ProductId = productId,
                Quantity = productQuantity
            };

            if (selection == 1)
            {
                bagItem.Quantity += 1;
            }
            else if (selection == 2)
            {
                bagItem.Quantity -= 1;
            }

            var bagItemJson = new StringContent(
                JsonConvert.SerializeObject(bagItem),
                Encoding.UTF8,
                "application/json");

            string uri = "https://localhost:6001/api/BagItem/UpdateBagItem/" + productId + "/" + sub + "/" + bagItem.Quantity;
            var content = await client.PatchAsync(uri, bagItemJson);

            if (content.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Bag");
            }
            return Content("Failed");
        }

        public async Task<IActionResult> AddBagItem(ProductVM productVM, int productQuantity)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            BagItem bagItem = new BagItem
            {
                ProductId = productVM.Product.Id,
                Quantity = productQuantity
            };

            if (!isAuthenticated)
            {
                try
                {
                    List<BagItem> bagItems = null;
                    if (HttpContext.Session.Get<List<BagItem>>(SessionBagKey) == default)
                    {
                        bagItems = new List<BagItem>();
                    }
                    else
                    {
                        bagItems = HttpContext.Session.Get<List<BagItem>>(SessionBagKey);
                    }
                    bagItems.Add(bagItem);
                    HttpContext.Session.Set<List<BagItem>>(SessionBagKey, bagItems);
                    return NoContent();
                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }
            }

            var sub = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            bagItem.Subject = sub;

            var bagItemJson = new StringContent(
                JsonConvert.SerializeObject(bagItem),
                Encoding.UTF8,
                "application/json");

            string uri = "https://localhost:6001/api/BagItem/PostBagItem/";
            var content = await client.PostAsync(uri, bagItemJson);

            if (content.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return Content("Failed");
        }

        //public async Task<IActionResult> DeleteBagItem(int productId)
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
        //    var subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //    string uri = "https://localhost:6001/api/BagItem/DeleteBagItem/" + productId + "/" + subject;
        //    var content = await client.DeleteAsync(uri);

        //    if (content.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Details","Bag");
        //    }
        //    return NotFound();
        //}
    }
}
