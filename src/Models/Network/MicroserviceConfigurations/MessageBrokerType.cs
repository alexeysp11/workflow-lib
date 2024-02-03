using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Network.MicroserviceConfigurations
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