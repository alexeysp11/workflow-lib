using Microsoft.EntityFrameworkCore;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Products;
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

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<InitialOrder> InitialOrders { get; set; }
        public DbSet<InitialOrderProduct> InitialOrderProducts { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<DeliveryOrderProduct> DeliveryOrderProducts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WHProduct> WHProducts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DeliveryOperation> DeliveryOperations { get; set; }
    }
}