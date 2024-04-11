using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;

namespace ConplementAG.CopsController
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => { config.AddEnvironmentVariables(); })
                .UseSerilog((ctx, config) =>
                {
                    config.ReadFrom.Configuration(new ConfigurationBuilder().AddEnvironmentVariables().Build());
                    config.Enrich.FromLogContext();
                    config.WriteTo.Console(new JsonFormatter());
                })
                .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });
    }
}