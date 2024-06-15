namespace WokflowLib.Authentication.Models;

/// <summary>
/// Sign up to the application.
/// </summary>
public class AuthSignUp
{
    /// <summary>
    /// ID of the sign up.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// UID of the sign up.
    /// </summary>
    public string Uid { get; set; }

    /// <summary>
    /// UID of the user.
    /// </summary>
    public string UserUid { get; set; }

    /// <summary>
    /// Verification code for the sign up.
    /// </summary>
    public string VerificationCode { get; set; }

    /// <summary>
    /// Verification code sending timestamp.
    /// </summary>
    public System.DateTime VCSendingDt { get; set; }

    /// <summary>
    /// Number of attempts to enter the sign up code.
    /// </summary>
    public string TriesNumber { get; set; }

    /// <summary>
    /// Sign up begin timestamp.
    /// </summary>
    public System.DateTime SignUpBeginDt { get; set; }

    /// <summary>
    /// Sign up end timestamp.
    /// </summary>
    public System.DateTime SignUpEndDt { get; set; }

    /// <summary>
    /// Shows if the sign up attempt is "deprecated".
    /// </summary>
    public bool IsDeprecated { get; set; }

    /// <summary>
    /// Shows if the sign up attempt is "overriden".
    /// </summary>
    public bool IsOverriden { get; set; }

    /// <summary>
    /// Authentication closing code.
    /// </summary>
    public AuthClosingCode AuthClosingCode { get; set; }
}