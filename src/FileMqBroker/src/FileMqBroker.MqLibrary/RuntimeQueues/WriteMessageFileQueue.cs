using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.RuntimeQueues;

/// <summary>
/// A class that allows you to manage a response message queue within an application instance.
/// </summary>
public class WriteMessageFileQueue : MessageFileQueue
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public WriteMessageFileQueue(AppInitConfigs appInitConfigs) : base(appInitConfigs)
    {
    }
}