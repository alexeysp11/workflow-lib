using System.Collections.Generic;
using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Business process diagram element.
    /// </summary>
    public class BusinessDiagramElement : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<ConnectorWF> InputConnectors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ConnectorWF> OutputConnectors { get; set; }
    }
}