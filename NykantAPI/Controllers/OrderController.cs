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

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]/")]
    public class OrderController : BaseController
    {
        public OrderController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            return Ok(JsonConvert.SerializeObject(orders));
        }

        [HttpGet("{subject}")]
        public async Task<ActionResult<List<Order>>> GetOrders(string subject)
        {
            var orders = _context.Orders.Where(x => x.Subject == subject);

            return Ok(JsonConvert.SerializeObject(orders));
        }

        [HttpPatch]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
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
            if (ModelState.IsValid)
            {
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return Ok(JsonConvert.SerializeObject(await _context.Orders.FindAsync(id)));
        }

        private bool OrderExists(int orderId)
        {
            return _context.Orders.Any(e => e.Id == orderId);
        }
    }
}
