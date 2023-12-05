using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using src.Repository;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Infrastructure.EntityFramework;

namespace ResistenceSocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IRebelRepository, RebelRepository>();
                    services.AddScoped<IInventoryRepository, InventoryRepository>();
                    services.AddScoped<IRebelUseCase, RebelUseCase>();
                    services.AddScoped<ITradeResourcesUseCase, TradeResoursesUseCase>();
                    services.AddScoped<IReportUseCase, ReportUseCase>();
                    services.AddScoped<ResistenceDbContext>();
                    
                    services.Configure<HostOptions>(option =>
                    {
                        option.ShutdownTimeout = TimeSpan.FromSeconds(30);
                    });
                });
    }
}
