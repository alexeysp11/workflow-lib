using VelocipedeUtils.Shared.Models.ErrorHandling;

namespace VelocipedeUtils.Authentication.Models.NetworkParameters;

/// <summary>
/// The result of adding a user to the database.
/// </summary>
public class UserCreationResult
{
    /// <summary>
    /// Shows if the spicified user was created and added to the database.
    /// </summary>
    public bool IsUserAdded { get; set; }
    
    /// <summary>
    /// Sign up GUID.
    /// </summary>
    public string? SignUpGuid { get; set; }
    
    /// <summary>
    /// Verification code.
    /// </summary>
    public string? VerificationCode { get; set; }
    
    /// <summary>
    /// Code sending timestamp.
    /// </summary>
    public System.DateTime CodeSendingDt { get; set; }
    
    /// <summary>
    /// Shows if the specified user existed in the database before the request.
    /// </summary>
    public UserExistance? UserExistanceBefore { get; set; }
    
    /// <summary>
    /// Shows if the specified user exists in the database after the request.
    /// </summary>
    public UserExistance? UserExistanceAfter { get; set; }

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
