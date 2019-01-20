using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShopSnowboardEquip.Data;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Data.mocks;
using ShopSnowboardEquip.Data.Models;
using ShopSnowboardEquip.Data.Repositories;

namespace ShopSnowboardEquip
{
	public class Startup
	{
		/*public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		*/
		private IConfigurationRoot _configurationRoot;

		public Startup(IHostingEnvironment hostingEnvironment)
		{
			_configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.Build();
		}


		
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			/*.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			}); */

			//Authentication, Identity config
			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddDbContext<AppDbContext>(options => options
                    .UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

			services.AddTransient<IEquipmentRepository, EquipmentRepository>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddSession();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(AppDbContext context, IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			loggerFactory.AddConsole();
			app.UseHttpsRedirection();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseCookiePolicy();
            app.UseSession();
			app.UseIdentity();
			app.UseMvc(routes =>
			{
                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Equipment/{action}/{category?}",
                    defaults: new { Controller = "Equipment", action = "List" });

                routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

            DbInitializer.Seed(context, app);
		}
	}
}
