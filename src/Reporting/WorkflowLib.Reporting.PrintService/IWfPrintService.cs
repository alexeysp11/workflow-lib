using WorkflowLib.Shared.Models.Business.Reporting;

namespace WorkflowLib.Reporting.PrintService;

public interface IWfPrintService
{
    void PrintReport(IWfReport report);
    void ExportReport(IWfReport report, WfExportFormatType format);
}