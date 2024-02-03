namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// Endpoint.
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// ID of the endpoint.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the endpoint.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// IP address of the endpoint
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Port of the endpoint.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Network address of the endpoint.
        /// </summary>
        public string NetworkAddress { get; set; }
    }
}
