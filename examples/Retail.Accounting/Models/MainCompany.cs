namespace WorkflowLib.Examples.Retail.Accounting.Models
{
    public struct MainCompany
    {
        public MainCompany(string companyName, string owner, 
            string country, string city)
        {
            CompanyName = companyName; 
            Owner = owner; 
            Country = country; 
            City = city; 
        }
        
        public string CompanyName { get; set; }
        public string Owner { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}