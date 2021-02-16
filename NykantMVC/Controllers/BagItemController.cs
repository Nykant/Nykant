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

        [HttpPatch]
        public async Task<IActionResult> UpdateBagItem(BagItem bagItem, int? selection)
        {
            if (selection != 0)
            {
                if (selection == 1)
                {
                    bagItem.Quantity += 1;
                }
                else if (selection == 2)
                {
                    bagItem.Quantity -= 1;
                }
            }

            var response = await PatchRequest("/BagItem/UpdateBagItem", bagItem);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Bag");
            }
            return Content("Failed");
        }

        [HttpPost]
        public async Task<IActionResult> AddBagItem(ProductVM productVM, int productQuantity)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            BagItem bagItem = new BagItem
            {
                Product = productVM.Product,
                ProductId = productVM.Product.Id,
                Quantity = productQuantity
            };

            if (!isAuthenticated)
            {
                try
                {
                    List<BagItem> bagItems = null;
                    if (HttpContext.Session.Get<List<BagItem>>(BagSessionKey) == default)
                    {
                        bagItems = new List<BagItem>();
                    }
                    else
                    {
                        bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);
                    }
                    bagItems.Add(bagItem);
                    HttpContext.Session.Set<List<BagItem>>(BagSessionKey, bagItems);
                    return NoContent();
                }
                catch (Exception e)
                {
                    return Content(e.Message);
                }
            }

            bagItem.Subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;

            var response = await PostRequest("/BagItem/PostBagItem", bagItem);

            if (response.IsSuccessStatusCode)
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
        //        return RedirectToAction("Details", "Bag");
        //    }
        //    return NotFound();
        //}
    }
}
