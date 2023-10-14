using Cims.WorkflowLib.Models.Business.Customers;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// 
        /// </summary>
        public Company Company { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public OrganizationItem HeadItem { get; set; }
    }
}