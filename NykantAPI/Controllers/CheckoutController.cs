using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Controllers
{
    [ApiController]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpGet("api/{controller}/{action}/{subject}")]
        public async Task<ActionResult<CheckoutDTO>> GetCheckoutInfo(string subject)
        {
            var bag = _context.Bags
                .FirstOrDefault(x => x.Subject == subject); // FIX THIS SHIT ????

            var bagItems = _context.BagItems
                .Include(x => x.Product)
                .Where(x => x.BagId == bag.BagId);

            int priceSum = 0;

            foreach (var bagItem in bagItems)
            {
                priceSum += bagItem.Product.Price;
            }

            CheckoutDTO checkoutDTO = new CheckoutDTO
            {
                 Subject = subject,
                 BagItems = bagItems.ToList(),
                 PriceSum = priceSum
            };

            var json = JsonConvert.SerializeObject(checkoutDTO, Extensions.JsonOptions.jsonSettings);

            return Ok(json);
        }

    }
}
