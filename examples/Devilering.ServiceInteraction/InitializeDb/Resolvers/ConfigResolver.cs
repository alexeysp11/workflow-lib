using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.InitializeDb;

/// <summary>
/// This class is responsible for interacting with configuration data 
/// about communication between system components.
/// </summary>
public class ConfigResolver
{
    private DbContextOptions<ServiceInteractionDbContext> m_contextOptions;

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public ConfigResolver(
        DbContextOptions<ServiceInteractionDbContext> contextOptions) 
    {
        m_contextOptions = contextOptions;
    }

    /// <summary>
    /// Initialize communication configs.
    /// </summary>
    public void InitCommunicationConfigs()
    {
        using var context = new ServiceInteractionDbContext(m_contextOptions);

        var stringBuilder = new StringBuilder();
        var dtNow = System.DateTime.UtcNow;

        // Backend service names.
        var customerBackendName = ServiceConfigConstants.CustomerBackendName;
        var whBackendName = ServiceConfigConstants.WhBackendName;
        var courierBackendName = ServiceConfigConstants.CourierBackendName;
        var kitchenBackendName = ServiceConfigConstants.KitchenBackendName;
        var fileserviceBackendName = ServiceConfigConstants.FileserviceBackendName;
        var backendServiceNames = ServiceConfigConstants.BackendServiceNames;

        // Endpoint call type names.
        var endpointCallTypes = ServiceConfigConstants.EndpointCallTypes;

        // Process.
        var process = new BusinessProcess
        {
            Name = "Delivering of the order",
            DateCreated = dtNow
        };

        // Process states.
        var customerState = new BusinessProcessState
        {
            Name = customerBackendName,
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var wh2kitchenState = new BusinessProcessState
        {
            Name = whBackendName + " (wh2kitchen)",
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var wh2courierState = new BusinessProcessState
        {
            Name = whBackendName + " (wh2courier)",
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var courierState = new BusinessProcessState
        {
            Name = courierBackendName,
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var kitchenState = new BusinessProcessState
        {
            Name = kitchenBackendName,
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var fileserivceState = new BusinessProcessState
        {
            Name = fileserviceBackendName,
            BusinessProcess = process,
            DateCreated = dtNow
        };
        var states = new List<BusinessProcessState>
        {
            customerState,
            wh2kitchenState,
            wh2courierState,
            courierState,
            kitchenState,
            fileserivceState
        };

        // Transitions.
        var customer_wh2kitchen = new BusinessProcessStateTransition
        {
            BusinessProcess = process,
            FromState = customerState,
            ToState = wh2kitchenState,
            DateCreated = dtNow
        };
        var wh2kitchen_kitchen = new BusinessProcessStateTransition
        {
            BusinessProcess = process,
            FromState = wh2kitchenState,
            ToState = kitchenState,
            DateCreated = dtNow
        };
        var kitchen_wh2courier = new BusinessProcessStateTransition
        {
            BusinessProcess = process,
            FromState = kitchenState,
            ToState = wh2courierState,
            DateCreated = dtNow
        };
        var wh2courier_courier = new BusinessProcessStateTransition
        {
            BusinessProcess = process,
            FromState = wh2courierState,
            ToState = courierState,
            DateCreated = dtNow
        };
        customer_wh2kitchen.Previous = null;
        wh2kitchen_kitchen.Previous = customer_wh2kitchen;
        kitchen_wh2courier.Previous = wh2kitchen_kitchen;
        wh2courier_courier.Previous = kitchen_wh2courier;
        var transitions = new List<BusinessProcessStateTransition>
        {
            customer_wh2kitchen,
            wh2kitchen_kitchen,
            kitchen_wh2courier,
            wh2courier_courier
        };

        // Endpoint types.
        var endpointTypes = new List<EndpointType>();
        foreach (var endpointShortName in backendServiceNames)
        {
            foreach (var endpointCallType in endpointCallTypes)
            {
                stringBuilder.Clear();
                stringBuilder.Append(endpointShortName).Append(" ").Append(endpointCallType);
                endpointTypes.Add(new EndpointType
                {
                    Name = stringBuilder.ToString()
                });
            }
        }

        // Endpoint calls.
        var endpointCalls = new List<EndpointCall>();
        var bpStateEndpointCalls = new List<BPStateEndpointCall>();
        foreach (var endpointCallType in endpointCallTypes)
        {
            EndpointCallType callTypeEnum;
            if (!System.Enum.TryParse(endpointCallType, out callTypeEnum))
                throw new System.Exception("Could not convert string into endpoint call type enumeration");
            
            var specificEndpointTypes = endpointTypes.Where(x => x.Name.Contains(endpointCallType));
            if (specificEndpointTypes == null || !specificEndpointTypes.Any())
                continue;
            
            var customerEndpointType = specificEndpointTypes.FirstOrDefault(x => x.Name.Contains(customerBackendName));
            var whEndpointType = specificEndpointTypes.FirstOrDefault(x => x.Name.Contains(whBackendName));
            var courierEndpointType = specificEndpointTypes.FirstOrDefault(x => x.Name.Contains(courierBackendName));
            var kitchenEndpointType = specificEndpointTypes.FirstOrDefault(x => x.Name.Contains(kitchenBackendName));
            var fileserviceEndpointType = specificEndpointTypes.FirstOrDefault(x => x.Name.Contains(fileserviceBackendName));
            
            if (customerEndpointType == null)
                throw new System.ArgumentNullException(nameof(customerEndpointType));
            if (whEndpointType == null)
                throw new System.ArgumentNullException(nameof(whEndpointType));
            if (courierEndpointType == null)
                throw new System.ArgumentNullException(nameof(courierEndpointType));
            if (kitchenEndpointType == null)
                throw new System.ArgumentNullException(nameof(kitchenEndpointType));
            if (fileserviceEndpointType == null)
                throw new System.ArgumentNullException(nameof(fileserviceEndpointType));
            
            var ec_customer_fileservice = new EndpointCall
            {
                EndpointTypeFrom = customerEndpointType,
                EndpointTypeTo = fileserviceEndpointType,
                EndpointCallType = callTypeEnum
            };
            var ec_customer_wh2kitchen = new EndpointCall
            {
                EndpointTypeFrom = customerEndpointType,
                EndpointTypeTo = whEndpointType,
                EndpointCallType = callTypeEnum
            };
            var ec_wh2kitchen_kitchen = new EndpointCall
            {
                EndpointTypeFrom = whEndpointType,
                EndpointTypeTo = kitchenEndpointType,
                EndpointCallType = callTypeEnum
            };
            var ec_kitchen_wh2courier = new EndpointCall
            {
                EndpointTypeFrom = kitchenEndpointType,
                EndpointTypeTo = whEndpointType,
                EndpointCallType = callTypeEnum
            };
            var ec_wh2courier_courier = new EndpointCall
            {
                EndpointTypeFrom = whEndpointType,
                EndpointTypeTo = courierEndpointType,
                EndpointCallType = callTypeEnum
            };
            endpointCalls.Add(ec_customer_fileservice);
            endpointCalls.Add(ec_customer_wh2kitchen);
            endpointCalls.Add(ec_wh2kitchen_kitchen);
            endpointCalls.Add(ec_kitchen_wh2courier);
            endpointCalls.Add(ec_wh2courier_courier);

            customer_wh2kitchen.EndpointCall = ec_customer_wh2kitchen;
            wh2kitchen_kitchen.EndpointCall = ec_wh2kitchen_kitchen;
            kitchen_wh2courier.EndpointCall = ec_kitchen_wh2courier;
            wh2courier_courier.EndpointCall = ec_wh2courier_courier;

            bpStateEndpointCalls.Add(new BPStateEndpointCall
            {
                BusinessProcessState = customerState,
                EndpointCall = ec_customer_fileservice
            });
            bpStateEndpointCalls.Add(new BPStateEndpointCall
            {
                BusinessProcessState = customerState,
                EndpointCall = ec_customer_wh2kitchen
            });
            bpStateEndpointCalls.Add(new BPStateEndpointCall
            {
                BusinessProcessState = wh2kitchenState,
                EndpointCall = ec_wh2kitchen_kitchen
            });
            bpStateEndpointCalls.Add(new BPStateEndpointCall
            {
                BusinessProcessState = kitchenState,
                EndpointCall = ec_kitchen_wh2courier
            });
            bpStateEndpointCalls.Add(new BPStateEndpointCall
            {
                BusinessProcessState = wh2courierState,
                EndpointCall = ec_wh2courier_courier
            });
        }

        context.BusinessProcesses.Add(process);
        context.BusinessProcessStates.AddRange(states);
        context.BusinessProcessStateTransitions.AddRange(transitions);
        context.EndpointTypes.AddRange(endpointTypes);
        context.EndpointCalls.AddRange(endpointCalls);
        context.BPStateEndpointCalls.AddRange(bpStateEndpointCalls);

        context.SaveChanges();
    }

    /// <summary>
    /// Initialize endpoints for the monolithic application.
    /// </summary>
    public void InitMonolithEndpoints(Dictionary<string, string> classNames)
    {
        using var context = new ServiceInteractionDbContext(m_contextOptions);

        // Constants.
        var customerBackendName = ServiceConfigConstants.CustomerBackendName;
        var whBackendName = ServiceConfigConstants.WhBackendName;
        var courierBackendName = ServiceConfigConstants.CourierBackendName;
        var kitchenBackendName = ServiceConfigConstants.KitchenBackendName;
        var fileserviceBackendName = ServiceConfigConstants.FileserviceBackendName;
        var backendServiceNames = ServiceConfigConstants.BackendServiceNames;
        var endpointTypeMonolith = ServiceConfigConstants.EndpointCallTypeMonolith;

        var endpointTypes = context.EndpointTypes.Where(x => x.Name.Contains(endpointTypeMonolith));
        if (endpointTypes == null || !endpointTypes.Any())
            throw new System.Exception("Collection of endpoint types could not be null or empty");
        
        var endpoints = new List<Endpoint>();
        foreach (var endpointType in endpointTypes)
        {
            var backendName = backendServiceNames.FirstOrDefault(x => endpointType.Name.Contains(x));
            if (string.IsNullOrEmpty(backendName))
                continue;
            
            endpoints.Add(new Endpoint
            {
                Name = endpointType.Name,
                EndpointType = endpointType,
                ClassName = classNames[backendName]
            });
        }
        context.Endpoints.AddRange(endpoints);

        context.SaveChanges();
    }
}