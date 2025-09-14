namespace VelocipedeUtils.Examples.TechSupport.Common.Models.AppContexts;

/// <summary>
/// Предоставляет информацию об аутентификации пользователя, такую как имя пользователя, роль и токен доступа.
/// </summary>
public class AuthenticationContext
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string AccessToken { get; set; }
}