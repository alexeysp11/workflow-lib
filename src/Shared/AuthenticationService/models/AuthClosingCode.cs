namespace WokflowLib.Authentication.Models;

/// <summary>
/// Authentication closing code.
/// </summary>
public class AuthClosingCode
{
    /// <summary>
    /// ID of the authentication closing code.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// UID of the authentication closing code.
    /// </summary>
    public string Uid { get; set; }
    
    /// <summary>
    /// Name of the authentication closing code.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Description of the authentication closing code.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Type of the authentication closing code.
    /// </summary>
    public AuthClosingCodeType Type { get; set; }
}