using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nykant.Data;
using Nykant.Models;
using Nykant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductController(ILogger<ProductController> logger, ApplicationDbContext context)
        {
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
            Product_Image productImage = new Product_Image
            {
                Product = _context.Products.FirstOrDefault(x => x.Id == id),
                Images = _context.Images.Where(x => x.ProductId == id)
            };
            return View(productImage);
        }
    }
}
