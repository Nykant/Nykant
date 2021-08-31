using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantIS.Models.ViewModels
{
    public class UrlEmailModel
    {
        public UrlEmailModel(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
