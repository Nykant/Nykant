using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Models.DTO;
using NykantAPI.Services;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/")]
    public class OrderController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public OrderController(ILogger<BaseController> logger, ApplicationDbContext context, IProtectionService protectionService)
            : base(logger, context)
        {
            _protectionService = protectionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();
                return Ok(JsonConvert.SerializeObject(orders));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            try
            {
                var order = await _context.Orders.Include(x => x.Customer).ThenInclude(x => x.ShippingAddress).Include(x => x.Customer).ThenInclude(x => x.BillingAddress).Include(x => x.OrderItems).ThenInclude(x => x.Product).Include(x => x.ShippingDelivery).Include(x => x.Invoice).FirstOrDefaultAsync(x => x.Id == id);
                return Ok(JsonConvert.SerializeObject(order, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        }

        [HttpPatch]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            try
            {
                _protectionService.UnprotectOrder(order);
                if (ModelState.IsValid)
                {
                    _protectionService.ProtectOrder(order);
                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }


        } 

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                _protectionService.UnprotectOrder(order);
                if (ModelState.IsValid)
                {
                    _protectionService.ProtectOrder(order);
                    var entity = _context.Orders.Add(order).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetOrder", new { id = entity.Id }, entity);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }

           
        }

        private bool OrderExists(int orderId)
        {
            return _context.Orders.Any(e => e.Id == orderId);
        }
    }
}
