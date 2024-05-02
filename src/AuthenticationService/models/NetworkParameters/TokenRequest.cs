namespace WokflowLib.Authentication.Models.NetworkParameters;

/// <summary>
/// The request to receive a session token for the user.
/// </summary>
public class TokenRequest
{
    /// <summary>
    /// User GUID.
    /// </summary>
    public string? UserUid { get; set; }
}
