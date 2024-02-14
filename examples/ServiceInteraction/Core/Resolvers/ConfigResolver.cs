using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

/// <summary>
/// This class is responsible for interacting with configuration data 
/// about communication between system components.
/// </summary>
public class ConfigResolver
{
    private DbContextOptions<ServiceInteractionContext> _contextOptions { get; set; }

    /// <summary>
    /// Constructor by default.
    /// </summary>
    public ConfigResolver(
        DbContextOptions<ServiceInteractionContext> contextOptions) 
    {
        _contextOptions = contextOptions;
    }

    /// <summary>
    /// A method that adds logs to the database.
    /// </summary>
    public void AddDbgLog(string sourceName, string sourceDetails)
    {
        using var context = new ServiceInteractionContext(_contextOptions);
        var dbglog = new DbgLog
        {
            SourceName = sourceName,
            SourceDetails = sourceDetails,
            CreateDate = System.DateTime.UtcNow,
            ChangeDate = System.DateTime.UtcNow
        };
        context.DbgLogs.Add(dbglog);
        context.SaveChanges();
    }

    public void CallNext()
    {
        // 
    }

    /// <summary>
    /// 
    /// </summary>
    public void InitCommunicationConfigs()
    {
        using var context = new ServiceInteractionContext(_contextOptions);

        var stringBuilder = new StringBuilder();
        var dtNow = System.DateTime.UtcNow;

        // Backend service names.
        var customerBackendName = "Customer backend";
        var whBackendName = "Warehouse backend";
        var courierBackendName = "Courier backend";
        var kitchenBackendName = "Kitchen backend";
        var fileserviceBackendName = "File service";
        var backendServiceNames = new List<string>
        {
            customerBackendName,
            whBackendName,
            courierBackendName,
            kitchenBackendName,
            fileserviceBackendName
        };

        // Endpoint call type names.
        var endpointCallTypes = new List<string>
        {
            EndpointCallType.Monolith.ToString(),
            EndpointCallType.HTTP.ToString(),
            EndpointCallType.gRPC.ToString()
        };

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
            
            endpointCalls.Add(new EndpointCall
            {
                EndpointTypeFrom = customerEndpointType,
                EndpointTypeTo = fileserviceEndpointType,
                EndpointCallType = callTypeEnum,
                BusinessProcessState = customerState
            });
            endpointCalls.Add(new EndpointCall
            {
                EndpointTypeFrom = customerEndpointType,
                EndpointTypeTo = whEndpointType,
                EndpointCallType = callTypeEnum,
                BusinessProcessState = customerState,
                BusinessProcessStateTransition = customer_wh2kitchen
            });
            endpointCalls.Add(new EndpointCall
            {
                EndpointTypeFrom = whEndpointType,
                EndpointTypeTo = kitchenEndpointType,
                EndpointCallType = callTypeEnum,
                BusinessProcessState = wh2kitchenState,
                BusinessProcessStateTransition = wh2kitchen_kitchen
            });
            endpointCalls.Add(new EndpointCall
            {
                EndpointTypeFrom = kitchenEndpointType,
                EndpointTypeTo = whEndpointType,
                EndpointCallType = callTypeEnum,
                BusinessProcessState = kitchenState,
                BusinessProcessStateTransition = kitchen_wh2courier
            });
            endpointCalls.Add(new EndpointCall
            {
                EndpointTypeFrom = whEndpointType,
                EndpointTypeTo = courierEndpointType,
                EndpointCallType = callTypeEnum,
                BusinessProcessState = wh2courierState,
                BusinessProcessStateTransition = wh2courier_courier
            });
        }

        context.BusinessProcesses.Add(process);
        context.BusinessProcessStates.AddRange(states);
        context.BusinessProcessStateTransitions.AddRange(transitions);
        context.EndpointTypes.AddRange(endpointTypes);
        context.EndpointCalls.AddRange(endpointCalls);

        context.SaveChanges();
    }
}
