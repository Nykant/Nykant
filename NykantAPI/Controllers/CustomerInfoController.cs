using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NykantAPI.Data;
using NykantAPI.Models;

namespace NykantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomerInfos()
        {
            return await _context.CustomerInfos.ToListAsync();
        }

        // GET: api/CustomerInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfo>> GetCustomerInfo(int id)
        {
            var customerInfo = await _context.CustomerInfos.FindAsync(id);

            if (customerInfo == null)
            {
                return NotFound();
            }

            return customerInfo;
        }

        // PUT: api/CustomerInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerInfo(int id, CustomerInfo customerInfo)
        {
            if (id != customerInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> PostCustomerInfo(CustomerInfo customerInfo)
        {
            _context.CustomerInfos.Add(customerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerInfo", new { id = customerInfo.Id }, customerInfo);
        }

        // DELETE: api/CustomerInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerInfo>> DeleteCustomerInfo(int id)
        {
            var customerInfo = await _context.CustomerInfos.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            _context.CustomerInfos.Remove(customerInfo);
            await _context.SaveChangesAsync();

            return customerInfo;
        }

        private bool CustomerInfoExists(int id)
        {
            return _context.CustomerInfos.Any(e => e.Id == id);
        }
    }
}
