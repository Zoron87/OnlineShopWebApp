using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OnlineShopWebApp
{
    public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
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
