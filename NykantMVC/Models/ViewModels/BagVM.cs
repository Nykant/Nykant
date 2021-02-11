using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Models.ViewModels
{
    public class BagVM
    {
        public List<BagItem> BagItems { get; set; }
        public int PriceSum { get; set; }
    }
}
