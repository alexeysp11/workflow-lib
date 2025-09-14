using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Examples.RealEstateManager.Database.Models;

namespace VelocipedeUtils.Examples.RealEstateManager.Database
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
