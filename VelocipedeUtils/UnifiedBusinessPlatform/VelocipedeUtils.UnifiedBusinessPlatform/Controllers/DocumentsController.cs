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

public class DocumentsController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<DocumentsController> _logger;
    private readonly UbpDbContext _context;

    public DocumentsController(
        AppSettings appSettings,
        ILogger<DocumentsController> logger,
        UbpDbContext context)
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