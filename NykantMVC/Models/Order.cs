using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
