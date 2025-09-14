namespace VelocipedeUtils.Examples.RealEstateManager.Database.Models
{
    public class Payment 
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateOverdue { get; set; }
        public bool Paid { get; set; }
    }
}