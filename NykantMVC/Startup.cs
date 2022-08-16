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
                        mykeyConnection));

                services.AddDataProtection()
                    .PersistKeysToDbContext<MyKeysContext>()
                    //.ProtectKeysWithCertificate("3fe5fcaf686e7ffbeaf80d760944e0f752f2112b")
                    .SetApplicationName("Nykant");
            }



            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {

                })
                .AddOpenIdConnect("oidc", options =>
                {
                    var accessDenied = Configuration.GetValue<string>("Is");
                    options.Authority = Configuration.GetValue<string>("Is");
                    options.MetadataAddress = Configuration.GetValue<string>("MetadataAddress");
                    options.CallbackPath = "/signin-oidc";
                    options.SignedOutCallbackPath = "/signout-callback-oidc";
                    options.AccessDeniedPath = accessDenied;

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
                });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin Permission", policy => policy.RequireClaim("Permission", "admin"));
            //    options.AddPolicy("Raffle Permission", policy => policy.RequireClaim("Permission", "raffle"));
            //});

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "Session";
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
            });

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
                    options.Cookie.Domain = ".nykant.dk";
                    options.Cookie.IsEssential = true;
                    options.Cookie.HttpOnly = true;
                });
            }

            services.AddControllersWithViews()
                                    //.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                                    //.AddDataAnnotationsLocalization()
                                    .AddXmlSerializerFormatters();

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<BrotliCompressionProvider>();
                options.MimeTypes = new[] {
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                };
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });



            services.AddWebOptimizer(options =>
            {
                options.AddCssBundle("/css/layout-bundle.css"
                    , "/wwwroot/css/mvcstyle.css"
                    , "/wwwroot/css/navbar.css"
                    , "/wwwroot/css/search.css"
                    , "/wwwroot/css/e-mark.css"
                    , "/wwwroot/css/cookiebot.css"
                    , "/wwwroot/css/front-page.css"
                    , "/wwwroot/css/product-gallery.css"
                    , "/wwwroot/css/product-details.css"
                    , "/wwwroot/css/karusel.css"
                    ).MinifyCss().UseContentRoot();

                options.AddJavaScriptBundle("/JS/layout-head-bundle.js"
                    , "/wwwroot/JS/AjaxAntiCSRF.js"
                    , "/wwwroot/JS/logger.js"
                    , "/wwwroot/lib/jquery/dist/jquery.min.js"
                    , "/wwwroot/lib/ajax/jquery.unobtrusive-ajax.min.js"
                    , "/wwwroot/lib/jquery-validation/dist/jquery.validate.js"
                    , "/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"
                    ).MinifyJavaScript().UseContentRoot();

                options.AddJavaScriptBundle("/JS/layout-bottom-bundle.js"
                    , "/wwwroot/JS/noop.js"
                    , "/wwwroot/JS/mobileNav.js"
                    , "/wwwroot/JS/search-button.js"
                    ).MinifyJavaScript().UseContentRoot();

                options.MinifyJsFiles();
            });
            services.AddHttpContextAccessor();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.All;

                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            // Register the Google Analytics configuration
            services.Configure<GoogleAnalyticsOptions>(options => Configuration.GetSection("GoogleAnalytics").Bind(options));

            // Register the TagHelperComponent
            services.AddTransient<ITagHelperComponent, GoogleAnalyticsTagHelperComponent>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

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

            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseCertificateForwarding();

            IdentityModelEventSource.ShowPII = false;

            app.UseHttpsRedirection();

            app.UseWebOptimizer();

            app.UseDefaultFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse =
                r =>
                {
                    string name = r.File.Name;
                    if (name.EndsWith(".css") || name.EndsWith(".js") || name.EndsWith(".gif") || name.EndsWith(".jpg") || name.EndsWith(".png") || name.EndsWith(".svg") || name.EndsWith(".mp4"))
                    {
                        TimeSpan maxAge = new TimeSpan(7, 0, 0, 0);
                        r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                    }
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "products",
                //    pattern: "Produkter/{*searchString}",
                //    defaults: new { controller = "Product", action = "Gallery" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");


            });
        }
    }
}
