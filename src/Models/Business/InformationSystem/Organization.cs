using Cims.WorkflowLib.Models.Business.Customers;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
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
    }
}