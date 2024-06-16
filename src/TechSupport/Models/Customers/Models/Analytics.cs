namespace WorkflowLib.Examples.TechSupport.Customers.Models;

/// <summary>
/// Analytics to measure customer satisfaction.
/// </summary>
public class Analytics
{
    /// <summary>
    /// ID in the database.
    /// </summary>
    public int AnalyticsId { get; set; }

    /// <summary>
    /// Analytics collection date.
    /// </summary>
    public DateTime AnalyticsDate { get; set; }

    /// <summary>
    /// Total number of customers.
    /// </summary>
    public int TotalCustomers { get; set; }

    /// <summary>
    /// Number of new customers.
    /// </summary>
    public int NewCustomers { get; set; }

    /// <summary>
    /// Number of technical support requests.
    /// </summary>
    public int SupportRequests { get; set; }

    /// <summary>
    /// Number of placed orders.
    /// </summary>
    public int OrdersPlaced { get; set; }

    /// <summary>
    /// Average Customer Satisfaction Score.
    /// </summary>
    public int AvgCustomerSatisfaction { get; set; }

    /// <summary>
    /// .
    /// </summary>
    public string TopIndustries { get; set; }

    /// <summary>
    /// Creation date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Update date.
    /// </summary>
    public DateTime UpdatedDate { get; set; }
}