namespace WorkflowLib.Examples.TechSupport.Customers.Models;

public class CustomerSatisfaction
{
    public int CustomerSatisfactionId { get; set; }
    public int CustomerId { get; set; }
    public string SurveyId { get; set; }
    public string Response { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
    public DateTime SurveyDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}