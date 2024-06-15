namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// The request to confirm sign up using a verification code.
/// </summary>
public class VSURequest
{
    /// <summary>
    /// Requested sign up UID.
    /// </summary>
    public string? SignUpGuid { get; set; }
    
    /// <summary>
    /// Number of tries that a user made to enter verification code during the sign up process.
    /// </summary>
    public int TriesNumber { get; set; }
    
    /// <summary>
    /// Shows if the specified sign up UID is deprecated.
    /// </summary>
    public bool IsDeprecated { get; set; }
    
    /// <summary>
    /// Shows if the specified sign up UID is overriden.
    /// </summary>
    public bool IsOverriden { get; set; }
    
    /// <summary>
    /// Sign up closing code.
    /// </summary>
    public string? SignUpClosingCode { get; set; }
}
