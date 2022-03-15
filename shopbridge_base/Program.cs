using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopbridge_base.Data;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Services;
using Shopbridge_base.Domain.Services.Interfaces;

namespace Shopbridge_base
{
    public class Program
    {
        public static IConfigurationRoot _configurationBuilder;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .ConfigureAppConfiguration(
                (hostBuilder, config) =>
                {
                    ConfigureAppConfiguration(config);
                }
            )
                .ConfigureServices(
                (config, services) =>
                {
                    ConfigureServices(services);
                }
            ).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void ConfigureAppConfiguration(IConfigurationBuilder config)
        {
            _configurationBuilder = config.Build();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configurationBuilder.GetSection("ConnectionStrings").GetSection("Shopbridge_Context").Value;

            services
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IRepository, Repository>();

            services.AddScoped<Shopbridge_Context>(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<Shopbridge_Context>();
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();

                return new Shopbridge_Context(optionsBuilder.Options, connectionString);
            });

        }
    }
}
