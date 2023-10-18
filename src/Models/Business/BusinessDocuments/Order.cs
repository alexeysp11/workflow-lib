using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    public class Order : BusinessEntityWF, IBusinessEntityWF
    {
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