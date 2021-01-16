using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nykant.Areas.Identity.Data;
using Nykant.Data;
using Nykant.Models;
using Nykant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(ILogger<ProductController> logger, ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        [Route("product/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.productId = id;
            ViewBag.bagId = _userManager.GetUserId(User);
            ViewBag.productQuantity = 1;

            Product_Image productImage = new Product_Image
            {
                Product = _context.Products.FirstOrDefault(x => x.Id == id),
                Images = _context.Images.Where(x => x.ProductId == id)
            };

            return View(productImage);
        }
    }
}
