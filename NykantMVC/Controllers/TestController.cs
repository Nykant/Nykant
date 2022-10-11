using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NykantMVC.Models;
using NykantMVC.Services;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Roles = "Admin")]
    public class TestController : BaseController
    {
        private readonly IRazorViewToStringRenderer razorViewToStringRenderer;
        public TestController(ILogger<BaseController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService, IRazorViewToStringRenderer razorViewToStringRenderer) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
            this.razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [HttpGet]
        public async Task<IActionResult> Pdf()
        {
            return View();
        }

        [HttpGet]
        public async Task SendPdfToS3()
        {
            var viewString = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/TestOrderEmail.cshtml", new { });
            await razorViewToStringRenderer.PdfSharpConvert(viewString, "TestFaktura");
        }

        [HttpPost]
        public async Task MakeInvoiceForPaymentCapture(int paymentCaptureId)
        {
            var json = await GetRequest($"/PaymentCapture/GetPaymentCapture/{paymentCaptureId}");
            PaymentCapture paymentCapture = JsonConvert.DeserializeObject<PaymentCapture>(json);

            Models.Invoice invoice = new Models.Invoice
            {
                CreatedAt = paymentCapture.Order.CreatedAt,
                PaymentCaptureId = paymentCapture.Id,
                TotalPrice = paymentCapture.Order.TotalPrice,
                TaxLessPrice = paymentCapture.Order.TaxLessPrice,
                Taxes = paymentCapture.Order.Taxes
            };

            var response = await PostRequest("/Invoice/PostInvoice", invoice);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"time: {DateTime.Now} - error: {response.StatusCode + response.ReasonPhrase}");
            }
            json = await GetRequest(response.Headers.Location.AbsolutePath);
            invoice = JsonConvert.DeserializeObject<Models.Invoice>(json);
            paymentCapture.Invoice = invoice;

            var fileName = "Faktura-" + invoice.Id;
            var viewString = await razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/InvoiceEmail.cshtml", paymentCapture);
            await razorViewToStringRenderer.PdfSharpConvert(viewString, fileName);
        }

    }
}
