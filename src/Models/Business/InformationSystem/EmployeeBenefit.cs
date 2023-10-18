using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Employee benifit.
    /// </summary>
    public class EmployeeBenefit : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Employee benifit type.
        /// </summary>
        public EmployeeBenefitType Type { get; set; }
    }
}