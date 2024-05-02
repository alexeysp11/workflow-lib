using System.Collections.Generic;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Warehouse product.
    /// </summary>
    public class WHProduct : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Product.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Minimal allowed quantity of the product.
        /// </summary>
        public int MinQuantity { get; set; }

        /// <summary>
        /// Maximal allowed quantity of the product.
        /// </summary>
        public int MaxQuantity { get; set; }
    }
}