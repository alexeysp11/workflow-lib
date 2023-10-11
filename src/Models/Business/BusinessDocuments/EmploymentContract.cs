using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Responsibilities;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// 
    /// </summary>
    public class EmploymentContract
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Contract Contract { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmploymentContractType EmploymentContractType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PayRate PayRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<EmployeeResponsibility> EmployeeResponsibilities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<EmployerResponsibility> EmployerResponsibilities { get; set; }
    }
}