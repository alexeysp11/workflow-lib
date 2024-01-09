using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.Delivery
{
    /// <summary>
    /// Model for transferring a finished order from the kitchen to the warehouse 
    /// (shipping point, destination, start time, end time, products, order number, generated order QR code).
    /// </summary>
    public class DeliveryKitchen2Wh : DeliveryOperation, IBusinessEntityWF
    {
        /// <summary>
        /// Order number.
        /// </summary>
        public string? OrderNumber { get; set; }

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
