﻿using System;
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

        [HttpGet("{email}")]
        public async Task<ActionResult<Customer>> GetCustomer(string email)
        {
            return Ok(JsonConvert.SerializeObject(await _context.Customers.FindAsync(email)));
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (CustomerExists(customer.Email))
                {
                    _context.Customers.Update(customer);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    var entity = _context.Customers.Add(customer).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetCustomer", new { email = entity.Email }, customer);
                }
            }
            else
            {
                return NotFound();
            }
        }

        private bool CustomerExists(string email)
        {
            return _context.Customers.Any(e => e.Email == email);
        }
    }
}
