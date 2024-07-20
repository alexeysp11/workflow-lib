using System.Collections.Generic;
using WorkflowLib.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.InitializeDb;

/// <summary>
/// Represents a class that stores constants for configuring services in the application.
/// </summary>
public static class ServiceConfigConstants
{
    /// <summary>
    /// The name of the Customer backend service.
    /// </summary>
    public static readonly string CustomerBackendName = "Customer backend";

    /// <summary>
    /// The name of the Warehouse backend service.
    /// </summary>
    public static readonly string WhBackendName = "Warehouse backend";

    /// <summary>
    /// The name of the Courier backend service.
    /// </summary>
    public static readonly string CourierBackendName = "Courier backend";

    /// <summary>
    /// The name of the Kitchen backend service.
    /// </summary>
    public static readonly string KitchenBackendName = "Kitchen backend";

    /// <summary>
    /// The name of the File service.
    /// </summary>
    public static readonly string FileserviceBackendName = "File service";

    /// <summary>
    /// A list of backend service names including Customer, Warehouse, Courier, Kitchen, and File service.
    /// </summary>
    public static readonly List<string> BackendServiceNames = new List<string>
    {
        CustomerBackendName,
        WhBackendName,
        CourierBackendName,
        KitchenBackendName,
        FileserviceBackendName
    };

    /// <summary>
    /// The type of an Endpoint call as Monolith.
    /// </summary>
    public static readonly string EndpointCallTypeMonolith = EndpointCallType.Monolith.ToString();

    /// <summary>
    /// The type of an Endpoint call as HTTP.
    /// </summary>
    public static readonly string EndpointCallTypeHTTP = EndpointCallType.HTTP.ToString();

    /// <summary>
    /// The type of an Endpoint call as gRPC.
    /// </summary>
    public static readonly string EndpointCallTypeGRPC = EndpointCallType.gRPC.ToString();

    /// <summary>
    /// A list of Endpoint call types including Monolith, HTTP, and gRPC.
    /// </summary>
    public static readonly List<string> EndpointCallTypes = new List<string>
    {
        EndpointCallTypeMonolith,
        EndpointCallTypeHTTP,
        EndpointCallTypeGRPC
    };
}