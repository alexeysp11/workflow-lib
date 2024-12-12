namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
