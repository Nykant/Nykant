using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantIS.Models.Email
{
    public class ResetPasswordEmailModel
    {
        public ResetPasswordEmailModel(string url)
        {
            ResetPasswordUrl = url;
        }

        public string ResetPasswordUrl { get; set; }
    }
}
