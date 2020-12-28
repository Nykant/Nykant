using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Models
{
    [Serializable]
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Token { get; set; }
    }
}
