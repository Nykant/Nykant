using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
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
    public class CustomerController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public CustomerController(ILogger<BaseController> logger, ApplicationDbContext context, IProtectionService protectionService)
            : base(logger, context)
        {
            _protectionService = protectionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customerInf = await _context.Customer.FindAsync(id);
            customerInf = _protectionService.ProtectCustomer(customerInf);
            return Ok(JsonConvert.SerializeObject(customerInf));
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customerInf)
        {
            try
            {
                customerInf = _protectionService.UnProtectCustomer(customerInf);
                if (ModelState.IsValid)
                {
                    if (CustomerExists(customerInf.Id))
                    {
                        _context.Customer.Update(customerInf);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    else
                    {

                        var entity = _context.Customer.Add(customerInf).Entity;
                        await _context.SaveChangesAsync();

                        return CreatedAtAction("GetCustomer", new { id = entity.Id }, customerInf);
                    }
                }
                return Content("error");
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return Content(e.Message);
            }
        }

        [HttpDelete("{customerInfId}")]
        public async Task<ActionResult<Customer>> DeleteCustomerInf(int customerInfId)
        {
            try
            {
                _context.Customer.Remove(await _context.Customer.FindAsync(customerInfId));
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
