using System.Data;

namespace WorkflowLib.Shared.Models.Business.Reporting
{
    /// <summary>
    /// Container for report data.
    /// </summary>
    public class WfReportData
    {
        public Guid Guid { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DataTable DataTable { get; set; }
    }
}