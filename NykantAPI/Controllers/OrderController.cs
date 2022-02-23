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
            var orders = await _context.Orders.ToListAsync();
            return Ok(JsonConvert.SerializeObject(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.Include(x => x.Customer).ThenInclude(x => x.ShippingAddress).Include(x => x.Customer).ThenInclude(x => x.BillingAddress).Include(x => x.OrderItems).ThenInclude(x => x.Product).Include(x => x.ShippingDelivery).Include(x => x.Invoice).FirstOrDefaultAsync(x => x.Id == id);
            return Ok(JsonConvert.SerializeObject(order, Extensions.JsonOptions.jsonSettings));
        }

        [HttpPatch]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            _protectionService.UnprotectOrder(order);
            if (ModelState.IsValid)
            {
                _protectionService.ProtectOrder(order);
                if (OrderExists(order.Id))
                {
                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        } 

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _protectionService.UnprotectOrder(order);
            if (ModelState.IsValid)
            {
                _protectionService.ProtectOrder(order);
                if (OrderExists(order.Id))
                {
                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    var entity = _context.Orders.Add(order).Entity;
                    await _context.SaveChangesAsync();
                    try
                    {
                        return CreatedAtAction("GetOrder", new { id = entity.Id }, entity);
                    }
                    catch(Exception e)
                    {
                        return NotFound(e.Message);
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }

        private bool OrderExists(int orderId)
        {
            return _context.Orders.Any(e => e.Id == orderId);
        }
    }
}
