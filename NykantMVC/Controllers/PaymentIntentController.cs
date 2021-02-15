using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantMVC.Extensions;
using NykantMVC.Models;
using NykantMVC.Models.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class PaymentIntentController : BaseController
    {
        private IConfigurationRoot _configuration; 
        public PaymentIntentController(ILogger<BaseController> logger, IConfiguration configuration) : base(logger)
        {
            _configuration = (IConfigurationRoot)configuration;
        }

        [HttpGet]
        public ActionResult GetCardInformation()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            CardInformation card = new CardInformation
            {
                Name = checkout.Shipping.FirstName,
                Email = checkout.Customer.Email,
                Address = checkout.Customer.Address,
                City = checkout.Customer.City,
                Country = checkout.Customer.Country,
                Phone = checkout.Customer.Phone,
                Postal = checkout.Customer.Postal
            };
            return Json(JsonConvert.SerializeObject(card));
        }

        public class CardInformation
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Postal { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaymentIntent()
        {
            var checkout = HttpContext.Session.Get<Checkout>(CheckoutSessionKey);
            StripeConfiguration.ApiKey = _configuration["StripeTESTKey"];

            var customers = new CustomerService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Name = checkout.Customer.FirstName + " " + checkout.Customer.LastName,
                Email = checkout.Customer.Email,
                Phone = checkout.Customer.Phone,
                Address = new AddressOptions
                {
                    Line1 = checkout.Customer.Address,
                    City = checkout.Customer.City,
                    Country = checkout.Customer.Country,
                    PostalCode = checkout.Customer.Postal
                },
            });

            var options = new PaymentIntentCreateOptions
            {
                Customer = customer.Id,
                Amount = CalculateOrderAmount(checkout.BagItems),
                Currency = "dkk",
                Metadata = new Dictionary<string, string>
                {
                    { "integration_check", "accept_a_payment" },
                },
            };

            PaymentIntentService service;
            PaymentIntent paymentIntent;
            try
            {
                service = new PaymentIntentService();
                paymentIntent = service.Create(options);
            }
            catch (StripeException e)
            {
                return NotFound(e.InnerException.Message);
            }

            var order = BuildOrder(checkout, paymentIntent);
            var createRequest = await PostRequest("Order/PostOrder", order);
            if (!createRequest.IsSuccessStatusCode)
            {
                return NotFound(createRequest.StatusCode);
            }

            var url = $"BagItem/DeleteBagItems/{User.Claims.FirstOrDefault(x => x.Type == "sub").Value}";
            var deleteRequest = await DeleteRequest(url);
            if (!deleteRequest.IsSuccessStatusCode)
            {
                return NotFound(deleteRequest.StatusCode);
            }

            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

        private Models.Order BuildOrder(Checkout checkout, PaymentIntent paymentIntent)
        {
            Models.Order order = new Models.Order
            {
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                CustomerEmail = checkout.Shipping.Email,
                PaymentIntent_Id = paymentIntent.Id,
                ShippingId = checkout.Shipping.ShippingId,
                Status = Status.Created,
                TotalPrice = CalculateOrderAmount(checkout.BagItems),
            };
            return order;
        }

        private int CalculateOrderAmount(List<BagItem> items)
        {
            int price = 0;
            foreach(var item in items)
            {
                price += item.Product.Price;
            }
            return price;
        }
    }
}
