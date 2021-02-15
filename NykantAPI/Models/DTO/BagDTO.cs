using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models.DTO
{
    public class BagDTO
    {
        public List<BagItem> BagItems { get; set; }
        public int PriceSum { get; set; }
    }
}
