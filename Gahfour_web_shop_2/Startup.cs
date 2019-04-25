using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gahfour_web_shop_2.Models;
using Gahfour_web_shop_2.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Session;
using Dapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Gahfour_web_shop_2
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);*/


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();//test, från https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.2



            services.AddTransient<IItemRepo, MSSQLItemRepo>();
            services.AddTransient<ISettingsRepo, MSSQLSettingsRepo>();//test
            services.AddTransient<IAdminRepo, MSSQLAdminRepo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDistributedMemoryCache();//för session // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();//för session, kan ha argument s => s.IdleTimeout = TimeSpan.FromMinutes(30)

            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();//För session, ersatt
            services.AddHttpContextAccessor();//för httpcontext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddOptions();
            //services.Configure<ConnStr>(Configuration.GetSection("ConnectionStrings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //session
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();



            //test
            app.UseAuthentication(); //från https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.2



            //test
            //app.UseAnonymousId();

            /* test med cookies
            app.Use(async (context, next) =>
            {
                context.Session.SetString("GreetingMessage", "Hello Session State");
                await next();
            });


            app.Run(async (context) =>
            {
                var message = context.Session.GetString("GreetingMessage");
                await context.Response.WriteAsync($"{message}");
            }); */

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
