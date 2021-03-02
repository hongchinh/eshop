using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eSaleSolution.Data.EF
{
    public class ESaleDbContextFactory : IDesignTimeDbContextFactory<ESaleDbContext>
    {
        public ESaleDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("eSaleSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<ESaleDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ESaleDbContext(optionsBuilder.Options);
        }
    }
}
