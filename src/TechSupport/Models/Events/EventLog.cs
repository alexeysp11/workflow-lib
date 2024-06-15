using System.Collections.Generic;

namespace WorkflowLib.Examples.TechSupport.EventJournal.Models;

/// <summary>
/// Stores a collection of all recorded events.
/// </summary>
public class EventLog
{
    /// <summary>
    /// Collection of all recorded events.
    /// </summary>
    public IEnumerable<Event> Events { get; set; }
}