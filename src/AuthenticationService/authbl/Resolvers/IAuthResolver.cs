using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthBL;

/// <summary>
/// The interfaces that processes authentication requests.
/// </summary>
public interface IAuthResolver
{
    /// <summary>
    /// Method that checks if the specified user exists in the database.
    /// </summary>
    UserExistance CheckUserExistance(UserCredentials request);

    /// <summary>
    /// Method that creates the specified user.
    /// </summary>
    UserCreationResult AddUser(UserCredentials request);

    /// <summary>
    /// Method for verification of sign up completion.
    /// </summary>
    VSUResponse VerifySignUp(VSURequest request);

    /// <summary>
    /// Method for user verification.
    /// </summary>
    VUCResponse VerifyUserCredentials(UserCredentials request);

    /// <summary>
    /// Method for getting and/or updating the session token by user UID.
    /// </summary>
    SessionToken GetTokenByUserUid(TokenRequest request);
}