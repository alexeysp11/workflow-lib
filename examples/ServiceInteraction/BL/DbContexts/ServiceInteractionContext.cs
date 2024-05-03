using Microsoft.EntityFrameworkCore;
using WorkflowLib.Models.Business.Processes;
using WorkflowLib.Models.Logging;
using WorkflowLib.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Examples.ServiceInteraction.BL.DbContexts;

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
}