using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NykantMVC.Extensions;
using NykantMVC.Models;

namespace NykantMVC.Services
{
    public class GoogleAnalyticsTagHelperComponent : TagHelperComponent
    {
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GoogleAnalyticsTagHelperComponent(IOptions<GoogleAnalyticsOptions> googleAnalyticsOptions, IHttpContextAccessor httpContextAccessor)
        {
            _googleAnalyticsOptions = googleAnalyticsOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var consent = _httpContextAccessor.HttpContext.Session.Get<Consent>("verysecretseriousconsentsessionkeyspecial");
            if(consent == null)
            {
                consent = new Consent { Statistics = false, Functional = false, OnlyEssential = true, ShowBanner = true };
                _httpContextAccessor.HttpContext.Session.Set<Consent>("verysecretseriousconsentsessionkeyspecial", consent);
            }
            if (consent.Statistics)
            {
                // Inject the code only in the head element
                if (string.Equals(output.TagName, "head", StringComparison.OrdinalIgnoreCase))
                {
                    // Get the tracking code from the configuration
                    var trackingCode = _googleAnalyticsOptions.TrackingCode;
                    if (!string.IsNullOrEmpty(trackingCode))
                    {
                        // PostContent correspond to the text just before closing tag
                        output.PostContent
                            .AppendHtml("<script async src='https://www.googletagmanager.com/gtag/js?id=")
                            .AppendHtml(trackingCode)
                            .AppendHtml("'></script><script>window.dataLayer=window.dataLayer||[];function gtag(){dataLayer.push(arguments)}gtag('js',new Date);gtag('config','")
                            .AppendHtml(trackingCode)
                            .AppendHtml("',{displayFeaturesTask:'null'});</script>");
                    }
                }
            }
        }
    }

    public class GoogleAnalyticsOptions
    {
        public string TrackingCode { get; set; }
    }
}
