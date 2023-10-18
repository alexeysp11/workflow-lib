using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Absense : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public UserAccount User { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public AbsenseReason Reason { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public AbsenseStatus Status { get; set; }
    }
}