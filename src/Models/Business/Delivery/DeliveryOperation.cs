using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.Processes;

namespace Cims.WorkflowLib.Models.Business.Delivery
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
        /// Previous delivery operation.
        /// </summary>
        public DeliveryOperation Previous { get; set; }

        /// <summary>
        /// Next delivery operation.
        /// </summary>
        public DeliveryOperation Next { get; set; }
        
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
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer name of the order.
        /// </summary>
        public Contact Contact { get; set; }
    }
}