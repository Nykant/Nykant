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

namespace NykantAPI.Controllers
{
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpPost("api/{controller}/{action}")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        //[HttpPatch("api/{controller}/{action}")]
        //public async Task<ActionResult<Order>> UpdateBagItem(Order order)
        //{
        //    if (OrderExists(order.Id))
        //    {
        //        var bagItem = await _context.BagItems.FirstOrDefaultAsync(x => x.Subject == subject && x.ProductId == productId);

        //        try
        //        {
        //            bagItem.Quantity = productQuantity;
        //            _context.BagItems.Update(bagItem);
        //            await _context.SaveChangesAsync();
        //            return Ok();
        //        }
        //        catch (Exception e)
        //        {
        //            return NotFound(e);
        //        }
        //    }
        //    return NotFound();
        //}

        private bool OrderExists(int orderId)
        {
            return _context.Orders.Any(e => e.Id == orderId);
        }
    }
}
