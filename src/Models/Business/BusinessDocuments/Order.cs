namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    public class Order
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime OpenOrderDt { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CloseOrderDt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}