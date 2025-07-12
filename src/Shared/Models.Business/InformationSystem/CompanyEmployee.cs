using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Company employee.
    /// </summary>
    public class CompanyEmployee : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Company.
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public Employee? Employee { get; set; }
    }
}