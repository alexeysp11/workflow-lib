using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Responsibilities
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployerResponsibility : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public EmployerResponsibilityType ResponsibilityType { get; set; }
    }
}