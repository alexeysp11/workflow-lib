using System.Collections.Generic;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.RuntimeQueues;

/// <summary>
/// An interface that allows you to manage a message queue within an application instance.
/// </summary>
public interface IMessageFileQueue
{
    /// <summary>
    /// Implementation of the duplicate request collapse.
    /// </summary>
    DuplicateRequestCollapseType DuplicateRequestCollapseType { get; }

    /// <summary>
    /// Determines whether an element with the specified key is in the message queue.
    /// </summary>
    bool IsMessageInQueue(string key);

    /// <summary>
    /// Enqueues a message into the message queue.
    /// </summary>
    void EnqueueMessage(MessageFile message);

    /// <summary>
    /// Dequeues a specified number of messages from the message queue.
    /// </summary>
    List<MessageFile> DequeueMessages(int count);

    /// <summary>
    /// Enqueues a message into the logging queue as processed elements.
    /// </summary>
    void EnqueueMessageLogging(MessageFile message);

    /// <summary>
    /// Dequeues a specified number of messages from the logging queue as processed elements.
    /// </summary>
    List<MessageFile> DequeueMessagesLogging(int count);

    /// <summary>
    /// Enqueues an exception message into the exception logging queue.
    /// </summary>
    void EnqueueExceptionLogging(string exceptionMessage);

    /// <summary>
    /// Dequeues a specified number of exception messages from the exception logging queue.
    /// </summary>
    List<string> DequeueExceptionLogging(int count);
}