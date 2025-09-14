namespace VelocipedeUtils.Examples.TechSupport.EventJournal.Models;

/// <summary>
/// Represents a separate event.
/// </summary>
public class Event
{
    /// <summary>
    /// Event ID.
    /// </summary>
    public int EventId { get; set; }

    /// <summary>
    /// Event date and time.
    /// </summary>
    public DateTime EventDate { get; set; }

    /// <summary>
    /// Event source, such as a service or application.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Event type, such as error, warning, or informational message.
    /// </summary>
    public EventType EventType { get; set; }

    /// <summary>
    /// Event message describing the event that occurred.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Additional event information such as call stack or debug information.
    /// </summary>
    public string Details { get; set; }

    /// <summary>
    /// Date and time the event entry was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Date and time the event record was last updated.
    /// </summary>
    public DateTime UpdatedDate { get; set; }
}