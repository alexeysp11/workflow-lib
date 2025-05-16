using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.UnifiedBusinessPlatform.Core.Domain.Filtering;
using WorkflowLib.UnifiedBusinessPlatform.Core.Dto;
using WorkflowLib.UnifiedBusinessPlatform.Core.Enums;
using WorkflowLib.UnifiedBusinessPlatform.Core.Models;
using WorkflowLib.UnifiedBusinessPlatform.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.UnifiedBusinessPlatform.Core.DbContexts;
using WorkflowLib.UnifiedBusinessPlatform.Core.Repositories;

namespace WorkflowLib.UnifiedBusinessPlatform.Controllers;

public class FinanceController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<FinanceController> _logger;
    private readonly EmployeesMvcDbContext _context;

    public FinanceController(
        AppSettings appSettings,
        ILogger<FinanceController> logger,
        EmployeesMvcDbContext context)
    {
        _appSettings = appSettings;
        _logger = logger;
        _context = context;
    }
    
    [Authorize]
    public IActionResult Investments()
    {
        return View();
    }
}