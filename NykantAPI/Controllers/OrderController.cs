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

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : BaseController
    {
        public OrderController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpPatch]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            try
            {
                var orderDB = await _context.Orders.FirstOrDefaultAsync(x => x.CustomerInfoEmail == order.CustomerInfoEmail && x.Status == Status.Created);
                if(order.Status != 0)
                orderDB.Status = order.Status;
                if(order.Valuta != null)
                orderDB.Valuta = order.Valuta;
                if(order.ShippingOptionName != null)
                orderDB.ShippingOptionName = order.ShippingOptionName;
                if(order.PIClientSecret != null)
                orderDB.PIClientSecret = order.PIClientSecret;

                _context.Orders.Update(orderDB);
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
