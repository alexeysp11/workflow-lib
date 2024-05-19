namespace WorkflowLib.Models.Business
{
    /// <summary>
    /// Business entity in the workflow-lib.
    /// </summary>
    public interface ISendableBusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// Timestamp when the message was sent.
        /// </summary>
        System.DateTime? DateSent { get; set; }
    }
}