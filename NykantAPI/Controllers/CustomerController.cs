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
        public async Task<ActionResult<CustomerInf>> GetCustomer(int id)
        {
            var customerInf = await _context.CustomerInfs.FindAsync(id);
            customerInf = _protectionService.ProtectCustomerInf(customerInf);
            return Ok(JsonConvert.SerializeObject(customerInf));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerInf>> PostCustomer(CustomerInf customerInf)
        {
            customerInf = _protectionService.UnProtectCustomerInf(customerInf);
            Console.WriteLine("unprotected customerinf");
            if (ModelState.IsValid)
            {
                Console.WriteLine("ModelState Is Valid yes");
                if (CustomerExists(customerInf.Id))
                {
                    Console.WriteLine("Customer Exists");
                    _context.CustomerInfs.Update(customerInf);
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Saved changes");
                    return Ok();
                }
                else
                {
                    Console.WriteLine("Customer doesnt Exists");
                    var entity = _context.CustomerInfs.Add(customerInf).Entity;
                    await _context.SaveChangesAsync();
                    Console.WriteLine("Saved changes");
                    return CreatedAtAction("GetCustomer", new { id = entity.Id }, customerInf);
                }
            }
            else
            {
                Console.WriteLine("Modelstate invalid");
                return Content("couldnt unprotect it");
            }
        }

        [HttpDelete("{customerInfId}")]
        public async Task<ActionResult<CustomerInf>> DeleteCustomerInf(int customerInfId)
        {
            try
            {
                _context.CustomerInfs.Remove(await _context.CustomerInfs.FindAsync(customerInfId));
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
            return _context.CustomerInfs.Any(e => e.Id == id);
        }
    }
}
