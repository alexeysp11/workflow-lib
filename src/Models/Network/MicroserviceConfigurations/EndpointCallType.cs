using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Models.Network.MicroserviceConfigurations
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