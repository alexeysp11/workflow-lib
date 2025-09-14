using VelocipedeUtils.Shared.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// The response to confirmation of registration using the verification code.
/// </summary>
public class VSUResponse
{
    /// <summary>
    /// Shows if the verification of the sign up was successful.
    /// </summary>
    public bool IsSuccessful { get; set; }
    
    /// <summary>
    /// Exception message.
    /// </summary>
    public string? ExceptionMessage { get; set; }
    
    /// <summary>
    /// Workflow exception.
    /// </summary>
    public WorkflowException? WorkflowException { get; set; }
}
