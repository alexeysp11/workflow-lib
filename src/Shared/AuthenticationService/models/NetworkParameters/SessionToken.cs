using WorkflowLib.Shared.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// Session token.
/// </summary>
public class SessionToken
{
    /// <summary>
    /// Token GUID.
    /// </summary>
    public string? TokenGuid { get; set; }

    /// <summary>
    /// Token begin timestamp.
    /// </summary>
    public System.DateTime TokenBeginDt { get; set; }

    /// <summary>
    /// Token end timestamp.
    /// </summary>
    public System.DateTime TokenEndDt { get; set; }

    /// <summary>
    /// User type.
    /// </summary>
    public string? UserType { get; set; }

    /// <summary>
    /// Exception message.
    /// </summary>
    public string? ExceptionMessage { get; set; }

    /// <summary>
    /// Workflow exception.
    /// </summary>
    public WorkflowException? WorkflowException { get; set; }
}
