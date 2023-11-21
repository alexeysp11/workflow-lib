using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Processes
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