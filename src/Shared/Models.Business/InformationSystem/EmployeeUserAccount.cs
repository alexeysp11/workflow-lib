using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Intermediate table between Employee and UserAccount.
    /// </summary>
    public class EmployeeUserAccount : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Employee.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// User account.
        /// </summary>
        public UserAccount UserAccount { get; set; }
        
        /// <summary>
        /// Create date of the relationship.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}