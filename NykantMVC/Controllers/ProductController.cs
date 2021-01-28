using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Product/GetProducts";
            var response = await client.GetStringAsync(uri);

            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(response);

            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string uri = "https://localhost:6001/api/Product/GetProduct/" + id;
            var response = await client.GetStringAsync(uri);

            ProductVM productVM = JsonConvert.DeserializeObject<ProductVM>(response);

            if (productVM == null)
            {
                return NotFound();
            }

            ViewBag.productId = id;
            ViewBag.bagId = productVM.BagId;
            ViewBag.productQuantity = 1;

            return View(productVM);
        }
    }
}
