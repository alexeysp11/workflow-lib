using Microsoft.Extensions.DependencyInjection;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BPInitializers;
using VelocipedeUtils.Shared.ServiceDiscoveryBpm.Routing;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.Webapi.Employee
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
            // var parameters = new PipeDelegateParams
            // {
            //     WorkflowInstanceId = 0,
            //     BPStateTransitionId = 0,
            //     UserId = 1
            // };
            // m_controlPlane.MoveWorkflowInstanceNext(parameters);
        }

        private void Initialize()
        {
            var pipeInitializer = (ProcPipeInitializer) m_serviceProvider.GetRequiredService(typeof(ProcPipeInitializer));
            var transitionInitializer = (BPTransitionInitializer) m_serviceProvider.GetRequiredService(typeof(BPTransitionInitializer));

            pipeInitializer.Initialize();
            transitionInitializer.Initialize();
        }
    }
}