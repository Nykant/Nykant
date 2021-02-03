using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;


namespace NykantMVC.Models
{
    public class Bag
    {
        [Key]
        public int BagId { get; set; }
        public string Subject { get; set; }
        public IEnumerable<BagItem> BagItems { get; set; }
    }

}
