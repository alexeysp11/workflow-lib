using VelocipedeUtils.Examples.TechSupport.Customers.Models;

namespace VelocipedeUtils.Examples.TechSupport.Incidents.Models;

/// <summary>
/// Represents an individual incident.
/// </summary>
public class Incident
{
    /// <summary>
    /// Incident ID.
    /// </summary>
    public int IncidentId { get; set; }

    /// <summary>
    /// Incident number.
    /// </summary>
    public string IncidentNumber { get; set; }

    /// <summary>
    /// Current Incident Status.
    /// </summary>
    public IncidentStatus Status { get; set; }

    /// <summary>
    /// Incident priority.
    /// </summary>
    public IncidentPriority Priority { get; set; }

    /// <summary>
    /// Summary of the incident.
    /// </summary>
    public string Summary { get; set; }

    /// <summary>
    /// Detailed description of the incident.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Customers associated with the incident.
    /// </summary>
    public List<Customer> Customers { get; set; }

    /// <summary>
    /// Products associated with the incident.
    /// </summary>
    public List<Product> Products { get; set; }

    /// <summary>
    /// Services associated with the incident.
    /// </summary>
    public List<Service> Services { get; set; }

    /// <summary>
    /// Date and time the incident record was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Date and time the incident record was last updated.
    /// </summary>
    public DateTime UpdatedDate { get; set; }
}