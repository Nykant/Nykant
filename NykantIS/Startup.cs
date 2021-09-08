// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using NykantIS.Data;
using NykantIS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.Configuration;
using System;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Reflection;
using NykantIS.Data.Seed;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using MailKit;
using NykantIS.Services;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NykantIS
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            string mykeyConnection = null;
            string identityserverConnection = null;
            string identityConnection = null;
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            mykeyConnection = Configuration.GetConnectionString("MyKeysConnection");
            identityserverConnection = Configuration.GetConnectionString("IdentityServer");
            identityConnection = Configuration.GetConnectionString("Identity");


            services.AddDbContext<MyKeysContext>(options =>
                options.UseMySql(mykeyConnection));

            services.AddDataProtection()
                .PersistKeysToDbContext<MyKeysContext>()
                .SetApplicationName("Nykant");

            services.AddDbContext<IdentityContext>(options =>
                options.UseMySql(identityConnection));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.IssuerUri = Configuration.GetValue<string>("IssuerUri");

                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;

                options.UserInteraction.LoginUrl = "/Account/Login";
                options.UserInteraction.LogoutUrl = "/Account/Logout";

                options.Authentication = new AuthenticationOptions()
                {
                    CookieLifetime = TimeSpan.FromHours(10), // ID server cookie timeout set to 10 hours
                    CookieSlidingExpiration = true
                };
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b
                    .UseMySql(identityserverConnection, mySqlOptionsAction: mySql =>
                    {
                        mySql.MigrationsAssembly(migrationsAssembly);
                    });
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b
                    .UseMySql(identityserverConnection, mySqlOptionsAction: mySql =>
                    {
                        mySql.MigrationsAssembly(migrationsAssembly);
                    });
            })

            .AddAspNetIdentity<ApplicationUser>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = "413646567653-2set9f80eantuvbkj84d7mmb5vp6dfl8.apps.googleusercontent.com";
                    options.ClientSecret = "dvfRC2hzoa-obrao6uScXHSB";
                });

            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddTransient<Services.IMailService, EmailService>();

            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews()
                                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                                    .AddDataAnnotationsLocalization();
            services.AddRazorPages()
                                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                                    .AddDataAnnotationsLocalization();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.All;

                //options.KnownNetworks.Clear();
                //options.KnownProxies.Clear();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            var DK = new CultureInfo("da-DK");
            var cultureList = new List<CultureInfo>
            {
                DK
            };

            app.UsePathBase(Configuration.GetValue<string>("PathBase"));
            app.UseForwardedHeaders();

            InitializeDatabase(app);

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCertificateForwarding();

            app.UseHttpsRedirection();

            IdentityModelEventSource.ShowPII = true;

            app.UseStaticFiles();

            app.UseRouting();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(DK, DK),
                SupportedCultures = cultureList,
                SupportedUICultures = cultureList
            });

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}