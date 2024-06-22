using Microsoft.AspNetCore.Mvc;
using WokflowLib.Authentication.AuthBL;
using WokflowLib.Authentication.Models.NetworkParameters;
using Chat.Core.Services;

namespace AuthenticationServiceWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatAuthController : ControllerBase
{
    private readonly ILogger<ChatAuthController> _logger;

    public ChatAuthController(ILogger<ChatAuthController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "AddUser")]
    public UserCreationResult AddUser(UserCredentials request)
    {
        return new ChatAuthService().AddUser(request);
    }

    [HttpGet(Name = "VerifyUserCredentials")]
    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        return new ChatAuthService().VerifyUserCredentials(request);
    }
}
