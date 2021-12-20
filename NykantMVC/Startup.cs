using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Logging;
using NykantMVC.Data;
using NykantMVC.Models;
using NykantMVC.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

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


            services.AddDbContext<MyKeysContext>(options =>
    options.UseMySql(
        mykeyConnection));
            //if (Environment.IsDevelopment())
            //{
            //    services.AddDbContext<MyKeysContext>(options =>
            //        options.UseSqlServer(
            //            mykeyConnection));
            //}
            //else
            //{
            //    services.AddDbContext<MyKeysContext>(options =>
            //        options.UseMySql(
            //            mykeyConnection));
            //}

            services.AddDataProtection()
                .PersistKeysToDbContext<MyKeysContext>()
                .SetApplicationName("Nykant");

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
                    options.Authority = Configuration.GetValue<string>("Is");
                    options.MetadataAddress = Configuration.GetValue<string>("MetadataAddress");
                    options.CallbackPath = "/signin-oidc";
                    options.SignedOutCallbackPath = "/signout-callback-oidc";

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("email");
                    options.Scope.Add("NykantAPI");
                    options.Scope.Add("offline_access");
                });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(10);
                options.Cookie.Name = "SessionCookie";
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddTransient<IMailService, EmailService>();

            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            services.AddScoped<IProtectionService, ProtectionService>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddAntiforgery();


            if (Environment.IsDevelopment())
            {
                services.AddAntiforgery(options => {
                    options.Cookie.Name = "NykantAntiCSRFToken";
                    options.HeaderName = "NykantAntiCSRFToken";
                    options.FormFieldName = "NykantAntiCSRFToken";
                    options.Cookie.Domain = "localhost";
                });
            }
            else
            {
                services.AddAntiforgery(options => {
                    options.Cookie.Name = "NykantAntiCSRFToken";
                    options.HeaderName = "NykantAntiCSRFToken";
                    options.FormFieldName = "NykantAntiCSRFToken";
                    options.Cookie.Domain = ".nykant.dk";
                });
            }


            services.AddControllersWithViews()
                                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                                    .AddDataAnnotationsLocalization()
                                    .AddXmlSerializerFormatters();

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
            var DK = new CultureInfo("da-DK");
            var EN = new CultureInfo("en-GB");
            var cultureList = new List<CultureInfo>
            {
                DK,
                EN
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(DK, DK),
                SupportedCultures = cultureList,
                SupportedUICultures = cultureList
            });

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

            app.UseCertificateForwarding();

            IdentityModelEventSource.ShowPII = true;

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Nykant}/{action=Index}/{id?}");
            });
        }
    }
}
