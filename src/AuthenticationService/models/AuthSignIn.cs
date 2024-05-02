namespace WokflowLib.Authentication.Models;

/// <summary>
/// Sign in to the application.
/// </summary>
public class AuthSignIn
{
    /// <summary>
    /// ID of the sign in.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// UID of the sign in.
    /// </summary>
    public string Uid { get; set; }

    /// <summary>
    /// UID of the user.
    /// </summary>
    public string UserUid { get; set; }

    /// <summary>
    /// Sign in begin timestamp.
    /// </summary>
    public System.DateTime SignInBeginDt { get; set; }

    /// <summary>
    /// Sign in end timestamp.
    /// </summary>
    public System.DateTime SignInEndDt { get; set; }

    /// <summary>
    /// Shows if the sign in attempt is "deprecated".
    /// </summary>
    public bool IsDeprecated { get; set; }

    /// <summary>
    /// Shows if the sign in attempt is "overriden".
    /// </summary>
    public bool IsOverriden { get; set; }

    /// <summary>
    /// Authentication closing code.
    /// </summary>
    public AuthClosingCode AuthClosingCode { get; set; }
}