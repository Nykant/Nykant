using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NykantMVC.Models.Sitemap
{
    /// <summary>
    /// A class for creating XML Sitemaps (see http://www.sitemaps.org/protocol.html)
    /// </summary>
    public class SitemapGenerator : ISitemapGenerator
    {
        private static readonly XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
        private static readonly XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private static readonly XNamespace image = "http://www.google.com/schemas/sitemap-image/1.1";

        public XDocument GenerateSiteMap(IEnumerable<ISitemapItem> items)
        {
            //Ensure.Argument.NotNull(items, "items");

            var sitemap = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement(xmlns + "urlset",
                      new XAttribute("xmlns", xmlns),
                      new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                      new XAttribute(XNamespace.Xmlns + "image", image),
                      new XAttribute(xsi + "schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd"),
                      from item in items
                      select CreateItemElement(item)
                      )
                 );

            return sitemap;
        }

        public XElement CreateItemElement(ISitemapItem item)
        {
            var itemElement = new XElement(xmlns + "url", new XElement(xmlns + "loc", item.Url.ToLowerInvariant()));

            // all other elements are optional

            if (item.LastModified.HasValue)
                itemElement.Add(new XElement(xmlns + "lastmod", item.LastModified.Value.ToString("yyyy-MM-dd")));

            if (item.ChangeFrequency.HasValue)
                itemElement.Add(new XElement(xmlns + "changefreq", item.ChangeFrequency.Value.ToString().ToLower()));

            if (item.Priority.HasValue)
                itemElement.Add(new XElement(xmlns + "priority", item.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));

            if (item.Images != null)
            {
                if(item.Images.Count > 0)
                {
                    foreach(var img in item.Images)
                    {
                        var t = new XElement(image.GetName("image"), new XElement (image.GetName("loc"), img.Url), new XElement(image.GetName("title"), img.Title), new XElement(image.GetName("caption"), img.Caption));
                        itemElement.Add(t);
                    }
                }
            }
                

            return itemElement;
        }
    }
}
