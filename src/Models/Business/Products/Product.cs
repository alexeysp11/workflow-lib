using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product : BusinessEntityWF, IBusinessEntityWF
    {
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