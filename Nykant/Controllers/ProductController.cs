using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nykant.Data;
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
    }
}
