using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Absence of an employee.
    /// </summary>
    public class Absense : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// ID of the user that is absent.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// User account related to the employee that is absent.
        /// </summary>
        public UserAccount User { get; set; }
        
        /// <summary>
        /// Timestamp when the absence started.
        /// </summary>
        public System.DateTime StartDate { get; set; }
        
        /// <summary>
        /// Timestamp when the absence finished.
        /// </summary>
        public System.DateTime EndDate { get; set; }
        
        /// <summary>
        /// Reason of the absence.
        /// </summary>
        public AbsenseReason Reason { get; set; }
        
        /// <summary>
        /// Status of the absence.
        /// </summary>
        public AbsenseStatus Status { get; set; }
    }
}