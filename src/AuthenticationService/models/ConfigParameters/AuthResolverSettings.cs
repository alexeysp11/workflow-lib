namespace WokflowLib.Authentication.Models.ConfigParameters;

/// <summary>
/// Settings for authentication resolver.
/// </summary>
public class AuthResolverSettings
{
    /// <summary>
    /// Config properties that is used for checking if the user credentials were filled properly.
    /// </summary>
    public CheckUCConfig CheckUCConfig { get; set; }

    /// <summary>
    /// Settings for DB.
    /// </summary>
    public AuthDBSettings AuthDBSettings { get; set; }

    /// <summary>
    /// Settings for network communication.
    /// </summary>
    public NetworkSettings NetworkSettings { get; set; }
}