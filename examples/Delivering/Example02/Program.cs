// The program for initializing data regarding to settings of microservice communication (without adding data to the database).
// 
// Possible backend services:
// - customer
// - warehouse
// - kitchen
// - courier
// - fileservice
// - notifications
// - esb proxy
// - esb writer
// - esb reader

using System.Linq;
using VelocipedeUtils.Shared.Models.Network.MicroserviceConfigurations;

var endpoints = new List<Endpoint>();
var serviceNames = new List<string>
{
    "customer",
    "warehouse",
    "kitchen",
    "courier",
    "fileservice",
    "notifications",
    "esb proxy",
    "esb writer",
    "esb reader"
};

// Monolith components.
InitializeMonolithComponents();

// HTTP components.
InitializeHttpComponents();

// gRPC components.
InitializeGrpcComponents();

// Print all endpoints.
PrintEndpoints();

void InitializeMonolithComponents()
{
    System.Console.WriteLine("Initializing monolith components...");
    
    // 
    var postfix = " monolith";
    var tmpEndpoints = new List<Endpoint>();
    foreach (var serviceName in serviceNames)
    {
        tmpEndpoints.Add(new Endpoint
        {
            Name = serviceName + postfix
        });
    }

    EstablishConnections(tmpEndpoints, NetworkInteractionDetailsType.Monolith);

    endpoints.AddRange(tmpEndpoints);

    System.Console.WriteLine("Monolith components initialized.");
}

void InitializeHttpComponents()
{
    System.Console.WriteLine("Initializing HTTP components...");

    // 
    var postfix = " HTTP";
    var tmpEndpoints = new List<Endpoint>();
    foreach (var serviceName in serviceNames)
    {
        tmpEndpoints.Add(new Endpoint
        {
            Name = serviceName + postfix
        });
    }

    endpoints.AddRange(tmpEndpoints);

    System.Console.WriteLine("HTTP components initialized.");
}

void InitializeGrpcComponents()
{
    System.Console.WriteLine("Initializing gRPC components...");

    // 
    var postfix = " gRPC";
    var tmpEndpoints = new List<Endpoint>();
    foreach (var serviceName in serviceNames)
    {
        tmpEndpoints.Add(new Endpoint
        {
            Name = serviceName + postfix
        });
    }

    endpoints.AddRange(tmpEndpoints);

    System.Console.WriteLine("gRPC components initialized.");
}

void EstablishConnections(
    List<Endpoint> tmpEndpoints, 
    NetworkInteractionDetailsType interactionType)
{
    if (tmpEndpoints == null)
        throw new System.ArgumentNullException(nameof(tmpEndpoints));
    if (!tmpEndpoints.Any())
        throw new System.Exception("List of the endpoints could not be empty");
    
    var customer = tmpEndpoints.FirstOrDefault(x => x.Name.Contains("customer"));
    var warehouse = tmpEndpoints.FirstOrDefault(x => x.Name.Contains("warehouse"));
    var kitchen = tmpEndpoints.FirstOrDefault(x => x.Name.Contains("kitchen"));
    var courier = tmpEndpoints.FirstOrDefault(x => x.Name.Contains("courier"));
    
    if (customer == null)
        throw new System.ArgumentNullException(nameof(customer));
    if (warehouse == null)
        throw new System.ArgumentNullException(nameof(warehouse));
    if (kitchen == null)
        throw new System.ArgumentNullException(nameof(kitchen));
    if (courier == null)
        throw new System.ArgumentNullException(nameof(courier));

    // 
    var customer2warehouse = new MicroserviceCommunicationConfiguration
    {
        EndpointFrom = customer,
        EndpointTo = warehouse,
        NetworkInteractionDetails = new NetworkInteractionDetails
        {
            Type = interactionType
        }
    };
    var warehouse2kitchen = new MicroserviceCommunicationConfiguration
    {
        EndpointFrom = warehouse,
        EndpointTo = kitchen,
        NetworkInteractionDetails = new NetworkInteractionDetails
        {
            Type = interactionType
        }
    };
    var warehouse2courier = new MicroserviceCommunicationConfiguration
    {
        EndpointFrom = warehouse,
        EndpointTo = courier,
        NetworkInteractionDetails = new NetworkInteractionDetails
        {
            Type = interactionType
        }
    };
    var kitchen2warehouse = new MicroserviceCommunicationConfiguration
    {
        EndpointFrom = kitchen,
        EndpointTo = warehouse,
        NetworkInteractionDetails = new NetworkInteractionDetails
        {
            Type = interactionType
        }
    };
    var courier2warehouse = new MicroserviceCommunicationConfiguration
    {
        EndpointFrom = courier,
        EndpointTo = warehouse,
        NetworkInteractionDetails = new NetworkInteractionDetails
        {
            Type = interactionType
        }
    };
}

void PrintEndpoints()
{
    System.Console.WriteLine();
    System.Console.WriteLine("All the endpoints:");
    foreach (var endpoint in endpoints)
    {
        System.Console.WriteLine("- " + endpoint.Name);
    }
}
