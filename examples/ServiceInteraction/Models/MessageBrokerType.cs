using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Examples.ServiceInteraction.Models
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