using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Cookie
    {
        public string Name { get; set; }
        public CookieType1 Type1 { get; set; }
        public CookieType2 Type2 { get; set; }
        public CookieCategory Category { get; set; }
        public string Description { get; set; }
    }

    public enum CookieCategory
    {
        Necessary,
        Functional,
        Performance,
        Statistics
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
