using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Cooking;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.Delivery
{
    /// <summary>
    /// Model for transferring products from warehouse to kitchen 
    /// (shipping point, destination, start time, end time, products, ingredients).
    /// </summary>
    public class DeliveryWh2Kitchen : DeliveryOperation, IWfBusinessEntity
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
