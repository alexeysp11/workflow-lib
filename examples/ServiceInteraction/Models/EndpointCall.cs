namespace WorkflowLib.Examples.ServiceInteraction.Models;

/// <summary>
/// Endpoint call.
/// </summary>
public class EndpointCall
{
    /// <summary>
    /// ID of endpoint call.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Endpoint which is going to start the communication.
    /// </summary>
    public Endpoint? EndpointFrom { get; set; }

    /// <summary>
    /// Endpoint that is going to be called.
    /// </summary>
    public Endpoint? EndpointTo { get; set; }
    
    /// <summary>
    /// Type of the network interaction details.
    /// </summary>
    public EndpointCallType EndpointCallType { get; set; }

    /// <summary>
    /// Current business process state.
    /// </summary>
    public BusinessProcessState BusinessProcessState { get; set; }

    /// <summary>
    /// API method name.
    /// </summary>
    public string? ApiMethodName { get; set; }

    /// <summary>
    /// Type of the message broker.
    /// </summary>
    public MessageBrokerType? MessageBrokerType { get; set; }

    /// <summary>
    /// Queue name in the message broker.
    /// </summary>
    public string? QueueName { get; set; }
    
    /// <summary>
    /// Timout limit.
    /// </summary>
    public int? TimeoutLimit { get; set; }

    /// <summary>
    /// Limit of attempts to establish network communication.
    /// </summary>
    public int? AttemptsLimit { get; set; }
}
