using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Cookie
    {
        public string Name { get; set; }
        public CookieType1 Type { get; set; }
        public CookieType2 Type2 { get; set; }
        public CookieCategory Category { get; set; }
        public string Description { get; set; }
    }

    public enum CookieCategory
    {
        Essential,
        Functional,
        Performance,
        Advertising
    }
    public enum CookieType1
    {
        Session,
        Persistent
    }
    public enum CookieType2
    {
        FirstParty,
        ThirdParty
    }
}
