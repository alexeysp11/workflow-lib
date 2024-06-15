using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// Type of the network interaction details.
    /// </summary>
    public enum NetworkInteractionDetailsType
    {
        Monolith,
        HTTP,
        gRPC
    }
}