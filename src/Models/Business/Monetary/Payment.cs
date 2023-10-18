using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class Payment : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public string PaymentType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PaymentMethod { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string CardNumber { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Payer { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Receiver { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}