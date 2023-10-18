using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product category.
    /// </summary>
    public class ProductCategory : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Product> Products { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PictureUrl { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PictureDescription { get; set; }
    }
}