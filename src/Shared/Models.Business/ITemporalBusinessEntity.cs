namespace WorkflowLib.Shared.Models.Business
{
    /// <summary>
    /// Interface that represents a business entity which is temporal.
    /// </summary>
    public interface ITemporalBusinessEntity : IWfBusinessEntity
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