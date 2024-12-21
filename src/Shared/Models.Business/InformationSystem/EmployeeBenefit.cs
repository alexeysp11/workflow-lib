using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Employee benifit.
    /// </summary>
    public class EmployeeBenefit : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Employee benifit type.
        /// </summary>
        public EmployeeBenefitType Type { get; set; }
    }
}