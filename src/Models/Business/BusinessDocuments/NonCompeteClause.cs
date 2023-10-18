using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    public class NonCompeteClause : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public string GeographicArea { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string LimitedScope { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string LegitimateCompetitiveInterest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeCompensation { get; set; }
    }
}