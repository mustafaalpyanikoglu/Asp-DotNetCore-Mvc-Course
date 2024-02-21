using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Constants;
using WebAPI.Middlewares;

namespace WebAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/Home/Error");

			app.UseStatusCodePagesWithReExecute("/Home/Status", "?code={0}");


			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/" + PathConstant.NODE_MODULES,
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), PathConstant.NODE_MODULES))
            });


			app.UseRouting();
			app.UseSession();

			app.UseEndpoints(endpoints =>
            {
				//endpoints.MapControllerRoute(
				//	name: "productRoute",
				//	pattern: "{Alp}/{action}",
				//	defaults: new { Controller = "Home"});

				endpoints.MapControllerRoute(
					name: "areas",
					pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}");

				endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}/{id?}",
                    defaults: new {Controller= "Home", Action="Index"});
            });
            //app.UseMiddleware<ReguestEditingMiddleware>();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
