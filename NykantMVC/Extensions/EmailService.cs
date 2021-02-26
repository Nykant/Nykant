using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Extensions
{
    public class EmailService : IMailService
    {
        private readonly EmailSettings _mailSettings;
        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            var image = builder.LinkedResources.Add(@"C:\Users\Christian\Documents\GitHub\Nykant\NykantMVC\wwwroot\images\gyngestol.jpg");
            image.ContentId = MimeUtils.GenerateMessageId();

            try
            {
                builder.HtmlBody = string.Format(@"<img src=""cid:{0}"" />", image.ContentId) ;
                //builder.HtmlBody = string.Format(mailRequest.Body, image.ContentId);
            }
            catch(Exception e)
            {

            }

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
