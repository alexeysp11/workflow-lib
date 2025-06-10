namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Non-complete clause.
    /// </summary>
    public class NonCompeteClause : WfBusinessEntity, IWfBusinessEntity, ITemporalBusinessEntity
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
        /// Actual start date.
        /// </summary>
        public System.DateTime? DateStartActual { get; set; }
        
        /// <summary>
        /// Actual end date.
        /// </summary>
        public System.DateTime? DateEndActual { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? DateStartExpected { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? DateEndExpected { get; set; }
    }
}