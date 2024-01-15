namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkInteraction
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? NetworkProtocolName { get; set; }

        /// <summary>
        /// Network interaction name: the microservice can be invoked over HTTP or gRPC, 
        /// or via a message broker (such as RabbitMQ or Kafka). 
        /// </summary>
        public string? NetworkInteractionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? ApiMethodName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? QueueName { get; set; }
    }
}