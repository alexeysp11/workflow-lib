using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Product category.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
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