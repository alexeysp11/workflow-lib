using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Processes;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Delivery order.
    /// </summary>
    public class DeliveryOrder : Order, IBusinessEntityWF
    {
        /// <summary>
        /// Delivery method.
        /// </summary>
        public DeliveryMethod DeliveryMethod { get; set; }
        
        /// <summary>
        /// Preparing operations for the delivery order.
        /// </summary>
        public ICollection<BusinessTask> PreparingOperations { get; set; }
        
        /// <summary>
        /// Delivery operation.
        /// </summary>
        public DeliveryOperation DeliveryOperation { get; set; }
        
        /// <summary>
        /// Price for the delivery.
        /// </summary>
        public decimal DeliveryPrice { get; set; }
                
        /// <summary>
        /// Initial address of the delivery.
        /// </summary>
        public Address Origin { get; set; }
        
        /// <summary>
        /// Final address of the delivery (destination).
        /// </summary>
        public Address Destination { get; set; }
    }
}