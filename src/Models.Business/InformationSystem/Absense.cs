using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Absence of an employee.
    /// </summary>
    public class Absense : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
    {
        /// <summary>
        /// ID of the user that is absent.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// User account related to the employee that is absent.
        /// </summary>
        public UserAccount? User { get; set; }
        
        /// <summary>
        /// Reason of the absence.
        /// </summary>
        public AbsenseReason Reason { get; set; }
        
        /// <summary>
        /// Status of the absence.
        /// </summary>
        public AbsenseStatus Status { get; set; }
        
        /// <summary>
        /// Factual start date.
        /// </summary>
        public System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        public System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? ExpectedEndDate { get; set; }
    }
}