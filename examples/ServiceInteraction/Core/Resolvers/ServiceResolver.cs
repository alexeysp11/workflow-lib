using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

/// <summary>
/// This class provides a choice of services to call within the microservice architecture.
/// </summary>
public class ServiceResolver
{
    private EndpointDAL m_endpointDAL { get; set; }
    private EndpointSelectionParameter m_endpointSelectionParameter { get; set; }
    private IEndpointLoadBalancer m_loadBalancer { get; set; }

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public ServiceResolver(
        EndpointDAL endpointDAL, 
        EndpointSelectionParameter endpointSelectionParameter, 
        IEndpointLoadBalancer loadBalancer)
    {
        m_endpointDAL = endpointDAL;
        m_endpointSelectionParameter = endpointSelectionParameter;
        m_loadBalancer = loadBalancer;
    }

    /// <summary>
    /// Method for selecting an endpoint as part of an implicit call to the next element of the microservice architecture.
    /// </summary>
    public Endpoint GetNextEndpoint(
        EndpointCallType endpointCallType,
        BusinessProcessState currentState,
        BusinessProcessStateTransition stateTransition)
    {
        if (endpointCallType == null) 
            throw new System.Exception("Endpoint call type could not be null");
        if (currentState == null || currentState.Id == null) 
            throw new System.Exception("Current state could not be null or undefined");
        
        return m_endpointDAL.GetEndpoint(x => x.EndpointCallType == endpointCallType
            && x.BusinessProcessState.Id == currentState.Id
            && (stateTransition == null || x.BusinessProcessStateTransition.Id == stateTransition.Id));
    }

    /// <summary>
    /// Method for selecting an endpoint within an explicit call to an element of a microservice architecture (by endpoint types).
    /// </summary>
    public Endpoint GetEndpointExplicit(
        EndpointType endpointTypeFrom, 
        EndpointType endpointTypeTo)
    {
        if (endpointTypeFrom == null || endpointTypeFrom.Id == null) 
            throw new System.Exception("Source endpoint type could not be null");
        if (endpointTypeTo == null || endpointTypeTo.Id == null) 
            throw new System.Exception("Destination endpoint type could not be null");

        return m_endpointDAL.GetEndpoint(x => x.EndpointTypeFrom.Id == endpointTypeFrom.Id
            && x.EndpointTypeTo.Id == endpointTypeTo.Id);
    }
}