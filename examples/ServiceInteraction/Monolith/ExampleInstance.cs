using WorkflowLib.Examples.ServiceInteraction.BL;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Monolith
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class ExampleInstance : IExampleInstance
    {
        private ConfigResolver m_configResolver { get; set; }
        private ServiceA m_serviceA { get; set; }

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public ExampleInstance(
            ConfigResolver configResolver,
            ServiceA serviceA)
        {
            m_configResolver = configResolver;
            m_serviceA = serviceA;
        }

        public void Run()
        {
            // m_configResolver.InitCommunicationConfigs();
            m_serviceA.ProcessPreviousService();
        }
    }
}