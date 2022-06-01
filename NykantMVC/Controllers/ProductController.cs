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
using System;
using Microsoft.Extensions.Configuration;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ProductController : BaseController
    {
        public ProductController(ILogger<ProductController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf) : base(logger, urls, htmlEncoder, conf)
        {
        }

        [HttpGet("Produkter")]
        public async Task<IActionResult> Gallery()
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                ViewBag.Categories = JsonConvert.DeserializeObject<List<Category>>(await GetRequest("/Category/GetCategories"));
                return View(products);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }

        }

        [HttpPost("Produkter")]
        public async Task<IActionResult> Search(string searchString)
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                ViewBag.Categories = JsonConvert.DeserializeObject<List<Category>>(await GetRequest("/Category/GetCategories"));

                var filteredList = new List<Product>();
                foreach (var product in products)
                {
                    if (product.Description.ToLower().Contains(searchString.ToLower()) || product.Category.Name.ToLower().Contains(searchString.ToLower()))
                    {
                        filteredList.Add(product);
                    }
                }

                ViewBag.CurrentFilter = searchString;
                return View("Gallery", filteredList);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }


        }

        [Route("Produkt/{urlname}")]
        [HttpGet]
        public async Task<IActionResult> Details(string urlname)
        {
            try
            {
                var json = await GetRequest($"/Product/GetProductWithUrlName/{urlname}");
                Product product = JsonConvert.DeserializeObject<Product>(json);

                //var relatedProductsJson = await GetRequest($"/Product/GetRelatedProducts/{product.CategoryId}");
                //var relatedProducts = JsonConvert.DeserializeObject<List<Product>>(relatedProductsJson);

                var productVM = new ProductVM
                {
                    Product = product
                    //RelatedProducts = relatedProducts
                };

                return View(productVM);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostLength(string urlname)
        {
            return RedirectToAction("Details", new { urlname = urlname });
        }

        [HttpPost]
        public async Task<IActionResult> Filter(string categoryName)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }


        }
    }
}
