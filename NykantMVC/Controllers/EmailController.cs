using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NykantMVC.Extensions;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using NykantMVC.Models.ViewModels;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class EmailController : BaseController
    {
        private readonly IMailService mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        public EmailController(IMailService mailService, ILogger<BaseController> logger, IRazorViewToStringRenderer razorViewToStringRenderer) : base(logger)
        {
            this.mailService = mailService;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        public async Task<IActionResult> SendEmail()
        {
            var confirmAccountModel = new ConfirmAccountEmailViewModel($"https://localhost/5002/" + Guid.NewGuid());

            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmail.cshtml", confirmAccountModel);
            try
            {
                var request = new EmailRequest
                {
                    ToEmail = "notedwow@hotmail.com",
                    Body = body,
                    Subject = "test"
                };

                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //private void SendEmail(List<string> toAddresses, string fromAddress, string subject, string body)
        //{
        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("SenderFirstName SenderLastName", fromAddress));
        //    foreach (var to in toAddresses)
        //    {
        //        message.To.Add(new MailboxAddress("RecipientFirstName RecipientLastName", to));
        //    }
        //    message.Subject = subject;

        //    message.Body = new TextPart(TextFormat.Html)
        //    {
        //        Text = body
        //    };

        //    using var client = new SmtpClient
        //    {
        //        // For demo-purposes, accept all SSL certificates
        //        ServerCertificateValidationCallback = (_, _, _, _) => true
        //    };

        //    client.Connect("127.0.0.1", 25, false);

        //    client.Send(message);
        //    client.Disconnect(true);
        //}

        public async Task<IActionResult> SendSingleEmail([FromServices] IFluentEmail singleEmail)
        {

            //var template = @"@{ Layout = ""/Views/Shared/_Layout2.cshtml""; }";

            var template = "@foreach(var item in @Model){ <img src='/images/Finback-Chairs1-1280x853-c-default.jpg' editable='true' label='Image' width='130' height='130'> }";

            var bagItems = HttpContext.Session.Get<List<BagItem>>(BagSessionKey);

            var email = singleEmail
                .To("notedwow@hotmail.com")
                .Subject("Razor template example")
                .UsingTemplate(template, bagItems);

            await email.SendAsync();

            return Ok();
        }

        public async Task<IActionResult> SendMultipleEmail([FromServices] IFluentEmailFactory emailFactory)
        {
            var email1 = emailFactory
                .Create()
                .To("nykant.development@gmail.com")
                .Subject("Test email 1")
                .Body("This is the first email");

            await email1.SendAsync();

            var email2 = emailFactory
                .Create()
                .To("nykant.development@gmail.com")
                .Subject("Test email 2")
                .Body("This is the second email");

            await email2.SendAsync();

            return Ok();
        }
    }
}
