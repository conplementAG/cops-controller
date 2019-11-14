using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
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
                .UseSerilog((ctx, config) =>
                {
                    config.Enrich.FromLogContext();
                    config.MinimumLevel.Debug();
                    config.WriteTo.Console(new JsonFormatter());
                })
                .UseStartup<Startup>();
    }
}
