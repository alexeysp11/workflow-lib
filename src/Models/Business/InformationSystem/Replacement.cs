using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Replacement.
    /// </summary>
    public class Replacement : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public int PreReplace { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool DuplicateMessage { get; set; }
        
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
        public UserAccount SourceUser { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount TargetUser { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ReplacementStatus Status { get; set; }
    }
}