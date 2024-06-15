namespace WorkflowLib.Shared.Models.Business
{
    /// <summary>
    /// Business entity in the workflow-lib.
    /// </summary>
    public interface IReceivableBusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// Date the business entity was received.
        /// </summary>
        System.DateTime? DateReceived { get; set; }
    }
}