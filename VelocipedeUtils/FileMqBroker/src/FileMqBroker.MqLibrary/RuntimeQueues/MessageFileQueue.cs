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
    private readonly DuplicateRequestCollapseType m_collapseType;
    private ConcurrentDictionary<string, MessageFile> m_messageQueueDictionary;
    private ConcurrentQueue<MessageFile> m_messageQueue;
    private ConcurrentQueue<MessageFile> m_loggingQueue;
    private ConcurrentQueue<string> m_exceptionQueue;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MessageFileQueue(AppInitConfigs appInitConfigs)
    {
        m_collapseType = appInitConfigs.DuplicateRequestCollapseType;
        m_messageQueueDictionary = new ConcurrentDictionary<string, MessageFile>();
        m_messageQueue = new ConcurrentQueue<MessageFile>();
        m_loggingQueue = new ConcurrentQueue<MessageFile>();
        m_exceptionQueue = new ConcurrentQueue<string>();
    }
    
    /// <summary>
    /// Implementation of the duplicate request collapse.
    /// </summary>
    public DuplicateRequestCollapseType DuplicateRequestCollapseType
    {
        get
        {
            return m_collapseType;
        }
    }

    /// <summary>
    /// Determines whether an element with the specified key is in the message queue.
    /// </summary>
    public bool IsMessageInQueue(string key)
    {
        return m_messageQueueDictionary.ContainsKey(key);
    }
    
    /// <summary>
    /// Enqueues a message into the message queue.
    /// </summary>
    public void EnqueueMessage(MessageFile message)
    {
        if (m_collapseType == DuplicateRequestCollapseType.Advanced)
        {
            if (!IsMessageInQueue(message.CollapseHashCode))
            {
                m_messageQueueDictionary.TryAdd(message.CollapseHashCode, message);
                m_messageQueue.Enqueue(message);
            }
        }
        else
        {
            m_messageQueue.Enqueue(message);
        }
    }

    /// <summary>
    /// Dequeues a specified number of messages from the message queue.
    /// </summary>
    public List<MessageFile> DequeueMessages(int count)
    {
        var messages = DequeueItems(m_messageQueue, count);
        
        if (m_collapseType == DuplicateRequestCollapseType.Advanced)
        {
            foreach (var message in messages)
            {
                if (IsMessageInQueue(message.CollapseHashCode))
                {
                    m_messageQueueDictionary.TryRemove(message.CollapseHashCode, out _);
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
        m_loggingQueue.Enqueue(message);
    }

    /// <summary>
    /// Dequeues a specified number of messages from the logging queue as processed elements.
    /// </summary>
    public List<MessageFile> DequeueMessagesLogging(int count)
    {
        return DequeueItems(m_loggingQueue, count);
    }

    /// <summary>
    /// Enqueues an exception message into the exception logging queue.
    /// </summary>
    public void EnqueueExceptionLogging(string exceptionMessage)
    {
        m_exceptionQueue.Enqueue(exceptionMessage);
    }

    /// <summary>
    /// Dequeues a specified number of exception messages from the exception logging queue.
    /// </summary>
    public List<string> DequeueExceptionLogging(int count)
    {
        return DequeueItems(m_exceptionQueue, count);
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