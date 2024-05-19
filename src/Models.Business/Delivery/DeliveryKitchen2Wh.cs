using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.Delivery
{
    /// <summary>
    /// Model for transferring a finished order from the kitchen to the warehouse 
    /// (shipping point, destination, start time, end time, products, order number, generated order QR code).
    /// </summary>
    public class DeliveryKitchen2Wh : DeliveryOperation, IBusinessEntityWF
    {
        /// <summary>
        /// Generated QR code attached to the order.
        /// </summary>
        public string? GeneratedOrderQrCode { get; set; }
        
        /// <summary>
        /// Initial orders.
        /// </summary>
        public ICollection<InitialOrder> InitialOrders { get; set; }

        /// <summary>
        /// Initial order products.
        /// </summary>
        public ICollection<InitialOrderProduct> InitialOrderProducts { get; set; }
    }
}
