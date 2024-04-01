using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.Responsibilities
{
    /// <summary>
    /// Employer responsibility.
    /// </summary>
    public class EmployerResponsibility : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Employer responsibility type.
        /// </summary>
        public EmployerResponsibilityType ResponsibilityType { get; set; }
    }
}