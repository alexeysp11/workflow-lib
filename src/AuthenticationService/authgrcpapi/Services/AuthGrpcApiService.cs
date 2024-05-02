using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.AuthGrpcApi;
using WokflowLib.Authentication.Models.Protos;
using UserCredentialsCommon = WokflowLib.Authentication.Models.NetworkParameters.UserCredentials;
using VSURequestCommon = WokflowLib.Authentication.Models.NetworkParameters.VSURequest;
using TokenRequestCommon = WokflowLib.Authentication.Models.NetworkParameters.TokenRequest;

namespace WokflowLib.Authentication.AuthGrpcApi.Services;

/// <summary>
/// Authentication service that is implemented as a gRPC service.
/// </summary>
public class AuthGrpcApiService : WokflowLib.Authentication.Models.Protos.AuthGrpcApi.AuthGrpcApiBase
{
    private readonly ILogger<AuthGrpcApiService> _logger;
    public AuthGrpcApiService(ILogger<AuthGrpcApiService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Method to check if a user exists in the database.
    /// </summary>
    public override Task<UserExistance> CheckUserExistance(UserCredentials request, ServerCallContext context)
    {
        var response = new AuthResolver().CheckUserExistance(new UserCredentialsCommon
        {
            Login = request.Login,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        });
        return Task.FromResult(new UserExistance
        {
            LoginExists = response.LoginExists,
            EmailExists = response.EmailExists,
            PhoneNumberExists = response.PhoneNumberExists
        });
    }

    /// <summary>
    /// Method for adding a user to the database.
    /// </summary>
    public override Task<UserCreationResult> AddUser(UserCredentials request, ServerCallContext context)
    {
        var response = new AuthResolver().AddUser(new UserCredentialsCommon
        {
            Login = request.Login,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        });
        return Task.FromResult(new UserCreationResult
        {
            IsUserAdded = true,
            SignUpGuid = "",
            VerificationCode = response.VerificationCode,
            CodeSendingDt = Timestamp.FromDateTimeOffset(response.CodeSendingDt)
        });
    }

    /// <summary>
    /// Method for verifying user sign up in an application.
    /// </summary>
    public override Task<VSUResponse> VerifySignUp(VSURequest request, ServerCallContext context)
    {
        var response = new AuthResolver().VerifySignUp(new VSURequestCommon
        {
            UserGuid = request.UserGuid,
            TriesNumber = request.TriesNumber,
            IsDeprecated = request.IsDeprecated,
            IsOverriden = request.IsOverriden,
            SignUpClosingCode = request.SignUpClosingCode
        });
        return Task.FromResult(new VSUResponse
        {
            IsSuccessful = response.IsSuccessful
        });
    }

    /// <summary>
    /// Method for verifying user credentials.
    /// </summary>
    public override Task<VUCResponse> VerifyUserCredentials(UserCredentials request, ServerCallContext context)
    {
        var response = new AuthResolver().VerifyUserCredentials(new UserCredentialsCommon
        {
            Login = request.Login,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password
        });
        return Task.FromResult(new VUCResponse
        {
            IsVerified = response.IsVerified,
            UserUid = response.UserUid
        });
    }

    /// <summary>
    /// Method for obtaining a token by user GUID.
    /// </summary>
    public override Task<SessionToken> GetTokenByUserUid(TokenRequest request, ServerCallContext context)
    {
        var response = new AuthResolver().GetTokenByUserUid(new TokenRequestCommon
        {
            UserUid = request.UserUid
        });
        return Task.FromResult(new SessionToken
        {
            TokenGuid = response.TokenGuid,
            TokenBeginDt = Timestamp.FromDateTimeOffset(response.TokenBeginDt),
            TokenEndDt = Timestamp.FromDateTimeOffset(response.TokenEndDt)
        });
    }
}
