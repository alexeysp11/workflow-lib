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
        private EsbServiceMeshControlPlane m_esbServiceMesh;
        private EsbRoutingConfigs m_esbRoutingConfigs;
        private IImplicitService m_service;
        private readonly IServiceProvider m_serviceProvider;
        private IImplicitService m_serviceA;

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public StartupInstance(
            EsbServiceMeshControlPlane esbServiceMesh,
            EsbRoutingConfigs esbRoutingConfigs,
            ServiceA serviceA,
            IServiceProvider serviceProvider)
        {
            m_esbServiceMesh = esbServiceMesh;
            m_esbRoutingConfigs = esbRoutingConfigs;
            m_service = serviceA;
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
            m_esbServiceMesh.ProcessPreviousService(parameters);
        }

        private void InitProcessingPipes()
        {
            m_esbRoutingConfigs.EsbRoutingEntry = new Dictionary<long, System.Action<IProcessingPipeDelegateParams>>();

            // Get services.
            if (m_serviceProvider == null)
                throw new System.Exception("Could not resolve service provider");
            var serviceA = (ServiceA) m_serviceProvider.GetRequiredService(typeof(ServiceA));
            CustomerPipe.SetService(serviceA);

            // Manually initialize pipes to process requests.
            var customer2whPipe = new ProcessingPipeBuilder(m_esbServiceMesh.ProcessPreviousService)
                .AddPipe(typeof(CustomerPipe))
                .Build();
            m_esbRoutingConfigs.EsbRoutingEntry.Add(4, customer2whPipe);
        }
    }
}