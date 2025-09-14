namespace VelocipedeUtils.Examples.TechSupport.Incidents.Models;

/// <summary>
/// Incident statuses.
/// </summary>
public enum IncidentStatus
{
    /// <summary>
    /// New incident.
    /// </summary>
    New,

    /// <summary>
    /// Incident that is being processed.
    /// </summary>
    InProgress,

    /// <summary>
    /// Incident resolved.
    /// </summary>
    Resolved,

    /// <summary>
    /// Incident closed.
    /// </summary>
    Closed
}