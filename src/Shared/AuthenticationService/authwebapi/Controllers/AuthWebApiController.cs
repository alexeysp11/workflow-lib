using Microsoft.AspNetCore.Mvc;
using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.Models.NetworkParameters;

namespace WokflowLib.Authentication.AuthWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthWebApiController : ControllerBase
{
    private readonly ILogger<AuthWebApiController> _logger;

    public AuthWebApiController(ILogger<AuthWebApiController> logger)
    {
        _logger = logger;
    }

    [HttpPost("CheckUserExistance")]
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        return new AuthResolver().CheckUserExistance(request);
    }

    [HttpPost("AddUser")]
    public UserCreationResult AddUser(UserCredentials request)
    {
        return new AuthResolver().AddUser(request);
    }

    [HttpPost("VerifySignUp")]
    public VSUResponse VerifySignUp(VSURequest request)
    {
        return new AuthResolver().VerifySignUp(request);
    }

    [HttpPost("VerifyUserCredentials")]
    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        return new AuthResolver().VerifyUserCredentials(request);
    }

    [HttpPost("GetTokenByUserUid")]
    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        return new AuthResolver().GetTokenByUserUid(request);
    }
}
