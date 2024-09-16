using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;
using WorkflowLib.Examples.EmployeesMvc.Core.Dto;
using WorkflowLib.Examples.EmployeesMvc.Core.Enums;
using WorkflowLib.Examples.EmployeesMvc.Core.Models;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Examples.EmployeesMvc.Core.DbContexts;
using WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

namespace WorkflowLib.Examples.EmployeesMvc.Controllers;

public class HomeController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        AppSettings appSettings,
        ILogger<HomeController> logger)
    {
        _appSettings = appSettings;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SetLanguage(string lang)
    {
        try
        {
            Response.Cookies.Append(
                "employeesmvc-lang", 
                lang, 
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1),
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
        }
        catch (System.Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
        return Redirect(Request.Headers["Referer"].ToString());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
