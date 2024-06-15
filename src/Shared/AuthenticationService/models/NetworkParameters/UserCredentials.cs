namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// User credentials.
/// </summary>
public class UserCredentials
{
    /// <summary>
    /// Login of the user.
    /// </summary>
    public string? Login { get; set; }
    
    /// <summary>
    /// Email of the user.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Phone number of the user.
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Password of the user.
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Type of the user.
    /// </summary>
    public string? UserType { get; set; }
}
