using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Contexts;

public class ServiceInteractionContext : DbContext
{
    public ServiceInteractionContext(DbContextOptions<ServiceInteractionContext> options) : base(options) { }
    
    public DbSet<DbgLog> DbgLogs { get; set; }

    public DbSet<Endpoint> Endpoints { get; set; }
    public DbSet<EndpointType> EndpointTypes { get; set; }
    public DbSet<EndpointCall> EndpointCalls { get; set; }

    public DbSet<BusinessProcess> BusinessProcesses { get; set; }
    public DbSet<BusinessProcessState> BusinessProcessStates { get; set; }
    public DbSet<BusinessProcessStateTransition> BusinessProcessStateTransitions { get; set; }
}
