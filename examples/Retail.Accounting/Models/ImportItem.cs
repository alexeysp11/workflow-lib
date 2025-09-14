using System;

namespace VelocipedeUtils.Examples.Retail.Accounting.Models
{
    public class ImportItem
    {
        public int ImportItemId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int ImportDocId { get; set; }
        public ImportDoc ImportDoc { get; set; }
    }
}
