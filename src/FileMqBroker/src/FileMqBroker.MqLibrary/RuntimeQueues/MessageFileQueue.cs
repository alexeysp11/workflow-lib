using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.RuntimeQueues;

/// <summary>
/// A class that allows you to manage a message queue within an application instance.
/// </summary>
public class MessageFileQueue : IMessageFileQueue
{
    private readonly DuplicateRequestCollapseType _collapseType;
    private ConcurrentDictionary<string, MessageFile> _messageQueueDictionary;
    private ConcurrentQueue<MessageFile> _messageQueue;
    private ConcurrentQueue<MessageFile> _loggingQueue;
    private ConcurrentQueue<string> _exceptionQueue;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MessageFileQueue(AppInitConfigs appInitConfigs)
    {
        _collapseType = appInitConfigs.DuplicateRequestCollapseType;
        _messageQueueDictionary = new ConcurrentDictionary<string, MessageFile>();
        _messageQueue = new ConcurrentQueue<MessageFile>();
        _loggingQueue = new ConcurrentQueue<MessageFile>();
        _exceptionQueue = new ConcurrentQueue<string>();
    }
    
    /// <summary>
    /// Implementation of the duplicate request collapse.
    /// </summary>
    public DuplicateRequestCollapseType DuplicateRequestCollapseType
    {
        get
        {
            return _collapseType;
        }
    }

    /// <summary>
    /// Determines whether an element with the specified key is in the message queue.
    /// </summary>
    public bool IsMessageInQueue(string key)
    {
        return _messageQueueDictionary.ContainsKey(key);
    }
    
    /// <summary>
    /// Enqueues a message into the message queue.
    /// </summary>
    public void EnqueueMessage(MessageFile message)
    {
        if (_collapseType == DuplicateRequestCollapseType.Advanced)
        {
            if (!IsMessageInQueue(message.CollapseHashCode))
            {
                _messageQueueDictionary.TryAdd(message.CollapseHashCode, message);
                _messageQueue.Enqueue(message);
            }
        }
        else
        {
            _messageQueue.Enqueue(message);
        }
    }

    /// <summary>
    /// Dequeues a specified number of messages from the message queue.
    /// </summary>
    public List<MessageFile> DequeueMessages(int count)
    {
        var messages = DequeueItems(_messageQueue, count);
        
        if (_collapseType == DuplicateRequestCollapseType.Advanced)
        {
            foreach (var message in messages)
            {
                if (IsMessageInQueue(message.CollapseHashCode))
                {
                    _messageQueueDictionary.TryRemove(message.CollapseHashCode, out _);
                }
            }
        }

        return messages;
    }

    /// <summary>
    /// Enqueues a message into the logging queue as processed elements.
    /// </summary>
    public void EnqueueMessageLogging(MessageFile message)
    {
        _loggingQueue.Enqueue(message);
    }

    /// <summary>
    /// Dequeues a specified number of messages from the logging queue as processed elements.
    /// </summary>
    public List<MessageFile> DequeueMessagesLogging(int count)
    {
        return DequeueItems(_loggingQueue, count);
    }

    /// <summary>
    /// Enqueues an exception message into the exception logging queue.
    /// </summary>
    public void EnqueueExceptionLogging(string exceptionMessage)
    {
        _exceptionQueue.Enqueue(exceptionMessage);
    }

    /// <summary>
    /// Dequeues a specified number of exception messages from the exception logging queue.
    /// </summary>
    public List<string> DequeueExceptionLogging(int count)
    {
        return DequeueItems(_exceptionQueue, count);
    }

    /// <summary>
    /// Method for getting a certain number of elements from a given collection.
    /// </summary>
    private List<T> DequeueItems<T>(ConcurrentQueue<T> queue, int count)
    {
        var items = new List<T>();
        int remainingCount = count;

        while (remainingCount > 0 && queue.Count > 0)
        {
            if (queue.TryDequeue(out T item))
            {
                items.Add(item);
                remainingCount--;
            }
        }
        return items;
    }
}