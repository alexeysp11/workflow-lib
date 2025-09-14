using VelocipedeUtils.Shared.Models.Business.Reporting;

namespace VelocipedeUtils.Reporting.ReportGenerationService;

public interface IWfReportGenerationService
{
    IWfReport GenerateReport(WfPrintDocLayout layout, WfReportData data);
}