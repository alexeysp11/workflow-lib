using Cims.WorkflowLib.Models.Business.Customer;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class Project
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContractId { get; private set; }        

        /// <summary>
        /// 
        /// </summary>
        public virtual Company CompanyCustomer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime StartDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime EndDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ActualEndDate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int GuaranteePeriodInMonths { get; private set; }        

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee Manager { get; private set; }

        //public virtual CompanyContract Contract { get; private set; }
    }
}