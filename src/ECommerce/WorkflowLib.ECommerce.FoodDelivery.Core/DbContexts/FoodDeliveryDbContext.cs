using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;
using VelocipedeUtils.Shared.Models.Business.Cooking;
using VelocipedeUtils.Shared.Models.Business.Customers;
using VelocipedeUtils.Shared.Models.Business.Delivery;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;
using VelocipedeUtils.Shared.Models.Business.Monetary;
using VelocipedeUtils.Shared.Models.Business.Products;
using VelocipedeUtils.Shared.Models.Business.Processes;
using VelocipedeUtils.Shared.Models.Business.SocialCommunication;
using VelocipedeUtils.Shared.Models.Business.Packing;
using VelocipedeUtils.Shared.Models.Business.MeasurementUnits;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts
{
    /// <summary>
    /// Database context that allows you to work with entities from the database and store them as regular collections.
    /// </summary>
    public class FoodDeliveryDbContext : DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options) : base(options) { }

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
        /// Business diagrams.
        /// </summary>
        public DbSet<BusinessDiagram> BusinessDiagrams { get; set; }

        /// <summary>
        /// Business diagram elements.
        /// </summary>
        public DbSet<BusinessDiagramElement> BusinessDiagramElements { get; set; }

        /// <summary>
        /// Business processes.
        /// </summary>
        public DbSet<BusinessProcess> BusinessProcesses { get; set; }

        /// <summary>
        /// Business process states.
        /// </summary>
        public DbSet<BusinessProcessState> BusinessProcessStates { get; set; }

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
        /// Containers.
        /// </summary>
        public DbSet<Container> Containers { get; set; }

        /// <summary>
        /// Lots.
        /// </summary>
        public DbSet<Lot> Lots { get; set; }

        /// <summary>
        /// Trays.
        /// </summary>
        public DbSet<Tray> Trays { get; set; }

        /// <summary>
        /// Pack types.
        /// </summary>
        public DbSet<PackType> PackTypes { get; set; }

        /// <summary>
        /// Pack type materials.
        /// </summary>
        public DbSet<PackTypeMaterial> PackTypeMaterials { get; set; }

        /// <summary>
        /// Weight units.
        /// </summary>
        public DbSet<WeightUnit> WeightUnits { get; set; }

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
        /// Employee user accounts.
        /// </summary>
        public DbSet<EmployeeUserAccount> EmployeeUserAccounts { get; set; }
    }
}