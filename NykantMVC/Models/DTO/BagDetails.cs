using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.DTO
{
    public class BagDetails
    {
        public IEnumerable<BagItem> BagItems { get; set; }
        public int PriceSum { get; set; }
        public string BagId { get; set; }
    }
}
