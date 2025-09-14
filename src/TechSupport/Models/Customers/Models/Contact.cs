namespace VelocipedeUtils.Examples.TechSupport.Customers.Models;

public class Contact
{
    public int ContactId { get; set; }
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsPrimaryContact { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}