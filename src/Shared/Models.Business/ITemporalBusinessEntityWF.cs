namespace WorkflowLib.Shared.Models.Business
{
    public interface ITemporalBusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// Actual start date.
        /// </summary>
        System.DateTime? DateStartActual { get; set; }
        
        /// <summary>
        /// Actual end date.
        /// </summary>
        System.DateTime? DateEndActual { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        System.DateTime? DateStartExpected { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        System.DateTime? DateEndExpected { get; set; }
    }
}