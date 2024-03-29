using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.BL;
using WorkflowLib.Examples.ServiceInteraction.Core.Constants;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.InitializeDb
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

        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            // Constants.
            var customerBackendName = ServiceConfigConstants.CustomerBackendName;
            var whBackendName = ServiceConfigConstants.WhBackendName;
            var courierBackendName = ServiceConfigConstants.CourierBackendName;
            var kitchenBackendName = ServiceConfigConstants.KitchenBackendName;
            var fileserviceBackendName = ServiceConfigConstants.FileserviceBackendName;
            
            // Class names.
            var classNames = new Dictionary<string, string>();
            classNames.Add(customerBackendName, typeof(ServiceA).Name);
            classNames.Add(whBackendName, typeof(ServiceB).Name);
            classNames.Add(courierBackendName, typeof(ServiceC).Name);
            classNames.Add(kitchenBackendName, typeof(ServiceD).Name);
            classNames.Add(fileserviceBackendName, typeof(ServiceE).Name);
            
            // m_configResolver.InitCommunicationConfigs();
            m_configResolver.InitMonolithEndpoints(classNames);
        }
    }
}