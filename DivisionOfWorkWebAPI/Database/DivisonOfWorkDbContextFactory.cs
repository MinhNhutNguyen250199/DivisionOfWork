using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Database
{
    public class DivisonOfWorkDbContextFactory: IDesignTimeDbContextFactory<DivisionOfWorkDbContext>
    {
        public DivisionOfWorkDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            //add MS.Extension.File.Ex + MS.Ex.Json

            var connectionString = configuration.GetConnectionString("DivisionOfWork");

            var optionsBuilder = new DbContextOptionsBuilder<DivisionOfWorkDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DivisionOfWorkDbContext(optionsBuilder.Options);
        }
    }
}
