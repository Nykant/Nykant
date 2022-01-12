using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
