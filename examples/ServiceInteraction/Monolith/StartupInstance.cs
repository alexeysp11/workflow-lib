using WorkflowLib.Examples.ServiceInteraction.BL;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Monolith
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private IImplicitService m_service;

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public StartupInstance(
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