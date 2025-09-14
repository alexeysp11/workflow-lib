using System;

namespace VelocipedeUtils.Examples.Retail.Accounting.Services
{
    public class ImportItemInfo
    {
        public int ImportItemId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
    }
}
