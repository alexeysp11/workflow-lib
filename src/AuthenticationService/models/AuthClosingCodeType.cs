using System.ComponentModel.DataAnnotations;

namespace WokflowLib.Authentication.Models;

/// <summary>
/// Type of authentication closing code.
/// </summary>
public enum AuthClosingCodeType
{
    [Display(Name = "Success")]
    Success,
    
    [Display(Name = "Rejected to provide verification code")]
    RejectedToProvideVC,
    
    [Display(Name = "Too nany tries", Description = "The number of attempts to confirm the code has been exhausted")]
    TooManyTries,
    
    [Display(Name = "Timeout", Description = "Connection fell off due to timeout")]
    Timeout,
    
    [Display(Name = "Overriden")]
    Overriden,
    
    [Display(Name = "Cancelled")]
    Cancelled
}