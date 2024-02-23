using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebIdentity.Context;
using WebIdentity.CustomDescriber;
using WebIdentity.Entities;

namespace WebIdentity
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddIdentity<AppUser, AppRole>(opt =>
			{
				opt.Password.RequireDigit = false;
				opt.Password.RequiredLength = 1;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.SignIn.RequireConfirmedEmail = true;
				opt.Lockout.MaxFailedAccessAttempts = 3;
			}).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<UdemyContext>();

			services.ConfigureApplicationCookie(opt =>
			{
				opt.Cookie.HttpOnly = true;
				opt.Cookie.SameSite = SameSiteMode.Strict;
				opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
				opt.Cookie.Name = "UdemyCookie";
				opt.ExpireTimeSpan = TimeSpan.FromDays(25);
				opt.LoginPath = new PathString("/Home/SignIn");
				opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
			});

			services.AddDbContext<UdemyContext>(opt =>
			{
				opt.UseSqlServer("Server=DESKTOP-I6QFS5F;Database=IdentityDB; Trusted_Connection=True; Integrated Security = true");
			});
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles(new StaticFileOptions
			{
				RequestPath = "/node_modules",
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
			});
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
