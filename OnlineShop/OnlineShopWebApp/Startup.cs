using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShop.DB.Storages;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using OnlineShopWebApp.Storages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using WebAPI;
using WebAPI.Interfaces;
using WebAPI.Storages;

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

            // Добавляем контекст ReviewDatabaseContext в качестве сервиса в приложение
            services.AddDbContext<ReviewDatabaseContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<User, UserRole>() // указываем тип пользователя и роли
				.AddRoles<UserRole>()
				.AddEntityFrameworkStores<IdentityContext>() // устанавливаем тип хранилища - наш контекст
				.AddErrorDescriber<CustomIdentityErrorDescriber>(); // Переписываем описания ошибок Identity

            // настройки кук
            services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromHours(24);
				options.LoginPath = "/Authorization/Login";
				options.LogoutPath = "/Authorization/Logout";
				options.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
				{
					IsEssential = true
				};
			});

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IFavouriteStorage, FavouriteStorage>();
			services.AddTransient<ICompareStorage, CompareStorage>();
			services.AddTransient<IOrderStorage, OrderDBStorage>();
			services.AddTransient<IProductStorage, ProductDBStorage>();
			services.AddTransient<ICartStorage, CartDBStorage>();
            services.AddTransient<IReviewStorage, ReviewStorage>();
            services.AddTransient<ImageProvider>();
            services.AddSingleton<UserViewModel>();

			services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "WebAPI",
                    Description = "Secret_WebAPI"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                        },
                        new List <string>()
                    }
                });
            });

            services.AddHttpClient("ReviewWebAPI", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:52723/");
            });
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

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/V1/swagger.json", "Secret_WebAPI");
                });
            }

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
