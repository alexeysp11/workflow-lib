using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Type of endpoint deployment.
    /// </summary>
    public enum EndpointDeploymentType
    {
        Monolith,
        HTTP,
        gRPC
    }
}