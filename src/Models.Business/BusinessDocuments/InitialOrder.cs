using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Products;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Model for placing order, that is used to send request from frontend to the controller.
    /// </summary>
    public class InitialOrder : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// User GUID.
        /// </summary>
        public string? UserUid { get; set; }
        
        /// <summary>
        /// Login of the user.
        /// </summary>
        public string? Login { get; set; }
        
        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public string? PhoneNumber { get; set; }
        
        /// <summary>
        /// City of the delivery.
        /// </summary>
        public string? City { get; set; }
        
        /// <summary>
        /// Address of the delivery.
        /// </summary>
        public string? Address { get; set; }
        
        /// <summary>
        /// List of the product IDs, that user has placed into the order.
        /// </summary>
        [NotMapped]
        public IList<long> ProductIds { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        public string? PaymentType { get; set; }
        
        /// <summary>
        /// Payment method.
        /// </summary>
        public string? PaymentMethod { get; set; }
        
        /// <summary>
        /// Amount of payment.
        /// </summary>
        public decimal PaymentAmount { get; set; }
        
        /// <summary>
        /// Delivery order that is associated with the initial order.
        /// </summary>
        public DeliveryOrder DeliveryOrder { get; set; }
    }
}