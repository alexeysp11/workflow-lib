using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
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