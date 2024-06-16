using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Responsibilities
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