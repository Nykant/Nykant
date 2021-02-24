using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Controllers
{
    [AllowAnonymous]
    public class EmailController : Controller
    {
        public async Task<IActionResult> SendSingleEmail([FromServices] IFluentEmail singleEmail)
        {
            // Using Razor templating package (or set using AddRazorRenderer in services)
            //Email.DefaultRenderer = new RazorRenderer();

            var template = "Dear @Model.Name, You are totally a @Model.Position.";
            var model = new
            {
                Name = "Christian",
                Position = "Developer",
                Message = "Hi Chris, this is an email message"
            };

            var email = Email
                .From("notedwow@hotmail.com")
                .To("nykant.development@gmail.com")
                .Subject("Razor template example")
                .UsingTemplate(template, model);

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
