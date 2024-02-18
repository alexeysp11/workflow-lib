using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Constants;

/// <summary>
/// 
/// </summary>
public static class ServiceConfigConstants
{
    public static readonly string CustomerBackendName = "Customer backend";
    public static readonly string WhBackendName = "Warehouse backend";
    public static readonly string CourierBackendName = "Courier backend";
    public static readonly string KitchenBackendName = "Kitchen backend";
    public static readonly string FileserviceBackendName = "File service";
    
    public static readonly List<string> BackendServiceNames = new List<string>
    {
        CustomerBackendName,
        WhBackendName,
        CourierBackendName,
        KitchenBackendName,
        FileserviceBackendName
    };

    public static readonly string EndpointCallTypeMonolith = EndpointCallType.Monolith.ToString();
    public static readonly string EndpointCallTypeHTTP = EndpointCallType.HTTP.ToString();
    public static readonly string EndpointCallTypeGRPC = EndpointCallType.gRPC.ToString();

    public static readonly List<string> EndpointCallTypes = new List<string>
    {
        EndpointCallTypeMonolith,
        EndpointCallTypeHTTP,
        EndpointCallTypeGRPC
    };
}