using Microsoft.Extensions.DependencyInjection;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BLProcessingPipes;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BPInitializers;
using WorkflowLib.Examples.Delivering.ServiceInteraction.Core.Routing;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Webapi.Customer
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private EsbControlPlane m_controlPlane;
        private readonly IServiceProvider m_serviceProvider;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartupInstance(
            EsbControlPlane controlPlane,
            IServiceProvider serviceProvider)
        {
            m_controlPlane = controlPlane;
            m_serviceProvider = serviceProvider;
            Initialize();
        }

        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            var parameters = new ValueProcessingPipeDelegateParams
            {
                WorkflowInstanceId = 0,
                BusinessProcessStateTransitionId = 0,
                UserId = 1
            };
            m_controlPlane.MoveWorkflowInstanceNext(parameters);
        }

        private void Initialize()
        {
            var pipeInitializer = (ProcessingPipeInitializer) m_serviceProvider.GetRequiredService(typeof(ProcessingPipeInitializer));
            var transitionInitializer = (BPTransitionInitializer) m_serviceProvider.GetRequiredService(typeof(BPTransitionInitializer));

            pipeInitializer.Initialize();
            transitionInitializer.Initialize();
        }
    }
}