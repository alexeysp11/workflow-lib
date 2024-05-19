namespace WorkflowLib.Models.Business
{
    public interface ITemporalBusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// Factual start date.
        /// </summary>
        System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        System.DateTime? ExpectedEndDate { get; set; }
    }
}