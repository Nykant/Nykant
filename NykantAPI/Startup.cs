using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;
using NykantAPI.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mykeyConnection = Configuration.GetConnectionString("MyKeysConnection");
            string nykantConnection = Configuration.GetConnectionString("NykantDb");
            string nykantConnectionLocal = Configuration.GetConnectionString("NykantDbLocal");
            string provider = Configuration.GetValue<string>("Provider");

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

            //migrations to mysql server
            //services.AddDbContext<ApplicationDbContext>(
            //    options =>
            //    {
            //        options.UseMySql(
            //            nykantConnection,
            //            x => x.MigrationsAssembly("MySqlMigrations"));
            //    });

            services.AddDbContext<ApplicationDbContext>(
                options => _ = provider switch
                {
                    "SqlServer" => options.UseSqlServer(
                        nykantConnectionLocal,
                        x => x.MigrationsAssembly("SqlServerMigrations")),

                    "MySql" => options.UseMySql(
                        nykantConnection,
                        x => x.MigrationsAssembly("MySqlMigrations")),

                    _ => throw new Exception($"Unsupported provider: {provider}")
                });



            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration.GetValue<string>("Is");
                    options.MetadataAddress = Configuration.GetValue<string>("MetadataAddress");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };

                    //options.Audience = "NykantAPI";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireClaim("scope", "NykantAPI");
                });
            });

            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddScoped<IProtectionService, ProtectionService>();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.All;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase(Configuration.GetValue<string>("PathBase"));
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCertificateForwarding();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization("ApiScope");
            });
        }
    }
}
