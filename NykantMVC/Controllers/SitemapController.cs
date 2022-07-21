using Microsoft.AspNetCore.Mvc;
using NykantMVC.Extensions;
using NykantMVC.Friends;
using NykantMVC.Models.Sitemap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NykantMVC.Models;

namespace NykantMVC.Controllers
{
    public class SitemapController : Controller
    {
        private readonly Urls urls;
        public SitemapController(IOptions<Urls> urls)
        {
            this.urls = urls.Value;
        }

        // GET: Sitemap
        public ActionResult Index()
        {
            var sitemapItems = new List<SitemapItem> {
            // Home
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, Url.Action("index", "home")), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, Url.Action("about", "home")), changeFrequency: SitemapChangeFrequency.Monthly, priority: 0.7, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, Url.Action("contact", "home")), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: new DateTime(2022, 07, 21)),
            //new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "cookiepolitik"), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: new DateTime(2022, 07, 21)),
            //new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "persondatapolitik"), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: new DateTime(2022, 07, 21)),
            //new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "handelsbetingelser"), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/handlevejledning"), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: new DateTime(2022, 07, 21)),
            // Bag
            //new SitemapItem(PathUtils.CombinePaths(urls.Mvc, Url.Action("Details", "Bag")), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: new DateTime(2022, 07, 21)),
            // Product
            // landing pages
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkter"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkter/tøjstativer"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkter/borde"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkter/hylder"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkter/bænke"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkter/bøjler"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: new DateTime(2022, 07, 21)),
            //bøjler
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bøjle-Egetræ-Naturolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bøjle-Egetræ-Sortolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bøjle-Egetræ-Hvidolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            // hylder
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Hvidolie-40cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Sortolie-40cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Naturolie-40cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Hvidolie-60cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Sortolie-60cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Naturolie-60cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Hvidolie-80cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Sortolie-80cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Naturolie-80cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Hvidolie-100cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Sortolie-100cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Hylde-Egetræ-Naturolie-100cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            // borde
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bord-Egetræ-Naturolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bord-Egetræ-Hvidolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            // bænk
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bænk-Egetræ-Naturolie-115cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bænk-Egetræ-Hvidolie-115cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bænk-Egetræ-Sortolie-115cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bænk-Egetræ-Naturolie-170cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bænk-Egetræ-Hvidolie-170cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Bænk-Egetræ-Sortolie-170cm"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            // opbevaringsbænk
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Opbevaringsbænk-Egetræ-Naturolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Opbevaringsbænk-Egetræ-Hvidolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Opbevaringsbænk-Egetræ-Sortolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            // tøjstativ
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Tøjstativ-Egetræ-Naturolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Tøjstativ-Egetræ-Hvidolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Tøjstativ-Egetræ-Sortolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            // hænge tøhjstatuiv
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Ophængt-Tøjstativ-Egetræ-Naturolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Ophængt-Tøjstativ-Egetræ-Hvidolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            new SitemapItem(PathUtils.CombinePaths(urls.Mvc, "/produkt/Ophængt-Tøjstativ-Egetræ-Sortolie"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 0.9, lastModified: new DateTime(2022, 07, 21)),
            };

            return new SitemapResult(sitemapItems);
        }
    }
}
