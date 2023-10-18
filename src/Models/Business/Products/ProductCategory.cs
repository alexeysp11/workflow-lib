using System.Collections.Generic;

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
        public string PictureUrl { get; set; }
        
        /// <summary>
        /// Picture description.
        /// </summary>
        public string PictureDescription { get; set; }
    }
}