using Google.Apis.ShoppingContent.v2_1.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Logging;
using Microsoft.Net.Http.Headers;
using NykantMVC.Data;
using NykantMVC.Models;
using NykantMVC.Services;
using Stripe;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Rewrite;
using NykantMVC.Extensions;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
namespace NykantMVC
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string mykeyConnection = Configuration.GetConnectionString("MyKeysConnection");

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<LocalMyKeysContext>(options =>
                    options.UseSqlServer(
                        mykeyConnection));

                services.AddDataProtection()
                    .PersistKeysToDbContext<LocalMyKeysContext>()
                    //.ProtectKeysWithCertificate("3fe5fcaf686e7ffbeaf80d760944e0f752f2112b")
                    .SetApplicationName("Nykant");
            }
            else
            {
                services.AddDbContext<MyKeysContext>(options =>
                    options.UseMySql(
                        mykeyConnection, ServerVersion.AutoDetect(mykeyConnection)));

                services.AddDataProtection()
                    .PersistKeysToDbContext<MyKeysContext>()
                    //.ProtectKeysWithCertificate("3fe5fcaf686e7ffbeaf80d760944e0f752f2112b")
                    .SetApplicationName("Nykant");
            }

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                 .AddCookie("Cookies", options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.Domain = "www.nykant.dk";
                    options.Cookie.IsEssential = true;
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = Configuration.GetValue<string>("Authority");
                    options.MetadataAddress = Configuration.GetValue<string>("MetadataAddress");
                    options.CallbackPath = "/signin-oidc";
                    options.SignedOutCallbackPath = "/signout-callback-oidc";

                    options.ClientId = "mvc";
                    options.ClientSecret = Configuration["MVCClientSecret"];
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("email");
                    options.Scope.Add("NykantAPI");
                    options.Scope.Add("offline_access");
                    options.Scope.Add("roles");
                    options.ClaimActions.MapJsonKey("role", "role", "role");
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("profile");
                    options.Scope.Add("openid");

                    options.CorrelationCookie = new CookieBuilder
                    {
                        HttpOnly = true,
                        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                        SecurePolicy = CookieSecurePolicy.Always,
                        IsEssential = true,
                        Domain = "www.nykant.dk"
                    };

                    options.NonceCookie = new CookieBuilder
                    {
                        HttpOnly = true,
                        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                        SecurePolicy = CookieSecurePolicy.Always,
                        IsEssential = true,
                        Domain = "www.nykant.dk"
                    };

                    options.ProtocolValidator = new OpenIdConnectProtocolValidator
                    {
                        RequireNonce = false,
                        RequireState = false,
                        RequireAuthTime = false,
                         RequireAmr = false,
                          RequireAcr = false,
                           RequireAzp = false,
                            RequireStateValidation = false,
                             RequireSub = false,
                               RequireTimeStampInNonce = false
                    };
                });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin Permission", policy => policy.RequireClaim("Permission", "admin"));
            //    options.AddPolicy("Raffle Permission", policy => policy.RequireClaim("Permission", "raffle"));
            //});


            if (!Environment.IsDevelopment())
            {
                services.AddHsts(options =>
                {
                    options.Preload = true;
                    options.IncludeSubDomains = true;
                    options.MaxAge = TimeSpan.FromDays(60);
                    options.ExcludedHosts.Add("nykant.dk");
                    options.ExcludedHosts.Add("static.nykant.dk");
                    options.ExcludedHosts.Add("www.nykant.dk");
                    options.ExcludedHosts.Add("Nykant-LB-2146644203.eu-north-1.elb.amazonaws.com");
                });

                //services.AddHttpsRedirection(options =>
                //{
                //    options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
                //    options.HttpsPort = 443;
                //});
            }


            if (!Environment.IsDevelopment())
            {
                services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromDays(30);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Name = "Session";
                    options.Cookie.IsEssential = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                });
                //    .AddStackExchangeRedisCache(options =>
                //{
                //    options.Configuration = "nykant-memcached.tylulq.cfg.eun1.cache.amazonaws.com:11211";
                //    options.InstanceName = "nykant-memcached";
                //});
            }
            else
            {
                services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromDays(30);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.Name = "Session";
                    options.Cookie.IsEssential = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                });
            }


            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddTransient<IMailService, EmailService>();

            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            services.AddScoped<IProtectionService, ProtectionService>();
            services.AddSingleton<IGoogleApiService, GoogleApiService>();

            services.AddSingleton<ITokenService, Services.TokenService>();

            //services.AddLocalization(options => {
            //    options.ResourcesPath = "Resources";
            //});

            if (Environment.IsDevelopment())
            {
                services.AddAntiforgery(options => {
                    options.Cookie.Name = "AntiforgeryToken";
                    options.HeaderName = "AntiforgeryToken";
                    options.FormFieldName = "AntiforgeryToken";
                    options.Cookie.Domain = "localhost";
                    options.Cookie.IsEssential = true;
                    options.Cookie.HttpOnly = true;
                });
            }
            else
            {
                services.AddAntiforgery(options => {
                    options.Cookie.Name = "AntiforgeryToken";
                    options.HeaderName = "AntiforgeryToken";
                    options.FormFieldName = "AntiforgeryToken";
                    options.Cookie.Domain = "www.nykant.dk";
                    options.Cookie.IsEssential = true;
                    options.Cookie.HttpOnly = true;
                });
            }

            //services.Configure<GzipCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Optimal;
            //});
            //services.Configure<BrotliCompressionProviderOptions>(options =>
            //{
            //    options.Level = CompressionLevel.Optimal;
            //});

            //services.AddResponseCompression(options =>
            //{
            //    options.EnableForHttps = true;

            //});


            services.AddResponseCaching();

            //services.AddWebOptimizer(options =>
            //{
            //    //options.AddCssBundle("/css/layout-bundle.css"
            //    //    , "/wwwroot/css/mvcstyle.css"
            //    //    , "/wwwroot/css/navbar.css"
            //    //    , "/wwwroot/css/search.css"
            //    //    , "/wwwroot/css/e-mark.css"
            //    //    , "/wwwroot/css/cookiebot.css"
            //    //    , "/wwwroot/css/front-page.css"
            //    //    , "/wwwroot/css/product-gallery.css"
            //    //    , "/wwwroot/css/product-details.css"
            //    //    , "/wwwroot/css/karusel.css"
            //    //    ).MinifyCss().UseContentRoot();

            //    //options.AddJavaScriptBundle("/JS/layout-head-bundle.js"
            //    //    , "/wwwroot/JS/AjaxAntiCSRF.js"
            //    //    , "/wwwroot/JS/logger.js"
            //    //    , "/wwwroot/lib/jquery/dist/jquery.min.js"
            //    //    , "/wwwroot/lib/ajax/jquery.unobtrusive-ajax.min.js"
            //    //    , "/wwwroot/lib/jquery-validation/dist/jquery.validate.js"
            //    //    , "/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"
            //    //    ).MinifyJavaScript().UseContentRoot();

            //    //options.AddJavaScriptBundle("/JS/layout-bottom-bundle.js"
            //    //    , "/wwwroot/JS/noop.js"
            //    //    , "/wwwroot/JS/mobileNav.js"
            //    //    , "/wwwroot/JS/search-button.js"
            //    //    ).MinifyJavaScript().UseContentRoot();

            //    //options.MinifyJsFiles();
            //});

            services.AddControllersWithViews()
                        //.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                        //.AddDataAnnotationsLocalization()
                        .AddXmlSerializerFormatters();

            services.AddHttpContextAccessor();

            // Register the Google Analytics configuration
            //services.Configure<GoogleAnalyticsOptions>(options => Configuration.GetSection("GoogleAnalytics").Bind(options));

            //// Register the TagHelperComponent
            //services.AddTransient<ITagHelperComponent, GoogleAnalyticsTagHelperComponent>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            //var DK = new CultureInfo("da-DK");
            //var EN = new CultureInfo("en-GB");
            //var cultureList = new List<CultureInfo>
            //{
            //    DK,
            //    EN
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(DK, DK),
            //    SupportedCultures = cultureList,
            //    SupportedUICultures = cultureList
            //});

            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(forwardOptions);

            var options = new RewriteOptions()
                .AddRedirectToProxiedHttps()
                .AddRedirect("(.*)/$", "$1")
                .AddRedirectToWwwPermanent();// remove trailing slash
            app.UseRewriter(options);

            app.UseCertificateForwarding();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/sitemap"))
                {
                    var syncIoFeature = context.Features.Get<IHttpBodyControlFeature>();
                    if (syncIoFeature != null)
                    {
                        syncIoFeature.AllowSynchronousIO = true;
                    }
                }

                await next();
            });

            IdentityModelEventSource.ShowPII = false;


            //app.UseResponseCompression();
            app.UseResponseCaching();
            //app.UseDefaultFiles();

            //app.UseStaticFiles(
            //    //new StaticFileOptions
            //    //{
            //    //    OnPrepareResponse =
            //    //r =>
            //    //{
            //    //    string name = r.File.Name;
            //    //    if (name.EndsWith(".png") || name.EndsWith(".svg") || name.EndsWith(".mp4") || name.EndsWith(".css") || name.EndsWith(".js") || name.EndsWith(".ico"))
            //    //    {
            //    //        TimeSpan maxAge = new TimeSpan(7, 0, 0, 0);
            //    //        r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
            //    //    }
            //    //}
            //    //}
            //    );

            app.UseRouting();

            //app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");


            });
        }
    }
}
