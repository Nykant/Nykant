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

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInf>> GetCustomer(int id)
        {
            return Ok(JsonConvert.SerializeObject(await _context.CustomerInfs.FindAsync(id)));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerInf>> PostCustomer(CustomerInf customer)
        {
            if (ModelState.IsValid)
            {
                if (CustomerExists(customer.Id))
                {
                    _context.CustomerInfs.Update(customer);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    var entity = _context.CustomerInfs.Add(customer).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetCustomer", new { id = entity.Id }, customer);
                }
            }
            else
            {
                return NotFound();
            }
        }

        private bool CustomerExists(int id)
        {
            return _context.CustomerInfs.Any(e => e.Id == id);
        }
    }
}
