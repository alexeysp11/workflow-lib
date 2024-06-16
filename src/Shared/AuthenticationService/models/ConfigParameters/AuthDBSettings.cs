namespace WokflowLib.Authentication.Models.ConfigParameters;

/// <summary>
/// Settings for DB.
/// </summary>
public class AuthDBSettings
{
    /// <summary>
    /// Name of the DB provider.
    /// </summary>
    public string DBProvider { get; set; }
    
    /// <summary>
    /// Connection string.
    /// </summary>
    public string ConnectionString { get; set; }
    
    /// <summary>
    /// SQL statement for adding a new user.
    /// </summary>
    public string AddUserSQL { get; set; }
    
    /// <summary>
    /// SQL statement for verifying user credentials.
    /// </summary>
    public string VerifyUserCredentialsSQL { get; set; }
}