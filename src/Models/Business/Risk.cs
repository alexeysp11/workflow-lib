using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business
{
    public class Risk : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public RiskSeverity Severity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee CreationAuthor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime ChangeDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee ChangeAuthor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime ResolvingDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee ResolvingAuthor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ResolvingComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RiskStatus Status { get; set; }
    }
}