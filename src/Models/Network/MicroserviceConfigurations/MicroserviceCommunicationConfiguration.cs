namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// 
    /// </summary>
    public class MicroserviceCommunicationConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CallingEndpointId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CalledEndpointId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NetworkInteractionId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? TimeoutLimit { get; set; }

        /// <summary>
        /// Limit of attempts to establish network communication.
        /// </summary>
        public int? AttemptsLimit { get; set; }
    }
}
