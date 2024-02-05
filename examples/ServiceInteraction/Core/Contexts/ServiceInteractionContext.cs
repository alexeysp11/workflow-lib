using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Contexts;

public class ServiceInteractionContext : DbContext
{
    public DbSet<Endpoint> Endpoints { get; set; }
    public DbSet<EndpointCall> EndpointCalls { get; set; }
}
