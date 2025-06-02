using System.Data;
using System.Text.Json;

namespace WorkflowLib.Shared.Models.Business.Reporting
{
    /// <summary>
    /// Export format.
    /// </summary>
    public enum WfExportFormat
    {
        None = 0,
        Pdf = 1,
        Excel = 2,
        Word = 3,
        Html = 4
    }

    /// <summary>
    /// Report status.
    /// </summary>
    public enum WfReportStatus
    {
        None = 0,
        New = 1,
        Generating = 2,
        Ready = 3,
        Printed = 4,
        Failed = 5
    }

    /// <summary>
    /// The main object of a printed document.
    /// </summary>
    public class WfPrintDoc : WfBusinessEntity, IWfBusinessEntity
    {
        public WfPrinter? Printer { get; set; }
        public WfPrintDocLayout? PrintDocLayout { get; set; }
        public WfExportFormat? ExportFormat { get; set; }
        public WfReportStatus? ReportStatus { get; set; }
        public string? ParametersJson { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public Dictionary<string, object>? GetParameters()
        {
            return string.IsNullOrEmpty(ParametersJson) 
                ? null 
                : JsonSerializer.Deserialize<Dictionary<string, object>>(ParametersJson);
        }

        public void SetParameters(Dictionary<string, object> parameters)
        {
            ParametersJson = JsonSerializer.Serialize(parameters);
        }
    }

    /// <summary>
    /// Report template description.
    /// </summary>
    public class WfPrintDocLayout : WfBusinessEntity, IWfBusinessEntity
    {
        public string? Layout { get; set; }
        public byte[]? TemplateContent { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? MarginTop { get; set; }
        public int? MarginRight { get; set; }
        public int? MarginLeft { get; set; }
        public int? MarginBottom { get; set; }
        public int? BorderTop { get; set; }
        public int? BorderRight { get; set; }
        public int? BorderLeft { get; set; }
        public int? BorderBottom { get; set; }
    }

    /// <summary>
    /// Printer object.
    /// </summary>
    public class WfPrinter : WfBusinessEntity, IWfBusinessEntity
    {
        public WfPrinterLocation? PrinterLocation { get; set; }
    }

    /// <summary>
    /// Location of the printer.
    /// </summary>
    public class WfPrinterLocation : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Number of the location.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Address of the location.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Determines whether the location is virtual.
        /// </summary>
        public bool IsVirtual { get; set; }
    }

    /// <summary>
    /// Container for report data.
    /// </summary>
    public class WfReportData
    {
        public Guid Guid { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DataTable DataTable { get; set; }
    }

    /// <summary>
    /// Report interface.
    /// </summary>
    public interface IWfReport
    {
        WfPrintDoc? PrintDoc { get; set; }

        void Generate();
        void Export(WfExportFormat format);
        void Print();
    }
}
