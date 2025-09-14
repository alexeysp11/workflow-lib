using VelocipedeUtils.Shared.Models.ErrorHandling;

namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// Esistance of the specified user.
/// </summary>
public class UserExistance
{
    /// <summary>
    /// Shows if the specified login exists in the database.
    /// </summary>
    public bool LoginExists { get; set; }
    
    /// <summary>
    /// Shows if the specified email exists in the database.
    /// </summary>
    public bool EmailExists { get; set; }
    
    /// <summary>
    /// Shows if the specified phone number exists in the database.
    /// </summary>
    public bool PhoneNumberExists { get; set; }
    
    /// <summary>
    /// Exception message.
    /// </summary>
    public string? ExceptionMessage { get; set; }
    
    /// <summary>
    /// Workflow exception.
    /// </summary>
    public WorkflowException? WorkflowException { get; set; }
}
