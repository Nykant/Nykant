using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.Facebook
{
    public class FacebookSession
    {
        public string AccessToken { get; set; }
        public Feed Feed { get; set; }
    }
}
