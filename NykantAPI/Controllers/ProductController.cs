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
            var products = _context.Products.Include(x => x.Category);
            var json = JsonConvert.SerializeObject(products, Extensions.JsonOptions.jsonSettings);
            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) 
        {
            var product = await _context.Products
                .Include(x => x.Images)
                .Include(x => x.Colors)
                .FirstOrDefaultAsync(x => x.Id == id);

            var json = JsonConvert.SerializeObject(product, Extensions.JsonOptions.jsonSettings);

            return Ok(json);
        }
    }
}
