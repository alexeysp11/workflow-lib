using VelocipedeUtils.Shared.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// Deactivation code.
/// </summary>
public class DeactivationCode
{
    /// <summary>
    /// 
    /// </summary>
    public string? DeactivationGuid { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public System.DateTime CodeSendingDt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ExceptionMessage { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public WorkflowException? WorkflowException { get; set; }
}