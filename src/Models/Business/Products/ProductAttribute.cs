using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product attribute.
    /// </summary>
    public class ProductAttribute : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }
        
        /// <summary>
        /// Attribute name.
        /// </summary>
        public string? AttributeName { get; set; }
        
        /// <summary>
        /// Product attribute type.
        /// </summary>
        public ProductAttributeType? ProductAttributeType { get; set; }
    }
}