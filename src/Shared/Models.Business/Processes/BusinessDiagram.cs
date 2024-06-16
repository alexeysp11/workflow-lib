using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Processes
{
    /// <summary>
    /// Business process diagram
    /// </summary>
    public class BusinessDiagram : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Collection of business diagram elements.
        /// </summary>
        public ICollection<BusinessDiagramElement> Elements { get; set; }
    }
}