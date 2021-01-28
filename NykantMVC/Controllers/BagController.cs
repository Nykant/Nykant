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

            BagDetails bagd = JsonConvert.DeserializeObject<BagDetails>(result);

            if (bagd == null)
            {
                return NotFound();
            }

            return View(bagd);
        }

        public async Task<IActionResult> AddProduct(int productId, int bagId, int productQuantity)
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
            string uri = "https://localhost:6001/api/Bag/AddProduct/" + productId + "/" + bagId + "/" + productQuantity;
            var content = await client.PutAsync(uri, todoItemJson);

            if (content.IsSuccessStatusCode)
            {
                return Redirect($"Details/{bagId}");
            }
            return NotFound();
        }

        public async Task<IActionResult> DeleteBagItem(int productId, int bagId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var subject = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Bag/Details/" + productId;
            var content = await client.DeleteAsync(uri);

            if (content.IsSuccessStatusCode)
            {
                return Redirect($"Details/{bagId}");
            }
            return NotFound();
        }

    }
}
