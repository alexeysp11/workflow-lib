namespace WorkflowLib.Examples.TechSupport.Customers.Models;

public class Interaction
{
    public int InteractionId { get; set; }
    public int CustomerId { get; set; }
    public InteractionType InteractionType { get; set; }
    public string Description { get; set; }
    public DateTime InteractionDate { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}