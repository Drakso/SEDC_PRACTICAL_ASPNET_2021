using Application;
using Application.Configurations;
using Infrastrucutre.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp
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
			services.AddControllersWithViews();

			// Our configurations

			// Configuring Options Pattern 
			// Connecting AppSettings section from appsettings.json to AppSettings class
			// This is registering IOption<AppSettings> to the DI container
			// The container will create a new instance of Options<AppSettings> and give it to the constructor where we are requesting for it
			var appConfig = Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appConfig);

			

			// Using AppSettings right away
			var appSettings = appConfig.Get<AppSettings>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddHttpClient<INotificationService, NotificationService>();
			services.AddTransient<INotificationService, NotificationService>();
			DiModule.Register(services, appSettings.ConnectionString);
			
			// Add automapper configuration for dependency Injection
			// When you request in constructor for IMapper you will get a Mapper with configurations from all MappingProfile classes that you insert here
			services.AddAutoMapper(typeof(Application.Configurations.MappingProfile), typeof(WebApp.Configurations.MappingProfile));

			// When we have multiple classes with the same name, they are differentiated by their namespace
			// We can write the namespace of the class before any class we use
			// The gray namespaces mean that they can be left out and the call can be simplified
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Users}/{action=Login}/{id?}");
			});
		}
	}
}
