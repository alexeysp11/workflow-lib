using VelocipedeUtils.Authentication.AuthBL;
using VelocipedeUtils.Authentication.Models.ConfigParameters;
using VelocipedeUtils.Authentication.Models.NetworkParameters;

namespace Chat.Core.Services;

/// <summary>
/// Chat authentication resolver.
/// </summary>
public class ChatAuthService
{
    /// <summary>
    /// Authentication resolver from VelocipedeUtils.
    /// </summary>
    private IAuthResolver AuthResolver { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ChatAuthService()
    {
        var configHelper = new ConfigHelper();
        var settings = new AuthResolverSettings
        {
            CheckUCConfig = configHelper.GetUCConfigs(),
            AuthDBSettings = configHelper.GetAuthDBSettings(usersTableName: "chat_users")
        };
        AuthResolver = new AuthResolverDB(settings);
    }

    /// <summary>
    /// Method for adding the specified user into the database.
    /// </summary>
    public UserCreationResult AddUser(UserCredentials request)
    {
        return AuthResolver.AddUser(request);
    }

    /// <summary>
    /// Method for verifying the user credentials.
    /// </summary>
    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        return AuthResolver.VerifyUserCredentials(request);
    }
}
