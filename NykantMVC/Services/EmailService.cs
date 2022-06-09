using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
//using System.Net.Mail;
using System.Threading.Tasks;

namespace NykantMVC.Services
{
    public class EmailService : IMailService
    {
        private readonly EmailSettings _mailSettings;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IProtectionService _protectionService;
        private readonly IHostEnvironment env;
        public readonly ILogger<EmailService> _logger;
        public EmailService(IOptions<EmailSettings> mailSettings, IRazorViewToStringRenderer razorViewToStringRenderer, IProtectionService protectionService, IHostEnvironment env, ILogger<EmailService> _logger)
        {
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _mailSettings = mailSettings.Value;
            _protectionService = protectionService;
            this.env = env;
            this._logger = _logger;
        }

        public async Task<string> SendOrderEmailAsync(Order order)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(order.PaymentCapture.Customer.Email));
                email.Subject = "Ordrebekræftelse";

                var bodyBuilder = new BodyBuilder();
                byte[] agreementBytes = System.IO.File.ReadAllBytes("wwwroot/pdf/Handelsbetingelser.pdf");
                byte[] regretBytes = System.IO.File.ReadAllBytes("wwwroot/pdf/standardfortrydelsesformular.pdf");
                bodyBuilder.Attachments.Add("Handelsbetingelser.pdf", agreementBytes, new MimeKit.ContentType("application", "pdf"));
                bodyBuilder.Attachments.Add("Standardfortrydelsesformular.pdf", regretBytes, new MimeKit.ContentType("application", "pdf"));
                //for (int i = 0; i < order.OrderItems.Count(); i++)
                //{
                //    var image = bodyBuilder.LinkedResources.Add(order.OrderItems[i].Product.Path);
                //    image.ContentId = MimeUtils.GenerateMessageId();
                //    order.OrderItems[i].ContentId = image.ContentId;
                //}
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/OrderEmail.cshtml", order);

                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }
        }

        public async Task<string> SendRegretEmailAsync(Regret regret)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(_mailSettings.Me));
                email.Subject = "Fortrydelse";

                var bodyBuilder = new BodyBuilder();
                //for (int i = 0; i < order.OrderItems.Count(); i++)
                //{
                //    var image = bodyBuilder.LinkedResources.Add(order.OrderItems[i].Product.Path);
                //    image.ContentId = MimeUtils.GenerateMessageId();
                //    order.OrderItems[i].ContentId = image.ContentId;
                //}
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/RegretEmail.cshtml", regret);

                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }
        }

        public async Task<string> SendOrderSentEmailAsync(Order order)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(order.PaymentCapture.Customer.Email));
                email.Subject = "Ordre Sendt";

                var bodyBuilder = new BodyBuilder();
                //for (int i = 0; i < order.OrderItems.Count(); i++)
                //{
                //    var image = bodyBuilder.LinkedResources.Add(order.OrderItems[i].Product.Path);
                //    image.ContentId = MimeUtils.GenerateMessageId();
                //    order.OrderItems[i].ContentId = image.ContentId;
                //}
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/OrderSentEmail.cshtml", order);

                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }

        }

        public async Task<string> SendDKIEmailAsync(Order order)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                if (env.IsDevelopment())
                {
                    email.To.Add(MailboxAddress.Parse(_mailSettings.Me));
                }
                else
                {
                    email.To.Add(MailboxAddress.Parse(_mailSettings.MailDKI));
                }
                email.Subject = "DKI Ordrebekræftelse";

                var bodyBuilder = new BodyBuilder();
                //for (int i = 0; i < order.OrderItems.Count(); i++)
                //{
                //    var image = bodyBuilder.LinkedResources.Add(order.OrderItems[i].Product.Path);
                //    image.ContentId = MimeUtils.GenerateMessageId();
                //    order.OrderItems[i].ContentId = image.ContentId;
                //}
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/DKIEmail.cshtml", order);

                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }
            
        }

        public async Task<string> SendNykantEmailAsync(Order order)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(_mailSettings.Me));
                email.Subject = "Nykant Ordrebekræftelse";

                var bodyBuilder = new BodyBuilder();
                //for (int i = 0; i < order.OrderItems.Count(); i++)
                //{
                //    var image = bodyBuilder.LinkedResources.Add(order.OrderItems[i].Product.Path);
                //    image.ContentId = MimeUtils.GenerateMessageId();
                //    order.OrderItems[i].ContentId = image.ContentId;
                //}
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/NykantOrderEmail.cshtml", order);

                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }
            
        }

        public async Task<string> SendInvoiceEmailAsync(PaymentCapture paymentCapture)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(paymentCapture.Customer.Email));
                email.Subject = "Faktura";
                var bodyBuilder = new BodyBuilder();
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/InvoiceEmail.cshtml", paymentCapture);
                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }
            
        }

        public async Task<string> SendRefundEmailAsync(PaymentCapture paymentCapture)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(paymentCapture.Customer.Email));
                email.Subject = "Refunderet";
                var bodyBuilder = new BodyBuilder();
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/RefundEmail.cshtml", paymentCapture);
                bodyBuilder.HtmlBody = body;
                email.Body = bodyBuilder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return "success";
            }
            catch (Exception e)
            {
                _logger.LogError($"time: {DateTime.Now} - {e.Message}");
                return "fail";
            }

        }

        //public async Task SendEmailAsync(SimpleMail simpleMail)
        //{
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
        //    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        //    email.To.Add(MailboxAddress.Parse("Christian@svinding.dk"));
        //    email.Subject = "Feedback";

        //    var bodyBuilder = new BodyBuilder();
        //    string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/EmailViews/ContactEmail.cshtml", simpleMail);

        //    bodyBuilder.HtmlBody = body;
        //    email.Body = bodyBuilder.ToMessageBody();

        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Username, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}
    }

    public interface IMailService
    {
        Task<string> SendOrderSentEmailAsync(Order order);
        Task<string> SendNykantEmailAsync(Order order);
        Task<string> SendOrderEmailAsync(Order order);
        Task<string> SendDKIEmailAsync(Order order);
        Task<string> SendInvoiceEmailAsync(PaymentCapture paymentCapture);
        Task<string> SendRegretEmailAsync(Regret regret);
        Task<string> SendRefundEmailAsync(PaymentCapture paymentCapture);
        //Task SendEmailAsync(SimpleMail simpleMail);
    }
}
