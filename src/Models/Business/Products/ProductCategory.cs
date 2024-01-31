using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product category.
    /// </summary>
    public class ProductCategory : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Products.
        /// </summary>
        public ICollection<Product> Products { get; set; }
        
        /// <summary>
        /// Picture URL.
        /// </summary>
        public string? PictureUrl { get; set; }
        
        /// <summary>
        /// Picture description.
        /// </summary>
        public string? PictureDescription { get; set; }
        
        /// <summary>
        /// Product category type.
        /// </summary>
        public ProductCategoryType? ProductCategoryType { get; set; }
    }
}