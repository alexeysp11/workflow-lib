namespace WorkflowLib.Shared.Models.Business.Reporting
{
    public enum WfExportFormat
    {
        None = 0,
        Pdf = 1,
        Excel = 2,
        Word = 3,
        Html = 4
    }

    public enum WfReportStatus
    {
        None = 0,
        New = 1,
        Generating = 2,
        Ready = 3,
        Printed = 4,
        Failed = 5
    }

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

    public class WfPrinter : WfBusinessEntity, IWfBusinessEntity
    {
        public Location? Location { get; set; }
    }

    public class WfReportData
    {
        public Guid Id { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DataTable DataTable { get; set; }
    }

    public interface IWfReport
    {
        WfPrintDoc? PrintDoc { get; set; }

        void Generate();
        void Export(ExportFormat format);
        void Print();
    }

    public interface IWfPrintService
    {
        void PrintReport(IWfReport report);
        void ExportReport(IWfReport report, ExportFormat format);
    }

    public interface IWfReportGenerationService
    {
        IWfReport GenerateReport(WfPrintDocLayout layout, WfReportData data);
    }
}
