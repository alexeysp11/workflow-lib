using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Absence of an employee.
    /// </summary>
    public class Absense : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
    {
        /// <summary>
        /// Employee that is absent.
        /// </summary>
        public Employee? Employee { get; set; }
        
        /// <summary>
        /// Reason of the absence.
        /// </summary>
        public AbsenseReason Reason { get; set; }
        
        /// <summary>
        /// Status of the absence.
        /// </summary>
        public AbsenseStatus Status { get; set; }
        
        /// <summary>
        /// Actual start date.
        /// </summary>
        public System.DateTime? DateStartActual { get; set; }
        
        /// <summary>
        /// Actual end date.
        /// </summary>
        public System.DateTime? DateEndActual { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? DateStartExpected { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? DateEndExpected { get; set; }
    }
}