namespace WorkflowLib.Shared.Models.Business
{
    /// <summary>
    /// Business entity in the workflow-lib.
    /// </summary>
    public interface IReceivableWfBusinessEntity : IWfBusinessEntity
    {
        /// <summary>
        /// Date the business entity was received.
        /// </summary>
        System.DateTime? DateReceived { get; set; }
    }
}