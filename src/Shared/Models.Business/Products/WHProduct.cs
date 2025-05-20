using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Products
{
    /// <summary>
    /// Warehouse product.
    /// </summary>
    public class WHProduct : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Code of the warehouse product.
        /// </summary>
        public string? Code { get; set; }

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