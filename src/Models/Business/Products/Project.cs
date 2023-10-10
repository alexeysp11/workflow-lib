using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Project
    {
        public string Name { get; private set; }

        public bool IsActive { get; private set; }

        public string Location { get; private set; }

        public string CustomerId { get; private set; }

        public string ContractId { get; private set; }        

        public virtual Company CompanyCustomer { get; private set; }

        //public virtual CompanyContract Contract { get; private set; }


        public System.DateTime StartDate { get; private set; }

        public System.DateTime EndDate { get; private set; }

        public System.DateTime? ActualEndDate { get; private set; }

        public int GuaranteePeriodInMonths { get; private set; }        

        public virtual Employee Manager { get; private set; }
    }
}