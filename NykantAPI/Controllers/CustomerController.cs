using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class CustomerController : BaseController
    {
        private readonly IProtectionService _protectionService;
        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context, IProtectionService protectionService)
            : base(logger, context)
        {
            _protectionService = protectionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            try
            {
                var customerInf = await _context.Customer.Include(x => x.ShippingAddress).Include(x => x.BillingAddress).FirstOrDefaultAsync(x => x.Id == id);
                return Ok(JsonConvert.SerializeObject(customerInf, Extensions.JsonOptions.jsonSettings));
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customerInf)
        {
            try
            {
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
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShippingAddress>> PostShippingAddress(ShippingAddress shippingAddress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ShippingAddressExists(shippingAddress.Id))
                    {
                        _context.ShippingAddress.Update(shippingAddress);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    else
                    {
                        _context.ShippingAddress.Add(shippingAddress);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BillingAddress>> PostBillingAddress(BillingAddress billingAddress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (InvoiceAddressExists(billingAddress.Id))
                    {
                        _context.BillingAddress.Update(billingAddress);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    else
                    {
                        _context.BillingAddress.Add(billingAddress);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }

                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
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
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return BadRequest();
            }

        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }

        private bool ShippingAddressExists(int id)
        {
            return _context.ShippingAddress.Any(e => e.Id == id);
        }

        private bool InvoiceAddressExists(int id)
        {
            return _context.BillingAddress.Any(e => e.Id == id);
        }
    }
}
