using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.Helpers
{
    public class MakeOrder
    {
        public List<BagItem> BagItems { get; set; }
        public int CustomerId { get; set; }
    }
}
