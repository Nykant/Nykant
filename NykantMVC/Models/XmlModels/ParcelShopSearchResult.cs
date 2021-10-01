using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NykantMVC.Models.XmlModels
{
    [XmlRoot(Namespace = "http://gls.dk/webservices/")]
    public class ParcelShopSearchResult
    {
        [XmlArray(ElementName = "parcelshops")]
        public PakkeshopData[] parcelshops { get; set; }
    }
}
