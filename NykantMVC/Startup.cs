using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using NykantMVC.Models;
using NykantMVC.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

namespace NykantMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo("/etc/nykant-keys"))
                .SetApplicationName("Nykant");

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

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

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(10);
                options.Cookie.Name = "SessionCookie";
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddTransient<IMailService, EmailService>();

            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddScoped<IProtectionService, ProtectionService>();

            services.AddControllersWithViews()
                                    .AddMvcOptions(options =>
                                    {
                                        options.MaxModelValidationErrors = 50;
                                        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                                            _ => "Du mangler at udfylde her.");
                                    });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.All;
                // Only loopback proxies are allowed by default.
                // Clear that restriction because forwarders are enabled by explicit 
                // configuration.
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            //app.UseCors();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();

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

        // -------------------------- FOR COOKIES ---------------------------

        //private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        //{
        //    if (options.SameSite == SameSiteMode.None)
        //    {
        //        var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
        //        if (DisallowsSameSiteNone(userAgent))
        //        {
        //            options.SameSite = SameSiteMode.Unspecified;
        //        }
        //    }
        //}

        //public static bool DisallowsSameSiteNone(string userAgent)
        //{
        //    // Check if a null or empty string has been passed in, since this
        //    // will cause further interrogation of the useragent to fail.
        //    if (String.IsNullOrWhiteSpace(userAgent))
        //        return false;

        //    // Cover all iOS based browsers here. This includes:
        //    // - Safari on iOS 12 for iPhone, iPod Touch, iPad
        //    // - WkWebview on iOS 12 for iPhone, iPod Touch, iPad
        //    // - Chrome on iOS 12 for iPhone, iPod Touch, iPad
        //    // All of which are broken by SameSite=None, because they use the iOS networking
        //    // stack.
        //    if (userAgent.Contains("CPU iPhone OS 12") ||
        //        userAgent.Contains("iPad; CPU OS 12"))
        //    {
        //        return true;
        //    }

        //    // Cover Mac OS X based browsers that use the Mac OS networking stack. 
        //    // This includes:
        //    // - Safari on Mac OS X.
        //    // This does not include:
        //    // - Chrome on Mac OS X
        //    // Because they do not use the Mac OS networking stack.
        //    if (userAgent.Contains("Macintosh; Intel Mac OS X 10_14") &&
        //        userAgent.Contains("Version/") && userAgent.Contains("Safari"))
        //    {
        //        return true;
        //    }

        //    // Cover Chrome 50-69, because some versions are broken by SameSite=None, 
        //    // and none in this range require it.
        //    // Note: this covers some pre-Chromium Edge versions, 
        //    // but pre-Chromium Edge does not require SameSite=None.
        //    if (userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6"))
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
