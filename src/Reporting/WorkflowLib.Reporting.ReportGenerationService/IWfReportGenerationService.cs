using WorkflowLib.Shared.Models.Business.Reporting;

namespace WorkflowLib.Reporting.ReportGenerationService;

public interface IWfReportGenerationService
{
    IWfReport GenerateReport(WfPrintDocLayout layout, WfReportData data);
}