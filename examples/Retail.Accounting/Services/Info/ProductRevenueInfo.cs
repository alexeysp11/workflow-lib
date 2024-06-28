namespace WorkflowLib.Examples.Retail.Accounting.Services
{
    public class ProductRevenueInfo
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public float TotalRevenue { get; set; }
        public float WeightedRevenue { get; set; }
        public float ExportQuantity { get; set; }
    }
}