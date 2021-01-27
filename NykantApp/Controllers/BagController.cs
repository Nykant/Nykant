using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NykantApp.Models;
using NykantApp.Models.DTO;

namespace NykantApp.Controllers
{

    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("https://localhost:6001/Bag/Details/{id}");

            if (content == null)
            {
                return NotFound();
            }

            BagDetails bagDetails = JsonSerializer.Deserialize<BagDetails>(content);

            return View(bagDetails);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddProduct(int productId, string bagId, int productQuantity)
        //{
        //    if (!_signInManager.IsSignedIn(User))
        //    {
        //        return Content("Must be signed in");
        //    }
        //    else if (BagItemExists(bagId, productId))
        //    {
        //        var bagItem = _context.BagItems.FirstOrDefault(x => x.BagId == bagId && x.ProductId == productId);
        //        bagItem.Quantity += productQuantity;
        //        _context.BagItems.Update(bagItem);
        //        _context.SaveChanges();
        //        return Content($"You already had this product in your bag, but now added {productQuantity} to the quantity");
        //    }
        //    else
        //    {
        //        var bagItem = new BagItem { ProductId = productId, BagId = bagId, Quantity = productQuantity };
        //        _context.BagItems.Add(bagItem);
        //        _context.SaveChanges();
        //        return Content("Success");
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteBagItem(int productId, string bagId)
        //{
        //    var bagItem = await _context.BagItems.FindAsync(bagId, productId);
        //    _context.BagItems.Remove(bagItem);
        //    await _context.SaveChangesAsync();
        //    return Redirect($"Details/{bagId}");
        //}

        //private bool BagItemExists(string bagId, int productId)
        //{
        //    return _context.BagItems.Any(e => e.BagId == bagId && e.ProductId == productId);
        //}

        //private bool BagExists(string id)
        //{
        //    return _context.Bags.Any(e => e.UserId == id);
        //}

    }
}
