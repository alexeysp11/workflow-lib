using Microsoft.EntityFrameworkCore;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Cooking;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Shared.Models.Business.Monetary;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Business.SocialCommunication;
using WorkflowLib.ECommerce.FoodDelivery.Core.Models;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts
{
    /// <summary>
    /// Database context that allows you to work with entities from the database and store them as regular collections.
    /// </summary>
    public class DeliveringDbContext : DbContext
    {
        public DeliveringDbContext(DbContextOptions<DeliveringDbContext> options) : base(options) { }

        /// <summary>
        /// User accounts.
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// User groups.
        /// </summary>
        public DbSet<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Contacts.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Organizations.
        /// </summary>
        public DbSet<Organization> Organizations { get; set; }

        /// <summary>
        /// Organization items.
        /// </summary>
        public DbSet<OrganizationItem> OrganizationItems { get; set; }

        /// <summary>
        /// Companies.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Business tasks.
        /// </summary>
        public DbSet<BusinessTask> BusinessTasks { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Orders.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Order products.
        /// </summary>
        public DbSet<OrderProduct> OrderProducts { get; set; }

        /// <summary>
        /// Initial orders.
        /// </summary>
        public DbSet<InitialOrder> InitialOrders { get; set; }

        /// <summary>
        /// Initial order products.
        /// </summary>
        public DbSet<InitialOrderProduct> InitialOrderProducts { get; set; }

        /// <summary>
        /// Initial order ingredients.
        /// </summary>
        public DbSet<InitialOrderIngredient> InitialOrderIngredients { get; set; }

        /// <summary>
        /// Delivery orders.
        /// </summary>
        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }

        /// <summary>
        /// Delivery order products.
        /// </summary>
        public DbSet<DeliveryOrderProduct> DeliveryOrderProducts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<BusinessTaskDeliveryOrder> BusinessTaskDeliveryOrders { get; set; }

        /// <summary>
        /// Delivery methods.
        /// </summary>
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        /// <summary>
        /// Payments.
        /// </summary>
        public DbSet<Payment> Payments { get; set; }

        /// <summary>
        /// Product categories.
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }

        /// <summary>
        /// Products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Warehouse products.
        /// </summary>
        public DbSet<WHProduct> WHProducts { get; set; }

        /// <summary>
        /// Ingredients.
        /// </summary>
        public DbSet<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Recipes.
        /// </summary>
        public DbSet<Recipe> Recipes { get; set; }

        /// <summary>
        /// Product transfers.
        /// </summary>
        public DbSet<ProductTransfer> ProductTransfers { get; set; }

        /// <summary>
        /// Notifications.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }

        /// <summary>
        /// Delivery operations.
        /// </summary>
        public DbSet<DeliveryOperation> DeliveryOperations { get; set; }

        /// <summary>
        /// Cooking operations.
        /// </summary>
        public DbSet<CookingOperation> CookingOperations { get; set; }

        /// <summary>
        /// Model for transferring products from warehouse to kitchen.
        /// </summary>
        public DbSet<DeliveryWh2Kitchen> DeliveriesWh2Kitchen { get; set; }

        /// <summary>
        /// Model for transferring products from kitchen to warehouse.
        /// </summary>
        public DbSet<DeliveryKitchen2Wh> DeliveriesKitchen2Wh { get; set; }
    }
}