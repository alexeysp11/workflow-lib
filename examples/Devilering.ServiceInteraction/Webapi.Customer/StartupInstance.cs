using Microsoft.Extensions.DependencyInjection;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BPInitializers;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.Webapi.Customer
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private readonly IServiceProvider m_serviceProvider;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartupInstance(
            IServiceProvider serviceProvider)
        {
            m_serviceProvider = serviceProvider;
            Initialize();
        }

        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            // 
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