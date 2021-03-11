using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var json = await GetRequest("/Product/GetProducts");

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

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
    }
}
