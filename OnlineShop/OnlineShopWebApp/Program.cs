using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using Serilog;

namespace OnlineShopWebApp
{
    public class Program
	{
		public static void Main(string[] args)
		{
			//CreateHostBuilder(args).Build().Run();
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				var userManager = services.GetRequiredService<UserManager<User>>();
				var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
				IdentityInitializer.Initialize(userManager, roleManager);
			}
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.UseSerilog((hostingContext, LoggerConfiguration) =>
			{
				LoggerConfiguration
					.ReadFrom.Configuration(hostingContext.Configuration)
					.Enrich.FromLogContext()
					.Enrich.WithProperty("ApplicationName", "Online Shop");
			})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
