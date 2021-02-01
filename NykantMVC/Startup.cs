using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NykantMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("profile");
                    options.Scope.Add("NykantAPI");
                    options.Scope.Add("offline_access");
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            // Make sure a JS engine is registered, or you will get an error!
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
              .AddV8();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) /*IAntiforgery antiforgery m?skeeee m?ske ik????*/
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //// Initialise ReactJS.NET. Must be before static files.
            //app.UseReact(config =>
            //{
            //    // If you want to use server-side rendering of React components,
            //    // add all the necessary JavaScript files here. This includes
            //    // your components as well as all of their dependencies.
            //    // See http://reactjs.net/ for more information. Example:
            //    //config
            //    //  .AddScript("~/js/First.jsx")
            //    //  .AddScript("~/js/Second.jsx");

            //    // If you use an external build too (for example, Babel, Webpack,
            //    // Browserify or Gulp), you can improve performance by disabling
            //    // ReactJS.NET's version of Babel and loading the pre-transpiled
            //    // scripts. Example:
            //    //config
            //    //  .SetLoadBabel(false)
            //    //  .AddScriptWithoutTransform("~/js/bundle.server.js");
            //});

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();
            });
        }
    }
}
