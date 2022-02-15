using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class CookieConsent
    {
        public bool OnlyEssential { get; set; } = true;
        public bool ShowBanner { get; set; } = true;
        public bool NonEssential { get; set; } = false;
    }
}
