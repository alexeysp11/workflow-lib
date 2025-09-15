namespace VelocipedeUtils.Examples.TechSupport.EventJournal.Models;

/// <summary>
/// Allows you to search for events using various criteria.
/// </summary>
public class EventSearch
{
    /// <summary>
    /// Text string to search in event messages.
    /// </summary>
    public string SearchText { get; set; }

    /// <summary>
    /// Event fields to search by their values.
    /// </summary>
    public List<string> SearchFields { get; set; }
}