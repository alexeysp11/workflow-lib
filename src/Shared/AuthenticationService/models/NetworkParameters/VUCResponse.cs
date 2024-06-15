using WorkflowLib.Shared.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// The result of verification of user credintials.
/// </summary>
public class VUCResponse
{
    /// <summary>
    /// Shows if the user credentials are verified.
    /// </summary>
    public bool IsVerified { get; set; }
    
    /// <summary>
    /// User UID.
    /// </summary>
    public string? UserUid { get; set; }
    
    /// <summary>
    /// User creadentials.
    /// </summary>
    public UserCredentials? UserCredentials { get; set; }
    
    /// <summary>
    /// Exception message.
    /// </summary>
    public string? ExceptionMessage { get; set; }
    
    /// <summary>
    /// Workflow exception.
    /// </summary>
    public WorkflowException? WorkflowException { get; set; }
}
