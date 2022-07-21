using Microsoft.AspNetCore.Mvc;
using NykantMVC.Models.Sitemap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NykantMVC.Extensions
{
    public class SitemapResult : ActionResult
    {
        private readonly IEnumerable<ISitemapItem> items;
        private readonly ISitemapGenerator generator;

        public SitemapResult(IEnumerable<ISitemapItem> items) : this(items, new SitemapGenerator())
        {
        }

        public SitemapResult(IEnumerable<ISitemapItem> items, ISitemapGenerator generator)
        {

            this.items = items;
            this.generator = generator;
        }

        public override void ExecuteResult(ActionContext context)
        {
            var response = context.HttpContext.Response;
            Encoding unicode = Encoding.UTF8;

            response.ContentType = "text/xml; charset=utf-8";

            using (var writer = new XmlTextWriter(response.Body, unicode))
            {
                writer.Formatting = Formatting.Indented;
                var sitemap = generator.GenerateSiteMap(items);

                sitemap.WriteTo(writer);
            }
        }
    }
}
