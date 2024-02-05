using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Type of endpoint call.
    /// </summary>
    public enum EndpointCallType
    {
        Monolith,
        HTTP,
        gRPC
    }
}