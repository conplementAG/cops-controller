using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Json;

namespace ConplementAG.CopsController
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => { config.AddEnvironmentVariables(); })
                .UseSerilog((ctx, config) =>
                {
                    config.ReadFrom.Configuration(new ConfigurationBuilder()
                        .AddEnvironmentVariables()
                        .Build());
                    config.Enrich.FromLogContext();
                    config.WriteTo.Console(new JsonFormatter());
                })
                .UseStartup<Startup>();
    }
}
