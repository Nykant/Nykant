using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ProductController : BaseController
    {
        public ProductController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var json = await GetRequest("/Product/GetProducts");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            ViewBag.Categories = JsonConvert.DeserializeObject<List<Category>>(await GetRequest("/Category/GetCategories"));

            if (searchString == null)
            {
                return View(products);
            }
            else
            {
                var filteredList = new List<Product>();
                foreach (var product in products)
                {
                    if (product.Description.ToLower().Contains(searchString.ToLower()) || product.Category.Name.ToLower().Contains(searchString.ToLower()))
                    {
                        filteredList.Add(product);
                    }
                }

                ViewBag.CurrentFilter = searchString;
                return View(filteredList);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var json = await GetRequest($"/Product/GetProduct/{id}");
            Product product = JsonConvert.DeserializeObject<Product>(json);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetLength(int lengthInput)
        {
            var json = await GetRequest($"/Product/GetProduct/{lengthInput}");
            Product product = JsonConvert.DeserializeObject<Product>(json);
            return View("Details", product);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(string categoryName)
        {
            var json = await GetRequest("/Product/GetProducts");
            var filteredList = new List<Product>();
            foreach (var product in JsonConvert.DeserializeObject<List<Product>>(json))
            {
                if (product.Category.Name.ToLower().Contains(categoryName.ToLower()))
                {
                    filteredList.Add(product);
                }
            }
            ViewBag.CurrentFilter = categoryName;
            ViewData.Model = filteredList;

            return new PartialViewResult
            {
                ViewName = "_ProductListPartial",
                ViewData = this.ViewData
            };
        }
    }
}
