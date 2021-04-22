using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using NykantIS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Amazon.SimpleEmail;
using Amazon;
using Amazon.SimpleEmail.Model;

namespace NykantIS.Services
{
    public class EmailService : IMailService
    {
        //private readonly EmailSettings _mailSettings;
        public EmailService(/*IOptions<EmailSettings> mailSettings*/)
        {
            //_mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(EmailRequest mailRequest)
        {
            // Replace USWest2 with the AWS Region you're using for Amazon SES.
            // Acceptable values are EUWest1, USEast1, and USWest2.
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.EUNorth1))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = "mail@nykant.dk",
                    Destination = new Destination
                    {
                        ToAddresses =
                        new List<string> { mailRequest.ToEmail }
                    },
                    Message = new Message
                    {
                        Subject = new Content(mailRequest.Subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = mailRequest.Body
                            }
                        }
                    },
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    //ConfigurationSetName = configSet
                };
                try
                {
                    Console.WriteLine("Sending email using Amazon SES...");
                    var response = client.SendEmailAsync(sendRequest);
                    Console.WriteLine("The email was sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);

                }
            }

            //Console.Write("Press any key to continue...");
            //Console.ReadKey();

            //var email = new MimeMessage();
            //email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            //email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            //email.Subject = mailRequest.Subject;
            //var builder = new BodyBuilder();
            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
            //builder.HtmlBody = mailRequest.Body;
            //email.Body = builder.ToMessageBody();

            //using var smtp = new SmtpClient();
            //smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            //await smtp.SendAsync(email);
            //smtp.Disconnect(true);
        }
    }
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
