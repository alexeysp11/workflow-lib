using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WorkflowLib.Examples.RealEstateManager.Database 
{
    public class RealEstateContextFactory : IDesignTimeDbContextFactory<RealEstateContext>
    {
        public RealEstateContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RealEstateContext>();
            var connectionString = configuration.GetConnectionString("RealEstateDb");
            builder.UseSqlServer(connectionString);
            return new RealEstateContext(builder.Options);
        }
    }
}