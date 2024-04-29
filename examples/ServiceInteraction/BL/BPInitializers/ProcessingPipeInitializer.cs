using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.Routing;

namespace WorkflowLib.Examples.ServiceInteraction.BL.BPInitializers;

/// <summary>
/// Processing pipe initializer.
/// </summary>
public class ProcessingPipeInitializer : IBPInitializer
{
    private EsbControlPlane m_controlPlane;
    private EsbRoutingConfigs m_esbRoutingConfigs;
    private StartupInitDetails m_startupInitDetails;
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ProcessingPipeInitializer(
        EsbControlPlane controlPlane,
        EsbRoutingConfigs esbRoutingConfigs,
        StartupInitDetails startupInitDetails,
        IServiceProvider serviceProvider)
    {
        m_controlPlane = controlPlane;
        m_esbRoutingConfigs = esbRoutingConfigs;
        m_startupInitDetails = startupInitDetails;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Performs processing pipes initialization.
    /// </summary>
    public void Initialize()
    {
        m_esbRoutingConfigs.Transition2Delegate = new Dictionary<long, System.Action<IProcessingPipeDelegateParams>>();

        if (m_serviceProvider == null)
            throw new System.Exception("Could not resolve service provider");
        BusinessStatePipe.SetEsbServiceRegistry(m_controlPlane);
        
        var appClientType = m_startupInitDetails.ApplicationClientType;
        switch (appClientType)
        {
            case ApplicationClientType.Customer:
                InitializeCustomerApp();
                break;
            case ApplicationClientType.Employee:
                InitializeEmployeeApp();
                break;
            default:
                InitializeCustomerApp();
                InitializeEmployeeApp();
                break;
        }
    }

    private void InitializeCustomerApp()
    {
        // Get services.
        var customerController = (CustomerBLController) m_serviceProvider.GetRequiredService(typeof(CustomerBLController));
        CustomerPipe.SetService(customerController);

        Action<IProcessingPipeDelegateParams> customerPipe;
        var appDeploymentType = m_startupInitDetails.ApplicationDeploymentType;
        switch (appDeploymentType)
        {
            case ApplicationDeploymentType.Monolith:
                // Build pipes.
                customerPipe = new ProcessingPipeBuilder(m_controlPlane.MoveWorkflowInstanceNext)
                    .AddPipe(typeof(CustomerPipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                
                // Manually map transition ID to the specified delegate.
                m_esbRoutingConfigs.Transition2Delegate.Add(0, customerPipe);
                break;
            case ApplicationDeploymentType.WebAPI:
                // Build pipes.
                customerPipe = new ProcessingPipeBuilder(m_controlPlane.PreserveServiceState)
                    .AddPipe(typeof(CustomerPipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                
                // Manually map transition ID to the specified delegate.
                m_esbRoutingConfigs.Transition2Delegate.Add(0, customerPipe);
                break;
            default:
                throw new System.NotImplementedException();
        }
    }

    private void InitializeEmployeeApp()
    {
        // Get services.
        var warehouseController = (WarehouseBLController) m_serviceProvider.GetRequiredService(typeof(WarehouseBLController));
        WarehousePipe.SetService(warehouseController);
        var kitchenController = (KitchenBLController) m_serviceProvider.GetRequiredService(typeof(KitchenBLController));
        KitchenPipe.SetService(kitchenController);
        var courierController = (CourierBLController) m_serviceProvider.GetRequiredService(typeof(CourierBLController));
        CourierPipe.SetService(courierController);
        
        Action<IProcessingPipeDelegateParams> warehousePipe;
        Action<IProcessingPipeDelegateParams> kitchenPipe;
        Action<IProcessingPipeDelegateParams> courierPipe;
        var appDeploymentType = m_startupInitDetails.ApplicationDeploymentType;
        switch (appDeploymentType)
        {
            case ApplicationDeploymentType.Monolith:
                // Build pipes.
                warehousePipe = new ProcessingPipeBuilder(m_controlPlane.MoveWorkflowInstanceNext)
                    .AddPipe(typeof(WarehousePipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                kitchenPipe = new ProcessingPipeBuilder(m_controlPlane.MoveWorkflowInstanceNext)
                    .AddPipe(typeof(KitchenPipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                courierPipe = new ProcessingPipeBuilder(m_controlPlane.MoveWorkflowInstanceNext)
                    .AddPipe(typeof(CourierPipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                
                // Manually map transition ID to the specified delegate.
                m_esbRoutingConfigs.Transition2Delegate.Add(1, warehousePipe);
                m_esbRoutingConfigs.Transition2Delegate.Add(2, kitchenPipe);
                m_esbRoutingConfigs.Transition2Delegate.Add(3, warehousePipe);
                break;
            case ApplicationDeploymentType.WebAPI:
                // Build pipes.
                warehousePipe = new ProcessingPipeBuilder(m_controlPlane.PreserveServiceState)
                    .AddPipe(typeof(WarehousePipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                kitchenPipe = new ProcessingPipeBuilder(m_controlPlane.PreserveServiceState)
                    .AddPipe(typeof(KitchenPipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                courierPipe = new ProcessingPipeBuilder(m_controlPlane.PreserveServiceState)
                    .AddPipe(typeof(CourierPipe))
                    .AddPipe(typeof(BusinessStatePipe))
                    .Build();
                
                // Manually map transition ID to the specified delegate.
                m_esbRoutingConfigs.Transition2Delegate.Add(1, warehousePipe);
                m_esbRoutingConfigs.Transition2Delegate.Add(2, kitchenPipe);
                m_esbRoutingConfigs.Transition2Delegate.Add(3, warehousePipe);
                break;
            default:
                throw new System.NotImplementedException();
        }
    }
}