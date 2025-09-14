using VelocipedeUtils.Shared.Models.Business.Reporting;

namespace VelocipedeUtils.Reporting.PrintService;

public interface IWfPrintService
{
    void PrintReport(IWfReport report);
    void ExportReport(IWfReport report, WfExportFormatType format);
}