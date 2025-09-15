using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.RuntimeQueues;

/// <summary>
/// A class that allows you to manage a request message queue within an application instance.
/// </summary>
public class ReadMessageFileQueue : MessageFileQueue
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public ReadMessageFileQueue(AppInitConfigs appInitConfigs) : base(appInitConfigs)
    {
    }
}