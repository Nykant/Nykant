using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class GlsAddress
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string CountryIso { get; set; }
        public string Amount { get; set; }
    }
}
