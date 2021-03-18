using System.Collections.Generic;

namespace NykantMVC.Models.ViewModels
{
    public class BagVM
    {
        public List<BagItem> BagItems { get; set; }
        public int PriceSum { get; set; }
    }
}
