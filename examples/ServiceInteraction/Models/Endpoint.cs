using System.ComponentModel.DataAnnotations.Schema;

namespace WorkflowLib.Examples.ServiceInteraction.Models;

/// <summary>
/// Endpoint.
/// </summary>
public class Endpoint
{
    private EndpointStatus? m_status;

    /// <summary>
    /// ID of the endpoint.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// Name of the endpoint.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Name of the class that represents the endpoint in the monolith.
    /// </summary>
    public string? ClassName { get; set; }
    
    /// <summary>
    /// IP address of the endpoint
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Port of the endpoint.
    /// </summary>
    public int? Port { get; set; }

    /// <summary>
    /// Network address of the endpoint.
    /// </summary>
    public string? NetworkAddress { get; set; }

    /// <summary>
    /// Endpoint type.
    /// </summary>
    public EndpointType? EndpointType { get; set; }

    /// <summary>
    /// Endpoint deployment type.
    /// </summary>
    public EndpointDeploymentType? EndpointDeploymentType { get; set; }
    
    /// <summary>
    /// Endpoint status.
    /// </summary>
    public EndpointStatus? Status 
    { 
        get => m_status;
        private set
        {
            m_status = value;
            LastStatusChange = System.DateTime.Now;
        }
    }
    
    /// <summary>
    /// Time of last endpoint status change.
    /// </summary>
    [NotMapped]
    public System.DateTime? LastStatusChange { get; private set; }
}
