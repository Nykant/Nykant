using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class BagItemController : BaseController
    {
        public BagItemController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> UpdateBagItem(int productId, int bagId, int productQuantity, int selection)
        {
            BagItem bagItem = new BagItem
            {
                BagId = bagId,
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

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var bagItemJson = new StringContent(
                JsonConvert.SerializeObject(bagItem),
                Encoding.UTF8,
                "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/BagItem/UpdateBagItem/" + productId + "/" + bagId + "/" + bagItem.Quantity;
            var content = await client.PatchAsync(uri, bagItemJson);

            if (content.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Bag", new { subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value });
            }
            return Content("Failed");
        }

        public async Task<IActionResult> AddBagItem(int productId, int bagId, int productQuantity)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            BagItem bagItem = new BagItem
            {
                BagId = bagId,
                ProductId = productId,
                Quantity = productQuantity
            };

            var todoItemJson = new StringContent(
                JsonConvert.SerializeObject(bagItem),
                Encoding.UTF8,
                "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/BagItem/AddBagItem/" + productId + "/" + bagId + "/" + productQuantity;
            var content = await client.PostAsync(uri, todoItemJson);

            if (content.IsSuccessStatusCode)
            {
                return NoContent();
            }
            return Content("Failed");
        }

        public async Task<IActionResult> DeleteBagItem(int productId, int bagId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/BagItem/DeleteBagItem/" + productId + "/" + bagId;
            var content = await client.DeleteAsync(uri);

            if (content.IsSuccessStatusCode)
            {
                return RedirectToAction("GetBag","Bag", new { subject = subject });
            }

            return NotFound();
        }
    }
}
