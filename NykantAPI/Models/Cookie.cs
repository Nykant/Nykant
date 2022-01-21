using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Cookie
    {
        [Key]
        public string Name { get; set; }
        public CookieType1 Type1 { get; set; }
        public CookieType2 Type2 { get; set; }
        public CookieCategory Category { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
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
