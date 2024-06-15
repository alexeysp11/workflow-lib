namespace WorkflowLib.Examples.TechSupport.EventJournal.Models;

/// <summary>
/// Provides an interface to view detailed information about each event.
/// </summary>
public class EventViewer
{
    /// <summary>
    /// Event selected for viewing.
    /// </summary>
    public Event SelectedEvent { get; set; }
}