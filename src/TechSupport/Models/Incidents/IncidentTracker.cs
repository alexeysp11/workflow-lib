namespace WorkflowLib.Examples.TechSupport.Incidents.Models;

/// <summary>
/// Allows you to track the progress of incidents.
/// </summary>
public class IncidentTracker
{
    /// <summary>
    /// Incident Update Collection.
    /// </summary>
    public List<IncidentUpdate> Updates { get; set; }

    /// <summary>
    /// Incident Action Collection.
    /// </summary>
    public List<IncidentAction> Actions { get; set; }

    /// <summary>
    /// Collection of incident status changes.
    /// </summary>
    public List<IncidentStatusChange> StatusChanges { get; set; }
}