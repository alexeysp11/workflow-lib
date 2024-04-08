using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.ServiceInteraction.BL.BLProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.ProcessingPipes;
using WorkflowLib.Examples.ServiceInteraction.Core.Routing;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Monolith
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private EsbControlPlane m_controlPlane;
        private EsbRoutingConfigs m_esbRoutingConfigs;
        private IImplicitService m_service;
        private readonly IServiceProvider m_serviceProvider;
        private IImplicitService m_serviceA;

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public StartupInstance(
            EsbControlPlane controlPlane,
            EsbRoutingConfigs esbRoutingConfigs,
            CustomerController customerController,
            IServiceProvider serviceProvider)
        {
            m_controlPlane = controlPlane;
            m_esbRoutingConfigs = esbRoutingConfigs;
            m_service = customerController;
            m_serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            // m_service.ProcessPreviousService();

            InitProcessingPipes();
            var parameters = new ValueProcessingPipeDelegateParams
            {
                WorkflowInstanceId = 0,
                BusinessProcessStateTransitionId = 0,
                UserId = 1
            };
            m_controlPlane.ProcessPreviousService(parameters);
        }

        private void InitProcessingPipes()
        {
            m_esbRoutingConfigs.EsbRoutingEntry = new Dictionary<long, System.Action<IProcessingPipeDelegateParams>>();

            // Get services.
            if (m_serviceProvider == null)
                throw new System.Exception("Could not resolve service provider");
            BusinessStatePipe.SetEsbServiceRegistry(m_controlPlane);
            var customerController = (CustomerController) m_serviceProvider.GetRequiredService(typeof(CustomerController));
            CustomerPipe.SetService(customerController);
            var warehouseController = (WarehouseController) m_serviceProvider.GetRequiredService(typeof(WarehouseController));
            WarehousePipe.SetService(warehouseController);
            var courierController = (CourierController) m_serviceProvider.GetRequiredService(typeof(CourierController));
            CourierPipe.SetService(courierController);
            var kitchenController = (KitchenController) m_serviceProvider.GetRequiredService(typeof(KitchenController));
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
            m_esbRoutingConfigs.EsbRoutingEntry.Add(4, customerPipe);
            m_esbRoutingConfigs.EsbRoutingEntry.Add(7, warehousePipe);
            m_esbRoutingConfigs.EsbRoutingEntry.Add(10, kitchenPipe);
            m_esbRoutingConfigs.EsbRoutingEntry.Add(13, warehousePipe);
        }
    }
}