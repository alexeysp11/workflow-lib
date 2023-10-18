using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// Payment.
    /// </summary>
    public class Payment : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Payment type.
        /// </summary>
        public string PaymentType { get; set; }
        
        /// <summary>
        /// Payment method.
        /// </summary>
        public string PaymentMethod { get; set; }
        
        /// <summary>
        /// Card number.
        /// </summary>
        public string CardNumber { get; set; }
        
        /// <summary>
        /// Amount of the payment.
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Payer.
        /// </summary>
        public string Payer { get; set; }
        
        /// <summary>
        /// Receiver.
        /// </summary>
        public string Receiver { get; set; }
        
        /// <summary>
        /// Status of the payment.
        /// </summary>
        public string Status { get; set; }
    }
}