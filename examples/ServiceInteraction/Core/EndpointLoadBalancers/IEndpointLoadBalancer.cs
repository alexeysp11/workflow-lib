namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointLoadBalancers;

/// <summary>
/// 
/// </summary>
public interface IEndpointLoadBalancer
{
    string GetNextEndpoint();
}