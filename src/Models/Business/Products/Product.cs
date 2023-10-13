namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UID of the product.
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Category of the product.
        /// </summary>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Picture URL of the product.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Picture description of the product.
        /// </summary>
        public string PictureDescription { get; set; }
    }
}