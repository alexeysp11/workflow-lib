using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
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
        public List<Product> Products { get; set; }
        
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