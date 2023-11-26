using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShop.DB.Storages;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Storages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OnlineShopWebApp
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
			string connection = Configuration.GetConnectionString("online_shop");
			// добавляем контекст MobileContext в качестве 
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer(connection));

			// Добавляем контекст IdentityContext в качестве сервиса в приложение
			services.AddDbContext<IdentityContext>(options =>
				options.UseSqlServer(connection));

			services.AddIdentity<User, IdentityRole>() // указываем тип пользователя и роли
				.AddEntityFrameworkStores<IdentityContext>(); // устанавливаем тип хранилища - наш контекст

			// настройки кук
			services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromHours(24);
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/Account/Logout";
				options.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
				{
					IsEssential = true
				};
			});

            services.AddSingleton<IUserStorage, UserStorageInJson>();
            services.AddSingleton<IRoleStorage, RoleStorageInJson>();
            services.AddTransient<IFavouriteStorage, FavouriteStorage>();
			services.AddTransient<ICompareStorage, CompareStorage>();
			services.AddTransient<IOrderStorage, OrderDBStorage>();
			services.AddTransient<IProductStorage, ProductDBStorage>();
			services.AddTransient<ICartStorage, CartDBStorage>();
            services.AddSingleton<ShopUser>();
			services.AddControllersWithViews();
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

            var defaultCulture = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            app.UseSerilogRequestLogging();
            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id=0}");

                endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id=0}");
			});
        }
	}
}
