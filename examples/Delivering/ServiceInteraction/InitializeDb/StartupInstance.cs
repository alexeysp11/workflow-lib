using System.Collections.Generic;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.Controllers;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.InitializeDb
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private ConfigResolver m_configResolver;
        private BusinessOrderInitializer m_orderInitializer;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartupInstance(
            ConfigResolver configResolver,
            BusinessOrderInitializer orderInitializer)
        {
            m_configResolver = configResolver;
            m_orderInitializer = orderInitializer;
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
            
            // m_configResolver.InitCommunicationConfigs();
            // m_configResolver.InitMonolithEndpoints(classNames);
            m_orderInitializer.ConfigureDbContext();
        }
    }
}