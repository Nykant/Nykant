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
    public class ProductController : BaseController
    {

        public ProductController(ILogger<BaseController> logger, ApplicationDbContext context) : base(logger, context)
        {
        }

        [HttpGet("api/{controller}/{action}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("api/{controller}/{action}/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) 
        {

            var product = await _context.Products
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id);

            ProductDTO productDTO = new ProductDTO
            {
                Product = product
            };

            var json = JsonConvert.SerializeObject(productDTO, Extensions.JsonOptions.jsonSettings);
            return Ok(json);
        }
    }
}
