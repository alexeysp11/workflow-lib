using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.BL.Controllers;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.InitializeDb
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private ConfigResolver m_configResolver;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartupInstance(
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
            classNames.Add(customerBackendName, typeof(CustomerBLController).Name);
            classNames.Add(whBackendName, typeof(WarehouseBLController).Name);
            classNames.Add(courierBackendName, typeof(CourierBLController).Name);
            classNames.Add(kitchenBackendName, typeof(KitchenBLController).Name);
            classNames.Add(fileserviceBackendName, typeof(FileService).Name);
            
            m_configResolver.InitCommunicationConfigs();
            m_configResolver.InitMonolithEndpoints(classNames);
        }
    }
}