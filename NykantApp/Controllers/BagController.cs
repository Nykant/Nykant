using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NykantApp.Models;
using NykantApp.Models.DTO;

namespace NykantApp.Controllers
{

    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Bag/Details/" + id;
            var result = await client.GetStringAsync(uri);

            BagDetails bagd = JsonSerializer.Deserialize<BagDetails>(result);

            if (bagd == null)
            {
                return NotFound();
            }

            return View(bagd);
        }

        public async Task<IActionResult> AddProduct(int productId, string bagId, int productQuantity)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            BagItem bagItem = new BagItem
            {
                BagId = bagId,
                ProductId = productId,
                Quantity = productQuantity
            };

            var todoItemJson = new StringContent(
                JsonSerializer.Serialize(bagItem),
                Encoding.UTF8,
                "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Bag/AddProduct/" + productId + "/" + bagId + "/" + productQuantity;
            var content = await client.PutAsync(uri, todoItemJson);

            if (content.IsSuccessStatusCode)
            {
                return Redirect($"Details/{bagId}");
            }
            return NotFound();
        }

        public async Task<IActionResult> DeleteBagItem(int productId, string bagId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Bag/Details/" + productId + "/" + bagId;
            var content = await client.DeleteAsync(uri);

            if (content.IsSuccessStatusCode)
            {
                return Redirect($"Details/{bagId}");
            }
            return NotFound();
        }

    }
}
