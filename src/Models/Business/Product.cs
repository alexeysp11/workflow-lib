namespace Cims.WorkflowLib.Models.Business
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}