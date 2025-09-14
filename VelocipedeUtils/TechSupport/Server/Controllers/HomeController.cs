using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Index()
    {
        return "This is my default action...";
    }
    
    [HttpGet]
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}