using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.DAL;
using VelocipedeUtils.Shared.Models.Network.MicroserviceConfigurations;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.DAL;

/// <summary>
/// A class at the DAL level that performs endpoint-related operations in the database.
/// </summary>
public class EndpointDAL : IEndpointDAL
{
    private DbContextOptions<ServiceInteractionDbContext> m_contextOptions;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public EndpointDAL(
        DbContextOptions<ServiceInteractionDbContext> contextOptions) 
    {
        m_contextOptions = contextOptions;
    }
    
    /// <summary>
    /// Method for obtaining endpoint data for a given predicate.
    /// </summary>
    public Endpoint GetEndpoint(Expression<System.Func<EndpointCall, bool>> predicate)
    {
        if (predicate == null)
            throw new System.ArgumentNullException(nameof(predicate));
        
        using var context = new ServiceInteractionDbContext(m_contextOptions);
        
        var endpointTypeTo = context.EndpointCalls
            .Where(predicate)
            .Select(x => x.EndpointTypeTo)
            .FirstOrDefault();
        if (endpointTypeTo == null)
            throw new System.Exception("Could not get endpoint type from the database");
        
        var endpoints = context.Endpoints.Where(x => x.EndpointType.Id == endpointTypeTo.Id).ToList();
        if (endpoints == null || !endpoints.Any())
            throw new System.Exception("Could not get endpoints from the database");
        if (endpoints.Any(x => x == null))
            throw new System.Exception("Collection of endpoints contains null object references");
        
        var endpointIds = endpoints.Select(x => x.Id).ToArray();
        var index = new System.Random().Next(endpointIds.Length);
        var endpoint = endpoints.FirstOrDefault(x => x.Id == endpointIds[index]);
        if (endpoint == null)
            throw new System.Exception("Could not select the endpoint");
        return endpoint;
    }
}