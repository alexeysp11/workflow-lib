using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Shared.Models.Network.MicroserviceConfigurations
{
    /// <summary>
    /// Type of the message broker.
    /// </summary>
    public enum MessageBrokerType
    {
        RabbitMQ,
        Kafka
    }
}