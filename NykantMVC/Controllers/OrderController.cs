using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPatch]
        public async Task<IActionResult> PostShipping(Order order)
        {
            var response = await PatchRequest("Order/UpdateShipping", order);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Bag");
            }
            return Content("Failed");
        }
    }
}
