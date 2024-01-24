namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// Microservice communication configuration.
    /// </summary>
    public class MicroserviceCommunicationConfiguration
    {
        /// <summary>
        /// ID of microservice communication configuration.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Endpoint ID which is going to start the communication.
        /// </summary>
        public int CallingEndpointId { get; set; }

        /// <summary>
        /// Endpoint ID that is going to be called.
        /// </summary>
        public int CalledEndpointId { get; set; }

        /// <summary>
        /// ID of the record that stores information about the network interaction.
        /// </summary>
        public int NetworkInteractionId { get; set; }
        
        /// <summary>
        /// Timout limit.
        /// </summary>
        public int? TimeoutLimit { get; set; }

        /// <summary>
        /// Limit of attempts to establish network communication.
        /// </summary>
        public int? AttemptsLimit { get; set; }
    }
}
