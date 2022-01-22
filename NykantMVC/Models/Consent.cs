using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Consent
    {
        public bool OnlyEssential { get; set; } = true;
        public bool ShowBanner { get; set; } = true;
        public bool Functional { get; set; } = false;
        public bool Statistics { get; set; } = false;
    }
}
