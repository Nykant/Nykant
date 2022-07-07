using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NykantMVC.Extensions;
using NykantMVC.Models;
using Microsoft.Extensions.Logging;

namespace NykantMVC.Services
{
    public class GoogleAnalyticsTagHelperComponent : TagHelperComponent
    {
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<GoogleAnalyticsTagHelperComponent> logger;

        public GoogleAnalyticsTagHelperComponent(IOptions<GoogleAnalyticsOptions> googleAnalyticsOptions, IHttpContextAccessor httpContextAccessor, ILogger<GoogleAnalyticsTagHelperComponent> logger)
        {
            _googleAnalyticsOptions = googleAnalyticsOptions.Value;
            _httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
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
                        //.AppendHtml("<script>window.dataLayer = window.dataLayer || [];function gtag(){dataLayer.push(arguments);}gtag('consent', 'default', { 'ad_storage': 'granted', 'analytics_storage': 'granted' });</script>")
                        //.AppendHtml("<script async src='https://www.googletagmanager.com/gtag/js?id=")
                        //.AppendHtml(trackingCode)
                        //.AppendHtml("'></script><script>window.dataLayer=window.dataLayer||[];function gtag(){dataLayer.push(arguments);}gtag('js',new Date());gtag('config','")
                        //.AppendHtml(trackingCode)
                        //.AppendHtml("', { 'anonymize_ip': true }); gtag('config', 'AW-10853506642');</script>");

                        .AppendHtml("<script async src='https://www.googletagmanager.com/gtag/js?id=")
                        .AppendHtml(trackingCode)
                        .AppendHtml("'></script><script>window.dataLayer=window.dataLayer||[];function gtag(){dataLayer.push(arguments);}gtag('js',new Date());gtag('config','")
                        .AppendHtml(trackingCode)
                        .AppendHtml("');</script>");
                    }
                }
            }
            catch (Exception e)
            {
                logger.LogError($"time: {DateTime.Now} - {e.Message}");
            }
        }
    }

    public class GoogleAnalyticsOptions
    {
        public string TrackingCode { get; set; }
    }
}
