namespace WorkflowLib.Examples.TechSupport.Customers.Models;

public class ActivityLog
{
    public int ActivityLogId { get; set; }
    public int UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public string Description { get; set; }
    public DateTime ActivityDate { get; set; }
    public string IPAddress { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}