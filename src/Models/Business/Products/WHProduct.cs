using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Warehouse product.
    /// </summary>
    public class WHProduct : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; set; }
    }
}