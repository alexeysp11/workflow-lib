using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Customers;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.Responsibilities;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Employment contract.
    /// </summary>
    public class EmploymentContract
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

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
        public EmploymentContract ExpiredEmploymentContract { get; set; }

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
        public Period EstimatedPeriod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Period ActualPeriod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<EmployeeResponsibility> EmployeeResponsibilities { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<EmployerResponsibility> EmployerResponsibilities { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICollection<EmployeeBenefit> EmployeeBenifits { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Schedule Schedule { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NonCompeteClause NonCompeteClause { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmploymentContractStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<EmploymentTerminationReason> InternalTerminationReasons { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmploymentTerminationReason OfficialTerminationReason { get; set; }
    }
}