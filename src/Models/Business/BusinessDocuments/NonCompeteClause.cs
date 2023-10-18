using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Non-complete clause.
    /// </summary>
    public class NonCompeteClause : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Geographic area.
        /// </summary>
        public string GeographicArea { get; set; }

        /// <summary>
        /// Period.
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
        /// ??? 
        /// </summary>
        public string EmployeeCompensation { get; set; }
    }
}