﻿using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Domain.Filtering;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Dto;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Enums;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Models;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.DbContexts;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Repositories;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Controllers;

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

    [Authorize]
    public IActionResult Notifications()
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
