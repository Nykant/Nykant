//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using NykantApp.Models;
//using NykantApp.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NykantApp.Controllers
//{
//    public class ProductController : BaseController
//    {
//        public ProductController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<HomeController> logger) : base(signInManager, userManager, logger)
//        {
//        }

//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Products.ToListAsync());
//        }

//        public IActionResult Details(int id)
//        {
//            ViewBag.productId = id;
//            ViewBag.bagId = _userManager.GetUserId(User);
//            ViewBag.productQuantity = 1;

//            Product_Image productImage = new Product_Image
//            {
//                Product = _context.Products.FirstOrDefault(x => x.Id == id),
//                Images = _context.Images.Where(x => x.ProductId == id)
//            };

//            return View(productImage);
//        }
//    }
//}
