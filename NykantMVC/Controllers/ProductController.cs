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
using System.Linq;
using System.Net.Http;
using System.Text;
using NykantMVC.Friends;
using Microsoft.AspNetCore.Http.Extensions;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ProductController : BaseController
    {
        private readonly IGoogleApiService googleApiService;
        public ProductController(ILogger<ProductController> logger, IGoogleApiService googleApiService, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
            this.googleApiService = googleApiService;
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

        [HttpGet("Møbler")]
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

        [HttpGet("Møbler/{category}")]
        public async Task<IActionResult> CategoryView(string category)
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                var jsonCategories = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);

                var filteredList = new List<Product>();
                var categoryMod = new Category();
                foreach (var product in products)
                {
                    if (product.Category.Name.ToLower() == category.ToLower())
                    {
                        categoryMod = product.Category;
                        filteredList.Add(product);
                    }
                }

                if(filteredList.Count > 0)
                {
                    var categoryVM = new CategoryViewVM
                    {
                        Categories = categories,
                        Products = filteredList,
                        Category = categoryMod
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

        [HttpPost("Møbler")]
        public async Task<IActionResult> Search(string searchString)
        {
            try
            {
                var json = await GetRequest("/Product/GetProducts");
                var products = JsonConvert.DeserializeObject<List<Product>>(json);
                var jsonCategories = await GetRequest("/Category/GetCategories");
                var categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);
                foreach(var item in categories)
                {
                    if(item.Name.ToLower() == searchString.ToLower())
                    {
                        return RedirectToAction("CategoryView", new { category = searchString });
                    }
                }

                var filteredList = new List<Product>();
                foreach (var product in products)
                {
                    if (product.Description.ToLower().Contains(searchString.ToLower()) || product.Category.Name.ToLower().Contains(searchString.ToLower()))
                    {
                        filteredList.Add(product);
                    }
                }

                int isOneCategory = 0;
                if(filteredList.Count > 1)
                {
                    isOneCategory = 1;
                    for(int i = 1; i < filteredList.Count; i++)
                    {
                        if(filteredList[i - 1].Category.Id != filteredList[i].Category.Id)
                        {
                            isOneCategory = 2;
                        }
                    }
                }
                else if(filteredList.Count == 1)
                {
                    isOneCategory = 1;
                }

                var galleryVM = new GalleryVM
                {
                    Categories = categories,
                    Products = filteredList
                };

                switch (isOneCategory)
                {
                    case 1:
                        var category = categories.FirstOrDefault(x => x.Name.ToLower().Contains(searchString.ToLower()));
                        if(category == default)
                        {
                            ViewBag.CurrentFilter = searchString;
                            return View("Gallery", galleryVM);
                        }
                        var categoryName = category.Name;
                        return RedirectToAction("CategoryView", new { category = categoryName });
                    default:
                        ViewBag.CurrentFilter = searchString;
                        return View("Gallery", galleryVM);
                }
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

                //var list = await googleApiService.GetProductList();


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

        [HttpGet]
        public async Task<IActionResult> UpdateMerchantCenter()
        {
            var json = await GetRequest("/Product/GetProducts");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            var accesstoken = googleApiService.GetAccessToken();

            var client = new HttpClient();
            //var response = await client.GetStringAsync($"https://shoppingcontent.googleapis.com/content/v2.1/549068494/products?access_token={accesstoken}");
            //var products = JsonConvert.SerializeObject(response);

            var mvc = $"{_urls.Mvc}";

            var tableCat = "4191";
            var bøjleCat = "631";
            var bænke = "6851";
            var hylder = "6372";
            var stativ = "5714";

            foreach (var product in products)
            {
                var s = product.Number.Split('+', ' ');
                product.Number = s[0];

                var t = product.Number.ToCharArray();
                var itemGroupId = t[0].ToString() + t[1].ToString() + "000";
                var udløb = new DateTime(2024, 12, 30);

                var updateProduct = new Models.Google.Product
                {
                    Title = product.MetaTitle,
                    Description = product.MetaDescription,
                    Price = new Models.Google.Price { Currency = "dkk", Value = product.Price.ToString() },
                    Link = $"https://www.nykant.dk/møbler/{product.Category.Name}/" + product.UrlName,
                    Brand = "Nykant",
                    Mpn = product.Number,
                    IdentifierExists = true,
                    OfferId = product.Number,
                    Channel = "online",
                    //Kind = "content#product",
                    Color = product.Oil,
                    ItemGroupId = itemGroupId,
                    Material = "Træ, Egetræ",
                    //Source = "api",
                    Condition = "new",
                    ContentLanguage = "da",
                    TargetCountry = "DK",
                    Availability = "in stock",
                    ExpirationDate = /*$"{udløb.Year}-{udløb.Month}-{udløb.Day}T00:00:00+0100",*/ null,
                    IncludedDestinations = new string[]
                    {
                        "Shopping_ads",
                        "Free_listings"
                    }
                };

                switch (product.Oil)
                {
                    case "Naturolie":
                        updateProduct.ProductHighlights = new string[]
                        {
                            "Gratis Og Hurtig Levering",
                            "Massivt Egetræsmøbel I Høj Kvalitet",
                            $"Overfladebehandlet Med {product.Oil}"
                        };
                        break;
                    case "Sortolie":
                        updateProduct.ProductHighlights = new string[]
{
                            "Gratis Og Hurtig Levering",
                            "Massivt Egetræsmøbel I Høj Kvalitet",
                            $"Overfladebehandlet Med {product.Oil}"
};
                        break;
                    case "Hvidolie":
                        updateProduct.ProductHighlights = new string[]
{
                            "Gratis Og Hurtig Levering",
                            "Massivt Egetræsmøbel I Høj Kvalitet",
                            $"Overfladebehandlet Med {product.Oil}"
};
                        break;
                    default:
                        break;
                }

                updateProduct.Id = $"{updateProduct.Channel}:{updateProduct.ContentLanguage}:{updateProduct.TargetCountry}:{updateProduct.OfferId}";

                switch (product.CategoryId)
                {
                    case 1:
                        updateProduct.GoogleProductCategory = stativ;
                        updateProduct.ProductTypes = new string[]
                        {
                             "Hjem > Produkter > Egetræsmøbler > Organisering Og Opbevaring > Tøjstativer I Træ",
                             "Hjem > Produkter > Møbler > Organisering Og Opbevaring > Tøjstativ"
                        };
                        break;
                    case 2:
                        updateProduct.GoogleProductCategory = tableCat;
                        updateProduct.ProductTypes = new string[]
                        {
                             "Hjem > Produkter > Møbler > Kontormøbler > Borde > Skriveborde",
                             "Hjem > Produkter > Egetræsmøbler > Kontormøbler > Egetræsborde > Skriveborde"
                        };
                        break;
                    case 3:
                        updateProduct.GoogleProductCategory = hylder;
                        updateProduct.ProductTypes = new string[]
                        {
                             "Hjem > Produkter > Møbler > Hylder > Væghylder",
                             "Hjem > Produkter > Egetræsmøbler > Egetræshylder > Væghylder I Træ"
                        };
                        break;
                    case 4:
                        updateProduct.GoogleProductCategory = bænke;
                        if (product.Name.Contains("Filippa"))
                        {
                            updateProduct.ProductTypes = new string[]
                            {
                                "Hjem > Produkter > Møbler > Organisering Og Opbevaring > Opbevaringsbænke",
                                "Hjem > Produkter > Egetræsmøbler > Entremøbler > Opbevaringsbænke I Egetræ"
                            };
                        }
                        else
                        {
                            updateProduct.ProductTypes = new string[]
                            {
                                "Hjem > Produkter > Møbler > Entremøbler > Bænke I Træ",
                                "Hjem > Produkter > Egetræsmøbler > Møbler Til Entreen > Egetræsbænke"
                             };
                        }
                        
                        break;
                    case 5:
                        updateProduct.GoogleProductCategory = bøjleCat;
                        updateProduct.ProductTypes = new string[]
                            {
                                "Hjem > Produkter > Møbler > Organisering Og Opbevaring > Tøjbøjler I Træ",
                                "Hjem > Produkter > Egetræsmøbler > Organisering Og Opbevaring > Egetræsbøjler"
                             };
                        updateProduct.Multipack = "3";
                        break;
                    default:
                        break;
                }

                if (product.Discount > 0)
                {
                    updateProduct.SalePrice = new Models.Google.Price { Currency = "dkk", Value = ProductHelper.GetPrice(product).ToString() };
                }
                else
                {
                    updateProduct.SalePrice = null;
                }

                var imgs = product.Images.ToList();

                for (int i = 0; i < imgs.Count; i++)
                {
                    if (imgs[i].ImageType == ImageType.DetailsFullscreen)
                    {
                        if (imgs[i].Source.Contains("1"))
                        {
                            updateProduct.ImageLink = imgs[i].Source;
                        }
                    }
                }

                var sourceList = new List<string>();
                for (int i = 0; i < imgs.Count; i++)
                {
                    if (imgs[i].ImageType == ImageType.DetailsFullscreen)
                    {
                        if (!imgs[i].Source.Contains("1"))
                        {
                            sourceList.Add(imgs[i].Source);
                        }
                    }
                }

                updateProduct.AdditionalImageLinks = sourceList.ToArray();

                var content = new StringContent(JsonConvert.SerializeObject(updateProduct), Encoding.UTF8, "application/json-patch+json");
                var httpResponse = await client.PostAsync($"https://shoppingcontent.googleapis.com" + $"/content/v2.1/549068494/products?access_token={accesstoken}", content);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    _logger.LogError($"time: {DateTime.Now} - update merchant product error - {httpResponse.ReasonPhrase}");
                    return Content("error");
                }
            }

            return Redirect($"{mvc}/Product/List");
        }

        [HttpGet("Møbler/{category}/{urlname}")]
        public async Task<IActionResult> Details(string category, string urlname)
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

                if(urlname == "none" || urlname == null)
                {
                    return Redirect($"Møbler/{category}");
                }

                return View(productVM);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}, produkt: {urlname}, category: {category}, request-path: {HttpContext.Request.Path}, request-query: {HttpContext.Request.QueryString}, request-display-url: {HttpContext.Request.GetDisplayUrl()}");
                return Redirect("/Fejl");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostLength(string category, string urlname)
        {
            return RedirectToAction("Details", new { category = category, urlname = urlname });
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
