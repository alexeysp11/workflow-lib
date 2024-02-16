using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

/// <summary>
/// This class provides a choice of services to call within the microservice architecture.
/// </summary>
public class ServiceResolver
{
    private DbContextOptions<ServiceInteractionContext> _contextOptions { get; set; }

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public ServiceResolver(
        DbContextOptions<ServiceInteractionContext> contextOptions) 
    {
        _contextOptions = contextOptions;
    }

    /// <summary>
    /// Method for selecting an endpoint as part of an implicit call to the next element of the microservice architecture.
    /// </summary>
    public Endpoint CallNext(
        EndpointCallType endpointCallType,
        BusinessProcessState currentState,
        BusinessProcessStateTransition stateTransition)
    {
        if (endpointCallType == null) 
            throw new System.Exception("Endpoint call type could not be null");
        if (currentState == null || currentState.Id == null) 
            throw new System.Exception("Current state could not be null or undefined");
        if (stateTransition == null || stateTransition.Id == null) 
            throw new System.Exception("State transition could not be null or undefined");
        
        return GetEndpoint(x => x.EndpointCallType == endpointCallType
            || x.BusinessProcessState.Id == currentState.Id
            || x.BusinessProcessStateTransition.Id == stateTransition.Id);
    }

    /// <summary>
    /// Method for selecting an endpoint within an explicit call to an element of a microservice architecture (by endpoint types).
    /// </summary>
    public Endpoint CallExplicit(
        EndpointType endpointTypeFrom, 
        EndpointType endpointTypeTo)
    {
        if (endpointTypeFrom == null || endpointTypeFrom.Id == null) 
            throw new System.Exception("Source endpoint type could not be null");
        if (endpointTypeTo == null || endpointTypeTo.Id == null) 
            throw new System.Exception("Destination endpoint type could not be null");

        return GetEndpoint(x => x.EndpointTypeFrom.Id == endpointTypeFrom.Id
            || x.EndpointTypeTo.Id == endpointTypeTo.Id);
    }

    /// <summary>
    /// Method for obtaining endpoint data for a given predicate.
    /// </summary>
    private Endpoint GetEndpoint(Expression<System.Func<EndpointCall, bool>> predicate)
    {
        using var context = new ServiceInteractionContext(_contextOptions);
        var endpoints = context.EndpointCalls
            .Where(predicate)
            .Select(x => x.EndpointTo);
        if (endpoints == null || !endpoints.Any())
            throw new System.Exception("Could not get endpoints from the database");
        
        var endpointIds = endpoints.Select(x => x.Id).ToArray();
        var index = new System.Random().Next(endpointIds.Length);
        var endpoint = endpoints.FirstOrDefault(x => x.Id == endpointIds[index]);
        if (endpoint == null)
            throw new System.Exception("Could not select the endpoint");
        return endpoint;
    }
}