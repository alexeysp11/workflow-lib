using System.ComponentModel.DataAnnotations;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.ViewModels;

public class LoginViewModel
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Username is requried!")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is requried!")]
    public string Password { get; set; }
}