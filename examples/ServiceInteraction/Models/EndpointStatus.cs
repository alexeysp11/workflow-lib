using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Endpoint status.
    /// </summary>
    public enum EndpointStatus
    {
        Unknown,
        Active,
        Inactive,
        Delete
    }
}