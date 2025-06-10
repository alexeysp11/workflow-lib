using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.DirectoryOperations;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.RuntimeQueues;

namespace FileMqBroker.MqLibrary.QueueDispatchers;

/// <summary>
/// Performs a key mediator role within message queue processing.
/// </summary>
public interface IMqDispatcher
{
    /// <summary>
    /// Method for processing the message queue.
    /// </summary>
    void ProcessMessageQueue();
}