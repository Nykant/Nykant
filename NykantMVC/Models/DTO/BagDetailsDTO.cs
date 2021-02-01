using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.DTO
{
    public class BagDetailsDTO
    {
        public IEnumerable<BagItem> BagItems { get; set; }
        public int PriceSum { get; set; }
        public int BagId { get; set; }
    }
}
