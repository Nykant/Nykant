using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class PaymentController : BaseController
    {
        private IConfigurationRoot _configuration; 
        public PaymentController(ILogger<BaseController> logger, IConfiguration configuration) : base(logger)
        {
            _configuration = (IConfigurationRoot)configuration;
        }

        [HttpGet]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PaymentSuccess(string email)
        {
            ViewBag.Email = email;

            Models.Order order = new Models.Order
            {
                CustomerInfoEmail = email,
                Status = Status.Accepted
            };

            var response = await PatchRequest("Order/UpdateOrder", order);

            if (response.IsSuccessStatusCode)
            {
                return View();
            }
            return Content("Failed to Accept order");
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaymentIntent([FromBody] PaymentIntentCreateRequest request)
        {
            StripeConfiguration.ApiKey = _configuration["StripeTESTKey"];

            var customers = new CustomerService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Name = request.Customer.Name,
                Email = request.Customer.Email,
                Phone = request.Customer.Phone,
                Address = new AddressOptions
                {
                    Line1 = request.Customer.Address,
                    City = request.Customer.City,
                    Country = request.Customer.Country,
                    PostalCode = request.Customer.Postal
                },
            });

            var options = new PaymentIntentCreateOptions
            {
                Customer = customer.Id,
                Amount = request.Price.Amount,
                Currency = "dkk",
                Metadata = new Dictionary<string, string>
                {
                    { "integration_check", "accept_a_payment" },
                },
            };

            var url = $"BagItem/DeleteBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}";
            var deleteRequest = await DeleteRequest(url);

            if (!deleteRequest.IsSuccessStatusCode)
            {
                return NotFound(deleteRequest.StatusCode);
            }

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }
        private int CalculateOrderAmount(BagItem[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 1400;
        }
        public class PaymentIntentCreateRequest
        {
            [JsonProperty("Price")]
            public Models.JsonModels.Price Price { get; set; }
            [JsonProperty("Customer")]
            public Models.JsonModels.Customer Customer { get; set; }
            [JsonProperty("Shipping")]
            public Models.JsonModels.Shipping Shipping { get; set; }
        }

    }
}
