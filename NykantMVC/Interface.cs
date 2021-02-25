using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
