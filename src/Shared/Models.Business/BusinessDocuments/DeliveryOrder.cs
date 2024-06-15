using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.Shared.Models.Business.Monetary;
using WorkflowLib.Shared.Models.Business.Processes;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Delivery order.
    /// </summary>
    public class DeliveryOrder : Order, IBusinessEntityWF
    {
        /// <summary>
        /// Parent delivery order.
        /// </summary>
        public DeliveryOrder? ParentDeliveryOrder { get; set; }
        
        /// <summary>
        /// Delivery method.
        /// </summary>
        public DeliveryMethod? DeliveryMethod { get; set; }
        
        /// <summary>
        /// Price for the delivery.
        /// </summary>
        public decimal DeliveryPrice { get; set; }
        
        /// <summary>
        /// Initial address of the delivery.
        /// </summary>
        public string? Origin { get; set; }
        
        /// <summary>
        /// Final address of the delivery (destination).
        /// </summary>
        public string? Destination { get; set; }
    }
}