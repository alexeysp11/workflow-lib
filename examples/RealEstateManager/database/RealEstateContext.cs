using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.RealEstateManager.Database.Models;

namespace WorkflowLib.Examples.RealEstateManager.Database
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
