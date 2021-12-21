using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;
using NykantMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Services
{
    public class EmailService : IMailService
    {
        private readonly EmailSettings _mailSettings;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IProtectionService _protectionService;
        public EmailService(IOptions<EmailSettings> mailSettings, IRazorViewToStringRenderer razorViewToStringRenderer, IProtectionService protectionService)
        {
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _mailSettings = mailSettings.Value;
            _protectionService = protectionService;
        }

        public async Task SendOrderEmailAsync(Customer customerInf, Order order)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(customerInf.Email));
            email.Subject = "Nykant Order";

            var bodyBuilder = new BodyBuilder();
            for (int i = 0; i < order.OrderItems.Count(); i++)
            {
                var image = bodyBuilder.LinkedResources.Add(order.OrderItems[i].Product.Path);
                image.ContentId = MimeUtils.GenerateMessageId();
                order.OrderItems[i].ContentId = image.ContentId;
            }
            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/OrderEmail.cshtml", order);

            bodyBuilder.HtmlBody = body;
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendEmailAsync(SimpleMail simpleMail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse("Christian@svinding.dk"));
            email.Subject = "Feedback";

            var bodyBuilder = new BodyBuilder();
            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/ContactEmail.cshtml", simpleMail);

            bodyBuilder.HtmlBody = body;
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }

    public interface IMailService
    {
        Task SendOrderEmailAsync(Customer customerInf, Order order);
        Task SendEmailAsync(SimpleMail simpleMail);
    }
}
