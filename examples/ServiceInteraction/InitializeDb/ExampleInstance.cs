using WorkflowLib.Examples.ServiceInteraction.Models;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;

namespace WorkflowLib.Examples.ServiceInteraction.InitializeDb
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class ExampleInstance : IExampleInstance
    {
        private ConfigResolver _configResolver { get; set; }

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public ExampleInstance(
            ConfigResolver configResolver)
        {
            _configResolver = configResolver;
        }

        public void Run()
        {
            _configResolver.InitCommunicationConfigs();
        }
    }
}