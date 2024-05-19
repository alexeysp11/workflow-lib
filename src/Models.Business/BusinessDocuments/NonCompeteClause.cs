using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Non-complete clause.
    /// </summary>
    public class NonCompeteClause : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
    {
        /// <summary>
        /// Geographic area.
        /// </summary>
        public string? GeographicArea { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string? LimitedScope { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string? LegitimateCompetitiveInterest { get; set; }

        /// <summary>
        /// ??? 
        /// </summary>
        public string? EmployeeCompensation { get; set; }
        
        /// <summary>
        /// Factual start date.
        /// </summary>
        public System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        public System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? ExpectedEndDate { get; set; }
    }
}