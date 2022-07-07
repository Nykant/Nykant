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
using Microsoft.AspNetCore.Authorization;
using NykantMVC.Services;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ProductController : BaseController
    {
        public ProductController(ILogger<ProductController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                return View(products);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }
        }

        [HttpGet("Produkter")]
        public async Task<IActionResult> Gallery()
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                var jsonCategories = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);
                if (TempData["Filter"] != null)
                {
                    ViewBag.CurrentFilter = TempData["Filter"];
                    var filteredList = new List<Product>();
                    foreach (var product in products)
                    {
                        if (product.Description.ToLower().Contains(ViewBag.CurrentFilter.ToLower()) || product.Category.Name.ToLower().Contains(ViewBag.CurrentFilter.ToLower()))
                        {
                            filteredList.Add(product);
                        }
                    }
                    var galleryVM = new GalleryVM
                    {
                        Categories = categories,
                        Products = filteredList
                    };

                    return View(galleryVM);
                }
                else
                {
                    var galleryVM = new GalleryVM
                    {
                        Categories = categories,
                        Products = products
                    };

                    return View(galleryVM);
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }
        }

        [HttpGet("Produkter/{category}")]
        public async Task<IActionResult> CategoryView(string category)
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                var jsonCategories = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);

                var filteredList = new List<Product>();
                foreach (var product in products)
                {
                    if (product.Category.Name == category)
                    {
                        filteredList.Add(product);
                    }
                }
                if(filteredList.Count > 0)
                {
                    var categoryVM = new CategoryViewVM
                    {
                        Categories = categories,
                        Products = filteredList,
                        CategoryName = category
                    };
                    return View(categoryVM);
                }
                else
                {
                    TempData["Filter"] = category;
                    return RedirectToAction("Gallery");
                }

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
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
                var jsonCategories = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);

                var filteredList = new List<Product>();
                foreach (var product in products)
                {
                    if (product.Description.ToLower().Contains(searchString.ToLower()) || product.Category.Name.ToLower().Contains(searchString.ToLower()))
                    {
                        filteredList.Add(product);
                    }
                }
                var galleryVM = new GalleryVM
                {
                    Categories = categories,
                    Products = filteredList
                };
                ViewBag.CurrentFilter = searchString;
                return View("Gallery", galleryVM);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("Product/Edit/{urlname}")]
        [HttpGet]
        public async Task<IActionResult> Edit(string urlname)
        {
            try
            {
                var json = await GetRequest($"/Product/GetProductWithUrlName/{urlname}");
                Product product = JsonConvert.DeserializeObject<Product>(json);

                return View(product);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Product/Edit/{urlname}")]
        public async Task<IActionResult> Edit(Product product) // dont use the model, it fucks, and go get the whole model and update that 
        {
            try
            {
                var json = await PatchRequest($"/Product/UpdateProduct", product);
                if (!json.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - error: {json.StatusCode}");
                    ViewData.Model = product;
                    return new PartialViewResult
                    {
                        ViewName = "_EditFormPartial",
                        ViewData = this.ViewData,
                        StatusCode = 500
                    };
                }

                ViewData.Model = product;
                return new PartialViewResult
                {
                    ViewName = "_EditFormPartial",
                    ViewData = this.ViewData,
                    StatusCode = 200
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                ViewData.Model = product;
                return new PartialViewResult
                {
                    ViewName = "_EditFormPartial",
                    ViewData = this.ViewData,
                    StatusCode = 500
                };
            }
        }

        [HttpGet("Produkt/{urlname}")]
        public async Task<IActionResult> Details(string urlname)
        {
            try
            {
                var json = await GetRequest($"/Product/GetProductWithUrlName/{urlname}");
                Product product = JsonConvert.DeserializeObject<Product>(json);

                var relatedProductsJson = await GetRequest($"/Product/GetRelatedProducts/{product.CategoryId}");
                var relatedProducts = JsonConvert.DeserializeObject<List<Product>>(relatedProductsJson);

                var productVM = new ProductVM
                {
                    Product = product,
                    RelatedProducts = relatedProducts
                };

                return View(productVM);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}, produkt: {urlname}");
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
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                var jsonCategories = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);
                var filteredList = new List<Product>();
                foreach (var product in products)
                {
                    if (product.Category.Name.ToLower().Contains(categoryName.ToLower()))
                    {
                        filteredList.Add(product);
                    }
                }
                var galleryVM = new GalleryVM
                {
                    Categories = categories,
                    Products = filteredList
                };
                ViewBag.CurrentFilter = categoryName;
                ViewData.Model = galleryVM;

                return new PartialViewResult
                {
                    ViewName = "_ProductListPartial",
                    ViewData = this.ViewData
                };

            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest($"time: {DateTime.Now} - {e.Message}");
            }


        }
    }
}
