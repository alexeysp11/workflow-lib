using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.BusinessDocuments
{
    public class OrganizationContract : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Organization.
        /// </summary>
        public Organization? Organization { get; set; }

        /// <summary>
        /// Contract.
        /// </summary>
        public Contract? Contract { get; set; }
    }
}