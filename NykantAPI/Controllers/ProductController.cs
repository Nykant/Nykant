using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Models.DTO;
using Newtonsoft.Json;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class ProductController : BaseController
    {
        public ProductController(ILogger<BaseController> logger, ApplicationDbContext context) : base(logger, context)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = _context.Products.Include(x => x.Category).Include(x => x.Colors).Include(x => x.ProductLengths);
            var json = JsonConvert.SerializeObject(products, Extensions.JsonOptions.jsonSettings);
            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) 
        {
            var product = await _context.Products
                .Include(x => x.Images)
                .Include(x => x.Colors)
                .Include(x => x.ProductLengths)
                .FirstOrDefaultAsync(x => x.Id == id);

            var json = JsonConvert.SerializeObject(product, Extensions.JsonOptions.jsonSettings);

            return Ok(json);
        }

        [HttpPatch]
        public async Task<ActionResult> ReduceAmount(int id, int amount)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product.Amount >= amount)
            {
                product.Amount = product.Amount - amount;
                _context.Update(product);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
