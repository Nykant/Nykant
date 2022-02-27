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
            try
            {
                var products = _context.Products.Include(x => x.Category).Include(x => x.Colors).Include(x => x.ProductLengths);
                var json = JsonConvert.SerializeObject(products, Extensions.JsonOptions.jsonSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }

        [HttpGet]
        public async Task<ActionResult> GetBagItemProducts(List<BagItem> bagItems)
        {
            try
            {
                var products = new List<Product>();
                foreach (var item in bagItems)
                {
                    products.Add(await _context.Products.FindAsync(item.ProductId));
                }
                var json = JsonConvert.SerializeObject(products, Extensions.JsonOptions.jsonSettings);
                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) 
        {
            try
            {
                var product = await _context.Products
                    .Include(x => x.Images)
                    .Include(x => x.Colors)
                    .Include(x => x.ProductLengths)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var json = JsonConvert.SerializeObject(product, Extensions.JsonOptions.jsonSettings);

                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }

        [HttpGet("{urlname}")]
        public async Task<ActionResult<ProductDTO>> GetProductWithUrlName(string urlname)
        {
            try
            {
                var product = await _context.Products
                    .Include(x => x.Images)
                    .Include(x => x.Colors)
                    .Include(x => x.ProductLengths)
                    .FirstOrDefaultAsync(x => x.UrlName == urlname);

                var json = JsonConvert.SerializeObject(product, Extensions.JsonOptions.jsonSettings);

                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }

        [HttpPatch]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }
    }
}
