using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Shared.Models.Business;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;
using VelocipedeUtils.Shared.Models.Business.Cooking;
using VelocipedeUtils.Shared.Models.Business.Customers;
using VelocipedeUtils.Shared.Models.Business.Delivery;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;
using VelocipedeUtils.Shared.Models.Business.Monetary;
using VelocipedeUtils.Shared.Models.Business.Processes;
using VelocipedeUtils.Shared.Models.Business.Products;
using VelocipedeUtils.Shared.Models.Business.SocialCommunication;
using VelocipedeUtils.Shared.Models.Logging;
using VelocipedeUtils.Shared.Models.Network;
using VelocipedeUtils.Shared.Models.Network.MicroserviceConfigurations;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DbContexts;

/// <summary>
/// Represents the database context for Service Interaction in the application.
/// </summary>
public class ServiceInteractionDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the ServiceInteractionDbContext class with the specified options.
    /// </summary>
    /// <param name="options">The DbContextOptions to be used by the context.</param>
    public ServiceInteractionDbContext(DbContextOptions<ServiceInteractionDbContext> options) : base(options) { }
    
    /// <summary>
    /// Gets or sets the DbSet of DbgLog entities in the context.
    /// </summary>
    public DbSet<DbgLog> DbgLogs { get; set; }

    #region Service discovery/BPM
    /// <summary>
    /// Gets or sets the DbSet of Endpoint entities in the context.
    /// </summary>
    public DbSet<Endpoint> Endpoints { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of EndpointType entities in the context.
    /// </summary>
    public DbSet<EndpointType> EndpointTypes { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of EndpointCall entities in the context.
    /// </summary>
    public DbSet<EndpointCall> EndpointCalls { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of BPStateEndpointCall entities in the context.
    /// </summary>
    public DbSet<BPStateEndpointCall> BPStateEndpointCalls { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of BusinessProcess entities in the context.
    /// </summary>
    public DbSet<BusinessProcess> BusinessProcesses { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of BusinessProcessState entities in the context.
    /// </summary>
    public DbSet<BusinessProcessState> BusinessProcessStates { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of BusinessProcessStateTransition entities in the context.
    /// </summary>
    public DbSet<BusinessProcessStateTransition> BusinessProcessStateTransitions { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of BusinessTask entities in the context.
    /// </summary>
    public DbSet<BusinessTask> BusinessTasks { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of WorkflowInstance entities in the context.
    /// </summary>
    public DbSet<WorkflowInstance> WorkflowInstances { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of WorkflowTrackingItem entities in the context.
    /// </summary>
    public DbSet<WorkflowTrackingItem> WorkflowTrackingItems { get; set; }
    #endregion  // Service discovery/BPM

    #region Business orders and deliverings
    /// <summary>
    /// Gets or sets the DbSet of UserAccount entities in the context.
    /// </summary>
    public DbSet<UserAccount> UserAccounts { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of UserGroup entities in the context.
    /// </summary>
    public DbSet<UserGroup> UserGroups { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of UserAccountGroup entities in the context.
    /// </summary>
    public DbSet<UserAccountGroup> UserAccountGroups { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Customer entities in the context.
    /// </summary>
    public DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Contact entities in the context.
    /// </summary>
    public DbSet<Contact> Contacts { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Organization entities in the context.
    /// </summary>
    public DbSet<Organization> Organizations { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of OrganizationItem entities in the context.
    /// </summary>
    public DbSet<OrganizationItem> OrganizationItems { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Company entities in the context.
    /// </summary>
    public DbSet<Company> Companies { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Employee entities in the context.
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Comment entities in the context.
    /// </summary>
    public DbSet<Comment> Comments { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Order entities in the context.
    /// </summary>
    public DbSet<Order> Orders { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of OrderProduct entities in the context.
    /// </summary>
    public DbSet<OrderProduct> OrderProducts { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of InitialOrder entities in the context.
    /// </summary>
    public DbSet<InitialOrder> InitialOrders { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of InitialOrderProduct entities in the context.
    /// </summary>
    public DbSet<InitialOrderProduct> InitialOrderProducts { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of InitialOrderIngredient entities in the context.
    /// </summary>
    public DbSet<InitialOrderIngredient> InitialOrderIngredients { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of DeliveryOrder entities in the context.
    /// </summary>
    public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of DeliveryOrderProduct entities in the context.
    /// </summary>
    public DbSet<DeliveryOrderProduct> DeliveryOrderProducts { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of BusinessTaskDeliveryOrder entities in the context.
    /// </summary>
    public DbSet<BusinessTaskDeliveryOrder> BusinessTaskDeliveryOrders { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of DeliveryMethod entities in the context.
    /// </summary>
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of Payment entities in the context.
    /// </summary>
    public DbSet<Payment> Payments { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of ProductCategory entities in the context.
    /// </summary>
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of Product entities in the context.
    /// </summary>
    public DbSet<Product> Products { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of WHProduct entities in the context.
    /// </summary>
    public DbSet<WHProduct> WHProducts { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of Ingredient entities in the context.
    /// </summary>
    public DbSet<Ingredient> Ingredients { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of Recipe entities in the context.
    /// </summary>
    public DbSet<Recipe> Recipes { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of ProductTransfer entities in the context.
    /// </summary>
    public DbSet<ProductTransfer> ProductTransfers { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of Notification entities in the context.
    /// </summary>
    public DbSet<Notification> Notifications { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of DeliveryWh2Kitchen entities in the context.
    /// </summary>
    public DbSet<DeliveryWh2Kitchen> DeliveriesWh2Kitchen { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of DeliveryKitchen2Wh entities in the context.
    /// </summary>
    public DbSet<DeliveryKitchen2Wh> DeliveriesKitchen2Wh { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of DeliveryOperation entities in the context.
    /// </summary>
    public DbSet<DeliveryOperation> DeliveryOperations { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet of CookingOperation entities in the context.
    /// </summary>
    public DbSet<CookingOperation> CookingOperations { get; set; }
    #endregion  // Business orders and deliverings
}