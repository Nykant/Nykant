using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NykantMVC.Models.Sitemap
{
    public interface ISitemapGenerator
    {
        XDocument GenerateSiteMap(IEnumerable<ISitemapItem> items);
    }
}
