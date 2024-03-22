using WorkflowLib.Examples.ServiceInteraction.Models;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.Monolith
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class ExampleInstance : IExampleInstance
    {
        private ConfigResolver m_configResolver { get; set; }

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public ExampleInstance(
            ConfigResolver configResolver)
        {
            m_configResolver = configResolver;
        }

        public void Run()
        {
            m_configResolver.InitCommunicationConfigs();
        }
    }
}