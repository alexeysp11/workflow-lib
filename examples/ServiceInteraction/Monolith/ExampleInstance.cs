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
        private IImplicitService m_service { get; set; }

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public ExampleInstance(
            ServiceA serviceA)
        {
            m_service = serviceA;
        }

        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            m_service.ProcessPreviousService();
        }
    }
}