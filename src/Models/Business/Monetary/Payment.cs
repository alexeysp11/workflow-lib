namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }
        
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