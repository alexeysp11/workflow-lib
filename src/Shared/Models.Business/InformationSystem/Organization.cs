using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Organization.
    /// </summary>
    public class Organization : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Company.
        /// </summary>
        public Company? Company { get; set; }
        
        /// <summary>
        /// Head organization item.
        /// </summary>
        public OrganizationItem? HeadItem { get; set; }
        
        /// <summary>
        /// Contracts.
        /// </summary>
        public ICollection<Contract> Contracts { get; private set; }
    }
}