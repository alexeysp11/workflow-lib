using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Network.MicroserviceConfigurations
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