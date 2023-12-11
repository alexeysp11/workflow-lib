using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Network;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DeliveringContext : DbContext
    {
        public DeliveringContext(DbContextOptions<DeliveringContext> options) : base(options) { }

        // public DbSet<ApiOperation> ApiOperations { get; set; }
        public DbSet<InitialOrder> InitialOrders { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DeliveryOperation> DeliveryOperations { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseInMemoryDatabase(databaseName: "mydatabase");
        // }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<InitialOrder>()
        //         .Property(x => x.Url)
        //         .IsRequired();
        // }
    }
}