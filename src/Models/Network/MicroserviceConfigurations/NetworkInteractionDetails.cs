namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// Record that stores information about the network interaction.
    /// </summary>
    public class NetworkInteractionDetails
    {
        /// <summary>
        /// ID of the network interaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Network protocol name.
        /// </summary>
        public string? NetworkProtocolName { get; set; }

        /// <summary>
        /// Network interaction name: the microservice can be invoked over HTTP or gRPC, 
        /// or via a message broker (such as RabbitMQ or Kafka). 
        /// </summary>
        public string? NetworkInteractionName { get; set; }

        /// <summary>
        /// API method name.
        /// </summary>
        public string? ApiMethodName { get; set; }

        /// <summary>
        /// Queue name in the message broker.
        /// </summary>
        public string? QueueName { get; set; }
    }
}