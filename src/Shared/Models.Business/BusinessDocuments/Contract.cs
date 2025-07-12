namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Contract.
    /// </summary>
    public class Contract : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Contract type.
        /// </summary>
        public ContractType? ContractType { get; set; }
    }
}