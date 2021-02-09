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
    public class CustomerInfoController : BaseController
    {
        public CustomerInfoController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpPost("api/{controller}/{action}/{customerInfo}")]
        public async Task<ActionResult<CustomerInfo>> PostCustomerInfo(CustomerInfo customerInfo)
        {
            try
            {
                _context.CustomerInfos.Add(customerInfo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound(e);
            }
        }

        private bool CustomerInfoExists(int id)
        {
            return _context.CustomerInfos.Any(e => e.Id == id);
        }
    }
}
