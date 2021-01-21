using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;


namespace NykantAPI.Models
{
    public class Bag
    {
        [Key]
        public string UserId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<BagItem> BagItems { get; set; }
    }

}
