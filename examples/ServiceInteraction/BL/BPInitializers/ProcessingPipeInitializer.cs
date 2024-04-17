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
    private readonly IServiceProvider m_serviceProvider;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ProcessingPipeInitializer(
        EsbControlPlane controlPlane,
        EsbRoutingConfigs esbRoutingConfigs,
        IServiceProvider serviceProvider)
    {
        m_controlPlane = controlPlane;
        m_esbRoutingConfigs = esbRoutingConfigs;
        m_serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Performs processing pipes initialization.
    /// </summary>
    public void Initialize()
    {
        m_esbRoutingConfigs.EsbRoutingEntries = new Dictionary<long, System.Action<IProcessingPipeDelegateParams>>();
        m_esbRoutingConfigs.Transition2EdpointCallDictionary = new Dictionary<long, long>();

        // Get services.
        if (m_serviceProvider == null)
            throw new System.Exception("Could not resolve service provider");
        BusinessStatePipe.SetEsbServiceRegistry(m_controlPlane);
        var customerController = (CustomerBLController) m_serviceProvider.GetRequiredService(typeof(CustomerBLController));
        CustomerPipe.SetService(customerController);
        var warehouseController = (WarehouseBLController) m_serviceProvider.GetRequiredService(typeof(WarehouseBLController));
        WarehousePipe.SetService(warehouseController);
        var courierController = (CourierBLController) m_serviceProvider.GetRequiredService(typeof(CourierBLController));
        CourierPipe.SetService(courierController);
        var kitchenController = (KitchenBLController) m_serviceProvider.GetRequiredService(typeof(KitchenBLController));
        KitchenPipe.SetService(kitchenController);

        // Build pipes.
        var customerPipe = new ProcessingPipeBuilder(m_controlPlane.ProcessPreviousService)
            .AddPipe(typeof(CustomerPipe))
            .AddPipe(typeof(BusinessStatePipe))
            .Build();
        var warehousePipe = new ProcessingPipeBuilder(m_controlPlane.ProcessPreviousService)
            .AddPipe(typeof(WarehousePipe))
            .AddPipe(typeof(BusinessStatePipe))
            .Build();
        var kitchenPipe = new ProcessingPipeBuilder(m_controlPlane.ProcessPreviousService)
            .AddPipe(typeof(KitchenPipe))
            .AddPipe(typeof(BusinessStatePipe))
            .Build();

        // Manually map pipes to process requests.
        m_esbRoutingConfigs.EsbRoutingEntries.Add(4, customerPipe);
        m_esbRoutingConfigs.EsbRoutingEntries.Add(7, warehousePipe);
        m_esbRoutingConfigs.EsbRoutingEntries.Add(10, kitchenPipe);
        m_esbRoutingConfigs.EsbRoutingEntries.Add(13, warehousePipe);

        // Manually map current transition ID to endpoint call ID.
        m_esbRoutingConfigs.Transition2EdpointCallDictionary.Add(0, 4);
        m_esbRoutingConfigs.Transition2EdpointCallDictionary.Add(1, 7);
        m_esbRoutingConfigs.Transition2EdpointCallDictionary.Add(2, 10);
        m_esbRoutingConfigs.Transition2EdpointCallDictionary.Add(3, 13);
    }
}