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
using Stripe;

namespace NykantAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]/")]
    public class CustomerInfoController : BaseController
    {
        public CustomerInfoController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }



        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> PostCustomerInfo(CheckoutDTO checkoutDTO)
        {
            try
            {
                if (!CustomerInfoExists(checkoutDTO.CustomerInfo.Email))
                {
                    await _context.CustomerInfos.AddAsync(checkoutDTO.CustomerInfo);
                }
                try
                {
                    var result = _context.Orders.Add(checkoutDTO.Order);
                    await _context.SaveChangesAsync();
                    var item = result.Entity;

                    foreach (var bagItem in checkoutDTO.BagItems)
                    {
                        Models.OrderItem orderItem = new Models.OrderItem
                        {
                            ProductId = bagItem.ProductId,
                            OrderId = item.Id,
                            Quantity = checkoutDTO.BagItems.Count()
                        };
                        await _context.OrderItems.AddAsync(orderItem);
                    }
                    await _context.SaveChangesAsync();

                    return Ok();
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }

        private bool CustomerInfoExists(string email)
        {
            return _context.CustomerInfos.Any(e => e.Email == email);
        }
    }
}
