using System.Collections.Generic;
using WorkflowLib.Models.Business.BusinessDocuments;
using WorkflowLib.Models.Business.Customers;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Organization.
    /// </summary>
    public class Organization : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Company.
        /// </summary>
        public Company Company { get; set; }
        
        /// <summary>
        /// Head organization item.
        /// </summary>
        public OrganizationItem HeadItem { get; set; }
        
        /// <summary>
        /// Contracts.
        /// </summary>
        public ICollection<Contract> Contracts { get; private set; }
    }
}