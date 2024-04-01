using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.Delivery
{
    /// <summary>
    /// Model for transferring products from warehouse to kitchen 
    /// (shipping point, destination, start time, end time, products, ingredients).
    /// </summary>
    public class DeliveryWh2Kitchen : DeliveryOperation, IBusinessEntityWF
    {
        /// <summary>
        /// Initial orders.
        /// </summary>
        public ICollection<InitialOrder> InitialOrders { get; set; }

        /// <summary>
        /// Initial order products.
        /// </summary>
        public ICollection<InitialOrderProduct> InitialOrderProducts { get; set; }

        /// <summary>
        /// Initial order ingredients.
        /// </summary>
        public ICollection<InitialOrderIngredient> InitialOrderIngredients { get; set; }
    }
}
