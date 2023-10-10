namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string PictureUrl { get; set; }
        public string PictureDescription { get; set; }
    }
}