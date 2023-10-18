using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Order.
    /// </summary>
    public class Order : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Number of the order.
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Timestamp when the order was opened.
        /// </summary>
        public System.DateTime OpenOrderDt { get; set; }
        
        /// <summary>
        /// Timestamp when the order was closed.
        /// </summary>
        public System.DateTime CloseOrderDt { get; set; }

        /// <summary>
        /// Status of the order.
        /// </summary>
        public string Status { get; set; }
    }
}