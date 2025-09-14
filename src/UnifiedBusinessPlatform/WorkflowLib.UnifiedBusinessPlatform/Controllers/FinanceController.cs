using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Domain.Filtering;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Dto;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Enums;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Models;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Models.Configurations;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.DbContexts;
using VelocipedeUtils.UnifiedBusinessPlatform.Core.Repositories;

namespace VelocipedeUtils.UnifiedBusinessPlatform.Controllers;

public class FinanceController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<FinanceController> _logger;
    private readonly UbpDbContext _context;

    public FinanceController(
        AppSettings appSettings,
        ILogger<FinanceController> logger,
        UbpDbContext context)
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