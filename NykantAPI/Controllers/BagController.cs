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
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Models.DTO;

namespace NykantAPI.Controllers
{
    [Route("api/{controller}/{action}/{id?}")]
    [ApiController]
    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger, ApplicationDbContext context)
            :base (logger, context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<BagDetailsDTO>> Details(string subject)
        {
            var bag = _context.Bags.FirstOrDefault(x => x.Subject == subject);
            if (bag == null)
            {
                bag = new Bag
                {
                    Subject = subject
                };
                await _context.Bags.AddAsync(bag);
                await _context.SaveChangesAsync();
            }

            var bagItems = _context.BagItems
                .Where(x => x.BagId == bag.BagId);
            
            int priceSum = 0;

            foreach (var bagItem in bagItems)
            {
                priceSum += bagItem.Product.Price;
            }

            if (bagItems == null)
            {
                return null;
            }

            BagDetailsDTO bagDetails = new BagDetailsDTO
            {
                BagId = bag.BagId,
                BagItems = bagItems,
                PriceSum = priceSum
            };

            //string jsonString = JsonSerializer.Serialize(bagDetails);

            return Ok(bagDetails);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(int productId, int bagId, int productQuantity)
        {
            if (BagItemExists(bagId, productId))
            {
                var bagItem = _context.BagItems.FirstOrDefault(x => x.BagId == bagId && x.ProductId == productId);
                bagItem.Quantity += productQuantity;
                _context.BagItems.Update(bagItem);
                _context.SaveChanges();
                return Content($"You already had this product in your bag, but now added {productQuantity} to the quantity");
            }
            else
            {
                var bagItem = new BagItem { ProductId = productId, BagId = bagId, Quantity = productQuantity };
                _context.BagItems.Add(bagItem);
                _context.SaveChanges();
                return Content("Success");
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBagItem(int productId, string bagId)
        {
            var bagItem = await _context.BagItems.FindAsync(bagId, productId);
            var result = _context.BagItems.Remove(bagItem);
            await _context.SaveChangesAsync();
            return Content("");
        }

        private bool BagItemExists(int bagId, int productId)
        {
            return _context.BagItems.Any(e => e.BagId == bagId && e.ProductId == productId);
        }

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.Subject == id);
        }

    }
}
