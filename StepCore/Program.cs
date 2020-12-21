using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StepCore.Data;
using StepCore.Data.Models;

namespace StepCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<StepCoreContext>();
                    var seedConfig = services.GetRequiredService<SeedConfig>();
                    context.Database.Migrate();
                    Seed.Initialiaze(context, seedConfig);
                }
                catch (System.Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
      
            var host = Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               }).ConfigureAppConfiguration(AppConfiguration);


           


            return host;
        }
           
        public static void AppConfiguration(HostBuilderContext builderContext, IConfigurationBuilder configuration)
        {

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
          
            configuration.AddJsonFile($"appsettings.{environment ?? Environments.Production}.json", optional: false, reloadOnChange: true);
        }
    }
}
