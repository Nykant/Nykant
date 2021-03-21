using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var json = await GetRequest("/Product/GetProducts");

            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            ViewBag.Categories = JsonConvert.DeserializeObject<List<Category>>(await GetRequest("/Category/GetCategories"));
            return View(products);
        }

        [Route("/{controller}/{action}/{id}/{itemAdded?}/{reviewSent?}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id, bool itemAdded, bool reviewSent)
        {
            var json = await GetRequest($"/Product/GetProduct/{id}");
            var reviewsJson = await GetRequest($"/Review/GetProductReviews/{id}");

            Product product = JsonConvert.DeserializeObject<Product>(json);
            List<Review> reviews = JsonConvert.DeserializeObject<List<Review>>(reviewsJson);

            ProductVM productVM = new ProductVM
            {
                ItemAdded = itemAdded,
                ReviewSent = reviewSent,
                Product = product,
                Reviews = reviews,
                Review = new Review()
            };

            return View(productVM);
        }


        [HttpPost]
        public async Task<IActionResult> Filter(string categoryName)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(await GetRequest("/Category/GetCategories"));
            Category category = null;
            foreach(var item in categories)
            {
                if(item.Name == categoryName)
                {
                    category = item;
                    break;
                }
            }
            var json = await GetRequest("/Product/GetProducts");
            var filteredList = new List<Product>();
            foreach (var product in JsonConvert.DeserializeObject<List<Product>>(json))
            {
                if (product.CategoryId == category.Id)
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
