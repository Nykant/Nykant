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
    [Route("[controller]/[action]/")]
    public class CustomerController : BaseController
    {
        public CustomerController(ILogger<BaseController> logger, ApplicationDbContext context)
            : base(logger, context)
        {
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (!CustomerExists(customer.Email))
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return CreatedAtAction("PostCustomerInfo", customer);
            }
            return Ok();
        }

        private bool CustomerExists(string email)
        {
            return _context.Customers.Any(e => e.Email == email);
        }
    }
}
