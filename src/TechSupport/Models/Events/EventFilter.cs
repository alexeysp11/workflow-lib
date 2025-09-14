namespace VelocipedeUtils.Examples.TechSupport.EventJournal.Models;

/// <summary>
/// Allows you to filter events by various criteria.
/// </summary>
public class EventFilter
{
    /// <summary>
    /// Event type to filter by.
    /// </summary>
    public EventType? EventType { get; set; }

    /// <summary>
    /// Event source to filter by.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Start of the period to which you want to apply the filter.
    /// </summary>
    public DateTime DateBegin { get; set; }

    /// <summary>
    /// End of the period to which you want to apply the filter.
    /// </summary>
    public DateTime DateEnd { get; set; }

    /// <summary>
    /// Text search for event messages.
    /// </summary>
    public string SearchText { get; set; }
}