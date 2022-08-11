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
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using NykantMVC.Services;
using System.Text.Encodings.Web;
using System.Security.Policy;

namespace NykantMVC.Controllers
{
    public class SitemapController : BaseController
    {
        public SitemapController(ILogger<SitemapController> logger, IOptions<Urls> urls, HtmlEncoder htmlEncoder, IConfiguration conf, ITokenService _tokenService) : base(logger, urls, htmlEncoder, conf, _tokenService)
        {
        }

        // GET: Sitemap
        public async Task<IActionResult> Index()
        {
            var json = await GetRequest("/Product/GetProducts");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            json = await GetRequest("/Category/GetCategories");
            var categories = JsonConvert.DeserializeObject<List<Category>>(json);

            var date = new DateTime(2022, 08, 11);

            var sitemapItems = new List<SitemapItem> {
            // Home
            new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, Url.Action("index", "home")), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: date),
            new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, Url.Action("about", "home")), changeFrequency: SitemapChangeFrequency.Monthly, priority: 0.7, lastModified: date),
            new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, Url.Action("contact", "home")), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: date),
            new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, Url.Action("howtoorder", "home")), changeFrequency: SitemapChangeFrequency.Yearly, priority: 0.4, lastModified: date),
            new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, "/Møbler"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: date)

            };

            //categories
            foreach (var cat in categories)
            {
                sitemapItems.Add(new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, $"/Møbler/{cat.Name}"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: date));
            }

            //produkter
            foreach (var prod in products)
            {
                var images = new List<string>();
                foreach(var img in prod.Images)
                {
                    if(img.ImageType == ImageType.DetailsFullscreen)
                    {
                        images.Add($"{_urls.Mvc}/{img.Source}");
                    }
                }
                sitemapItems.Add(new SitemapItem(PathUtils.CombinePaths(_urls.Mvc, $"/Møbler/{prod.Category.Name}/{prod.UrlName}"), changeFrequency: SitemapChangeFrequency.Weekly, priority: 1.0, lastModified: date, image: images));
            }

            return new SitemapResult(sitemapItems);
        }
    }
}
