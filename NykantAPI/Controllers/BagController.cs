using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Models.DTO;

namespace NykantAPI.Controllers
{
    [ApiController]
    public class BagController : BaseController
    {
        public BagController(ILogger<BaseController> logger, ApplicationDbContext context)
            :base (logger, context)
        {
        }

        [HttpGet("api/{controller}/{action}/{subject}")]
        public async Task<ActionResult<BagDetailsDTO>> GetBag(string subject) // THIS IS A SHIT METHOD :D
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }


            var bag = _context.Bags.FirstOrDefault(x => x.Subject == subject); // FIX THIS SHIT PLEASE :D
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
                .Include(x => x.Product)
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

            var json = JsonConvert.SerializeObject(bagDetails, Extensions.JsonOptions.jsonSettings);

            return Ok(json);
        }

        private bool BagExists(string id)
        {
            return _context.Bags.Any(e => e.Subject == id);
        }

    }
}
