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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class ProductController : BaseController
    {
        public ProductController(ILogger<ProductController> logger, ApplicationDbContext _context) : base(logger, _context)
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }

        [HttpGet("{categoryId}")]
        public ActionResult<IQueryable<Product>> GetRelatedProducts(int categoryId)
        {
            try
            {
                IQueryable<Product> products;
                if(categoryId == 5 || categoryId == 1)
                {
                    products = _context.Products
                        .Where(x => x.Category.Id == 5 || x.Category.Id == 1);
                }
                else
                {
                    products = _context.Products
                        .Where(x => x.Category.Id == categoryId);
                }

                var json = JsonConvert.SerializeObject(products, Extensions.JsonOptions.jsonSettings);

                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<IQueryable<Product>> GetDiscountProducts()
        {
            try
            {

                var products = _context.Products.Where(x => x.Discount > 0);
                var json = JsonConvert.SerializeObject(products, Extensions.JsonOptions.jsonSettings);

                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }


        }
    }
}
