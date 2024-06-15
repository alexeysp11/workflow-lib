using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Network.MicroserviceConfigurations
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