namespace WorkflowLib.Models.Business
{
    /// <summary>
    /// Business entity in the workflow-lib.
    /// </summary>
    public interface IReceivableBusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// Timestamp when the message was received.
        /// </summary>
        System.DateTime? DateReceived { get; set; }
    }
}