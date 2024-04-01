using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Customers;
using WorkflowLib.Models.Business.Processes;

namespace WorkflowLib.Models.Business.Delivery
{
    /// <summary>
    /// Delivery operation.
    /// </summary>
    public class DeliveryOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Number of the order.
        /// </summary>
        public string OrderNumber { get; set; }
        
        /// <summary>
        /// Delivery method.
        /// </summary>
        public DeliveryMethod DeliveryMethod { get; set; }

        /// <summary>
        /// Initial address of the delivery.
        /// </summary>
        public Address Origin { get; set; }
        
        /// <summary>
        /// Final address of the delivery (destination).
        /// </summary>
        public Address Destination { get; set; }

        /// <summary>
        /// Customer name of the order.
        /// </summary>
        public string? CustomerName { get; set; }

        /// <summary>
        /// Customer name of the order.
        /// </summary>
        public Contact Contact { get; set; }
    }
}