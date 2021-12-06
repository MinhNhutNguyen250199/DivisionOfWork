using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DivisionOfWorkWebAPI.Database;
using DivisionOfWorkWebAPI.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace DivisionOfWorkWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<DivisionOfWorkDbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<DivisionOfWorkSeedata>>();
                new DivisionOfWorkSeedata().SeedAsync(context, logger).Wait();
            });
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
