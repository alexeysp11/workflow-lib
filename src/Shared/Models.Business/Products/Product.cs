using System;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Products
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product : WfBusinessEntity, IWfBusinessEntity, ICloneable
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
        public ProductCategory? ProductCategory { get; set; }

        /// <summary>
        /// Picture URL of the product.
        /// </summary>
        public string? PictureUrl { get; set; }

        /// <summary>
        /// Picture description of the product.
        /// </summary>
        public string? PictureDescription { get; set; }

        public Product Clone() { return (Product)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }
    }
}