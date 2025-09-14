namespace Banking.Core.Models
{
    public class Customer
    {
        private int CustomerId { get; set; }
        private string FullName { get; set; }

        private System.DateTime DateOfBirth { get; set; }

        private string Nationality { get; set; }
        
        private string Country { get; set; }
        private string City { get; set; }
        private string Address { get; set; }

        private string Occupation { get; set; }
    }
}
