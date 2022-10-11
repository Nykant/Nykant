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
using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Wkhtmltopdf.NetCore;

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

        [Obsolete]
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

            //services.AddWkhtmltopdf("wwwroot/wkhtmltopdf");
            services.AddWkhtmltopdf(Path.GetFullPath("wkhtmltopdf"));

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                 .AddCookie("Cookies", options =>
                {
                    if (Environment.IsDevelopment())
                    {
                        options.Cookie.Domain = "localhost";
                    }
                    else
                    {
                        options.Cookie.Domain = "www.nykant.dk";
                    }
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

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
                        IsEssential = true
                    };
                    if (Environment.IsDevelopment())
                    {
                        options.CorrelationCookie.Domain = "localhost";
                    }
                    else
                    {
                        options.CorrelationCookie.Domain = "www.nykant.dk";
                    }

                    options.NonceCookie = new CookieBuilder
                    {
                        HttpOnly = true,
                        SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                        SecurePolicy = CookieSecurePolicy.Always,
                        IsEssential = true,
                        Domain = "www.nykant.dk"
                    };
                    if (Environment.IsDevelopment())
                    {
                        options.NonceCookie.Domain = "localhost";
                    }
                    else
                    {
                        options.NonceCookie.Domain = "www.nykant.dk";
                    }

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

            services.AddScoped<Services.IRazorViewToStringRenderer, Services.RazorViewToStringRenderer>();
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

            services.AddCsp(nonceByteAmount: 32);

            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy", p =>
                {
                    p.WithOrigins("https://r.stripe.com", "https://r.stripe.network", "https://www.nykant.dk/is", "https://localhost:5001", "https://localhost:5003", "https://www.nykant.dk/api").AllowAnyHeader().AllowAnyMethod();
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCsp(csp =>
            {
                csp.ByDefaultAllow
                    .FromSelf()
                    .From("https://static.nykant.dk");
                csp.AllowScripts
                    //.WithStrictDynamic()
                    .AddNonce()
                    .FromSelf()
                    .AllowUnsafeEval()
                    .From("https://static.nykant.dk")
                    .From("https://www.google-analytics.com")
                    .From("https://assets.emaerket.dk")
                    .From("https://kit.fontawesome.com")
                    .From("https://consentcdn.cookiebot.com")
                    .From("https://consent.cookiebot.com")
                    .From("https://widget.emaerket.dk")
                    .From("https://connect.facebook.net")
                    .From("https://www.facebook.com")
                    .From("https://www.googletagmanager.com")
                    .From("https://js.stripe.com")
                    .From("https://invitejs.trustpilot.com");
                csp.AllowStyles
                    .FromSelf()
                    .AllowUnsafeInline()
                    .From("https://static.nykant.dk")
                    .From("https://use.fontawesome.com")
                    .From("https://fonts.googleapis.com");
                csp.AllowImages
                    .FromSelf()
                    .From("https://www.google-analytics.com")
                    .From("https://www.google.com")
                    .From("https://www.facebook.com")
                    .From("https://hooks.stripe.com")
                    .From("https://www.credit-card-logos.com")
                    .From("https://www.googletagmanager.com")
                    .From("https://www.google.dk")
                    .From("https://static.nykant.dk")
                    .From("data:")
                    .From("http://www.w3.org/2000/svg");
                csp.AllowFonts
                    .FromSelf()
                    .From("https://static.nykant.dk")
                    .From("https://ka-f.fontawesome.com")
                    .From("https://use.fontawesome.com")
                    .From("https://fonts.gstatic.com");
                csp.AllowFrames
                    .FromSelf()
                    .From("https://simplicity.trustpilot.com")
                    .From("https://static.nykant.dk")
                    .From("https://web.facebook.com")
                    .From("https://www.facebook.com ")
                    .From("https://js.stripe.com")
                    .From("https://consentcdn.cookiebot.com")
                    .From("https://hooks.stripe.com");
                csp.AllowFraming
                    .FromSelf()
                    .From("https://static.nykant.dk")
                    .From("https://www.facebook.com");
                csp.AllowConnections
                    .OnlyOverHttps();
            });

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
                .AddRedirectToWwwCustom()
                .AddRedirectToProxiedHttps()
                .AddRedirect("(.*)/$", "$1");
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

            IdentityModelEventSource.ShowPII = true;


            //app.UseResponseCompression();
            app.UseResponseCaching();
            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

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
