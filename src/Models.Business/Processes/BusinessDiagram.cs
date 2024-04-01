using System.Collections.Generic;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Business process diagram
    /// </summary>
    public class BusinessDiagram : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<BusinessDiagramElement> Elements { get; set; }
    }
}