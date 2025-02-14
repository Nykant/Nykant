﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantAPI.Data;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace NykantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]/")]
    public class OrderItemController : BaseController
    {
        public OrderItemController(ILogger<OrderItemController> logger, ApplicationDbContext _context)
                    : base(logger, _context)
        {

        }


        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItems(List<OrderItem> orderItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in orderItem)
                    {
                        _context.OrderItems.Add(item);
                    }
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}, {e.InnerException}, {e.StackTrace}, {e.TargetSite}");
                return BadRequest();
            }
        }
    }
}
