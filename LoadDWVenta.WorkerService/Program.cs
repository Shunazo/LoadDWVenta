using LoadDWVenta.WorkerService;
using LoadDWVenta.Data.Context;
using LoadDWVenta.Data.Interfaces;
using LoadDWVenta.Data.Services;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) => {

     
            services.AddDbContextPool<DWHContext>(options =>
                                                      options.UseSqlServer(hostContext.Configuration.GetConnectionString("DWH")));

            services.AddDbContextPool<NorthwindContext>(options =>
                                                      options.UseSqlServer(hostContext.Configuration.GetConnectionString("Northwind")));


            services.AddScoped<IDataServiceDWHNorth, DataServiceDWHNorth>();

            services.AddHostedService<Worker>();
        });
}

