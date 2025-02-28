﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
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
using Microsoft.AspNetCore.Rewrite;
using NykantIS.Extensions;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

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
            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            mykeyConnection = Configuration.GetConnectionString("MyKeysConnection");
            identityserverConnection = Configuration.GetConnectionString("IdentityServer");
            identityConnection = Configuration.GetConnectionString("Identity");

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader());
            //});

            //services.AddDbContext<MyKeysContext>(options =>
            //    options.UseMySql(mykeyConnection));

            //services.AddDbContext<IdentityContext>(options =>
            //    options.UseMySql(identityConnection));

            //services.AddDataProtection()
            //    .PersistKeysToDbContext<MyKeysContext>()
            //    .SetApplicationName("Nykant");

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<IdentityContext>()
            //    .AddClaimsPrincipalFactory<ClaimsFactory<ApplicationUser>>();

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<LocalMyKeysContext>(options =>
                    options.UseSqlServer(mykeyConnection));

                services.AddDataProtection()
                    .PersistKeysToDbContext<LocalMyKeysContext>()
                    //.ProtectKeysWithCertificate("3fe5fcaf686e7ffbeaf80d760944e0f752f2112b")
                    .SetApplicationName("Nykant");

                services.AddDbContext<LocalIdentityContext>(options =>
                    options.UseSqlServer(identityConnection));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<LocalIdentityContext>()
                    .AddClaimsPrincipalFactory<ClaimsFactory<ApplicationUser>>();
            }
            else
            {
                services.AddDbContext<MyKeysContext>(options =>
                    options.UseMySql(mykeyConnection));

                services.AddDataProtection()
                    .PersistKeysToDbContext<MyKeysContext>()
                    //.ProtectKeysWithCertificate("3fe5fcaf686e7ffbeaf80d760944e0f752f2112b")
                    .SetApplicationName("Nykant");

                services.AddDbContext<IdentityContext>(options =>
                    options.UseMySql(identityConnection));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddClaimsPrincipalFactory<ClaimsFactory<ApplicationUser>>();
            }



            var builder = services.AddIdentityServer(options =>
            {
                options.IssuerUri = Configuration.GetValue<string>("IssuerUri");
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
                options.Discovery = new DiscoveryOptions
                {
                     ShowEndpoints = true,
                      ShowTokenEndpointAuthenticationMethods = true
                };
                //options.MutualTls = new MutualTlsOptions
                //{
                //    Enabled = true,
                //    DomainName = "nykant.dk"
                //};

                options.UserInteraction.LoginUrl = "/Account/Login";
                options.UserInteraction.LogoutUrl = "/Account/Logout";
                options.Endpoints = new EndpointsOptions
                {
                    EnableTokenEndpoint = true,
                     EnableAuthorizeEndpoint = true,
                      EnableDiscoveryEndpoint = true,
                       EnableJwtRequestUri = true,
                        EnableUserInfoEndpoint = true,
                         EnableTokenRevocationEndpoint = true,
                          EnableCheckSessionEndpoint = true,
                           EnableDeviceAuthorizationEndpoint = true,
                            EnableEndSessionEndpoint = true,
                             EnableIntrospectionEndpoint = true

                };
                //options.Authentication = new AuthenticationOptions()
                //{
                //    CookieLifetime = TimeSpan.FromHours(10), // ID server cookie timeout set to 10 hours
                //    CookieSlidingExpiration = true,
                //     CookieSameSiteMode = SameSiteMode.None
                //};
                
            });





            //builder.AddConfigurationStore(options =>
            //{
            //    options.ConfigureDbContext = b => b
            //        .UseMySql(identityserverConnection, mySqlOptionsAction: mySql =>
            //        {
            //            mySql.MigrationsAssembly(migrationsAssembly);
            //        });
            //});

            //builder.AddOperationalStore(options =>
            //{
            //    options.ConfigureDbContext = b => b
            //        .UseMySql(identityserverConnection, mySqlOptionsAction: mySql =>
            //        {
            //            mySql.MigrationsAssembly(migrationsAssembly);
            //        });
            //});


            if (Environment.IsDevelopment())
            {
                builder.AddConfigurationStore<LocalConfigurationDbContext>(options =>
                {
                    options.ConfigureDbContext = b => b
                        .UseSqlServer(identityserverConnection, sqlServerOptionsAction: sql =>
                        {
                            sql.MigrationsAssembly(migrationsAssembly);
                        });
                });

                builder.AddOperationalStore<LocalPersistedGrantDbContext>(options =>
                {
                    options.ConfigureDbContext = b => b
                        .UseSqlServer(identityserverConnection, sqlServerOptionsAction: sql =>
                        {
                            sql.MigrationsAssembly(migrationsAssembly);
                        });
                });
            }
            else
            {
                builder.AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b
                        .UseMySql(identityserverConnection, mySqlOptionsAction: mySql =>
                        {
                            mySql.MigrationsAssembly(migrationsAssembly);
                        });
                });

                builder.AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b
                        .UseMySql(identityserverConnection, mySqlOptionsAction: mySql =>
                        {
                            mySql.MigrationsAssembly(migrationsAssembly);
                        });

                });
            }

            builder.AddAspNetIdentity<ApplicationUser>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            //if (!Environment.IsDevelopment())
            //{
            //    builder.AddRedisCaching(options =>
            //    {
            //        options.RedisConnectionString = "nykant-memcached.tylulq.cfg.eun1.cache.amazonaws.com:11211";
            //    });
            //}

            //if (!Environment.IsDevelopment())
            //{
            //    services.AddStackExchangeRedisCache(options =>
            //    {
            //        options.Configuration = "nykant-memcached.tylulq.cfg.eun1.cache.amazonaws.com:11211";
            //        options.InstanceName = "nykant-memcached";
            //    });
            //}


            services.AddAuthentication();
                //.AddGoogle("Google", options =>
                //{
                //    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                //    // register your IdentityServer with Google at https://console.developers.google.com
                //    // enable the Google+ API
                //    // set the redirect URI to https://localhost:5001/signin-google
                //    options.ClientId = "413646567653-2set9f80eantuvbkj84d7mmb5vp6dfl8.apps.googleusercontent.com";
                //    options.ClientSecret = "dvfRC2hzoa-obrao6uScXHSB";
                //});

            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddTransient<Services.IMailService, EmailService>();

            services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddAntiforgery();

            services.AddControllersWithViews()
                                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                                    .AddDataAnnotationsLocalization();
            services.AddRazorPages()
                                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                                    .AddDataAnnotationsLocalization();




        }

        public void Configure(IApplicationBuilder app)
        {


            app.UsePathBase(Configuration.GetValue<string>("PathBase"));

            var DK = new CultureInfo("da-DK");
            var GB = new CultureInfo("en-GB");
            var cultureList = new List<CultureInfo>
            {
                DK,
                GB
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(DK, DK),
                SupportedCultures = cultureList,
                SupportedUICultures = cultureList
            });

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
                .AddRedirectToWwwPermanent();  // remove trailing slash
            app.UseRewriter(options);

            app.UseCertificateForwarding();
            //app.UseHttpsRedirection();

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

            //app.Use(async (ctx, next) =>
            //{
            //    ctx.SetIdentityServerOrigin("https://nykant.dk/is");
            //    await next();
            //});

            //app.UseHttpsRedirection();

            IdentityModelEventSource.ShowPII = true;

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();


            //app.UseCors("CorsPolicy");

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            SeedData.EnsureSeedData(app.ApplicationServices, Environment);
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                if (Environment.IsDevelopment())
                {
                    serviceScope.ServiceProvider.GetRequiredService<LocalPersistedGrantDbContext>().Database.Migrate();
                    var context = serviceScope.ServiceProvider.GetRequiredService<LocalConfigurationDbContext>();
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
                else
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
}