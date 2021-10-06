using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;
using NykantMVC.Services;
using System.Text.Encodings.Web;

namespace NykantMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class EmailController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        public EmailController(IMailService mailService, ILogger<BaseController> logger, IRazorViewToStringRenderer razorViewToStringRenderer, IOptions<Urls> urls, HtmlEncoder htmlEncoder) : base(logger, urls, htmlEncoder)
        {
            this.mailService = mailService;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        //public async Task<IActionResult> SendEmail()
        //{
        //    var confirmAccountModel = new ConfirmAccountEmailViewModel($"https://localhost/5002/" + Guid.NewGuid());

        //    string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmail.cshtml", confirmAccountModel);

        //    var request = new EmailRequest
        //    {
        //        ToEmail = "notedwow@hotmail.com",
        //        Body = body,
        //        Subject = "test"
        //    };

        //    await mailService.SendEmailAsync(request);

        //    return NoContent();
        //}

        //public async Task<IActionResult> SendSingleEmail([FromServices] IFluentEmail singleEmail)
        //{

        //    //var template = @"@{ Layout = ""/Views/Shared/_Layout2.cshtml""; }";

        //    var template = "@foreach(var item in @Model){ <img src='/images/Finback-Chairs1-1280x853-c-default.jpg' editable='true' label='Image' width='130' height='130'> }";

        //    var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

        //    var email = singleEmail
        //        .To("notedwow@hotmail.com")
        //        .Subject("Razor template example")
        //        .UsingTemplate(template, bagItems);

        //    await email.SendAsync();

        //    return Ok();
        //}

        //public async Task<IActionResult> SendMultipleEmail([FromServices] IFluentEmailFactory emailFactory)
        //{
        //    var email1 = emailFactory
        //        .Create()
        //        .To("nykant.development@gmail.com")
        //        .Subject("Test email 1")
        //        .Body("This is the first email");

        //    await email1.SendAsync();

        //    var email2 = emailFactory
        //        .Create()
        //        .To("nykant.development@gmail.com")
        //        .Subject("Test email 2")
        //        .Body("This is the second email");

        //    await email2.SendAsync();

        //    return Ok();
        //}
    }
}
