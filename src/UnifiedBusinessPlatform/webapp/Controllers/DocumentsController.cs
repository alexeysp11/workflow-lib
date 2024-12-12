using System.Diagnostics;
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

public class DocumentsController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<DocumentsController> _logger;
    private readonly EmployeesMvcDbContext _context;

    public DocumentsController(
        AppSettings appSettings,
        ILogger<DocumentsController> logger,
        EmployeesMvcDbContext context)
    {
        _appSettings = appSettings;
        _logger = logger;
        _context = context;
    }
    
    [Authorize]
    public IActionResult Internal()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult KnowledgeBase()
    {
        return View();
    }
}