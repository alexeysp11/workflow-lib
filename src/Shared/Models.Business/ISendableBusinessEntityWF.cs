namespace WorkflowLib.Shared.Models.Business
{
    /// <summary>
    /// Business entity in the workflow-lib.
    /// </summary>
    public interface ISendableBusinessEntityWF : IBusinessEntityWF
    {
        /// <summary>
        /// Date the business entity was sent.
        /// </summary>
        System.DateTime? DateSent { get; set; }
    }
}