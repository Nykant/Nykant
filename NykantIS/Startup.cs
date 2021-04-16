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

            string ISString = Configuration.GetConnectionString("IdentityServer");
            string IdentityString = Configuration.GetConnectionString("Identity");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseMySql(IdentityString,
                        mySqlOptionsAction: mySql =>
                        {
                            mySql.ServerVersion(new Version(5, 5, 68), ServerType.MariaDb);
                            mySql.EnableRetryOnFailure();
                            mySql.CharSetBehavior(CharSetBehavior.NeverAppend);
                        })
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    );

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;

                options.UserInteraction.LoginUrl = "is/Account/Login";
                options.UserInteraction.LogoutUrl = "is/Account/Logout";

                options.Authentication = new AuthenticationOptions()
                {
                    CookieLifetime = TimeSpan.FromHours(10), // ID server cookie timeout set to 10 hours
                    CookieSlidingExpiration = true
                };
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b
                .UseMySql(
                    ISString,
                    mySqlOptionsAction: mySql =>
                    {
                        mySql.ServerVersion(new Version(5, 5, 68), ServerType.MariaDb);
                        mySql.EnableRetryOnFailure();
                        mySql.CharSetBehavior(CharSetBehavior.NeverAppend);
                        mySql.MigrationsAssembly(migrationsAssembly);
                    })
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b
                    .UseMySql(
                        ISString,
                        mySqlOptionsAction: mySql =>
                        {
                            mySql.ServerVersion(new Version(5, 5, 68), ServerType.MariaDb);
                            mySql.EnableRetryOnFailure();
                            mySql.CharSetBehavior(CharSetBehavior.NeverAppend);
                            mySql.MigrationsAssembly(migrationsAssembly);
                        })
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
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
            services.AddTransient<Services.IMailService, EmailService>();

            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddControllersWithViews()
                    .AddMvcOptions(options =>
                    {
                        options.MaxModelValidationErrors = 50;
                        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                            _ => "Du mangler at udfylde her.");
                    });
            services.AddRazorPages()
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
            });

        }

        public void Configure(IApplicationBuilder app)
        {
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
            //app.UseHttpsRedirection();
            IdentityModelEventSource.ShowPII = true;

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
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