using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using live_chatApp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Startup


{
    public class Startup
    {
        private const string V = "/Index";
        private const string Path = V;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

             services.AddSignalR();
            IMvcBuilder mvcBuilder = services.AddMvc().SetCompatibilityVersion(version: CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            IApplicationBuilder applicationBuilder = app.UseSignalR(configure: NewMethod());
#pragma warning disable MVC1005 // Cannot use UseMvc with Endpoint Routing.
            app.UseMvc(routes =>

            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
#pragma warning restore MVC1005 // Cannot use UseMvc with Endpoint Routing.
        }

        [Obsolete]
        private static Action<HubRouteBuilder> NewMethod()
        {
            return routes =>
            {
                routes.MapHub<Class>(Path);
            };
        }
    }
}