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

[Authorize]
public class OrganizationalStructureController : Controller
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<OrganizationalStructureController> _logger;
    private readonly EmployeesMvcDbContext _context;

    public OrganizationalStructureController(
        AppSettings appSettings,
        ILogger<OrganizationalStructureController> logger,
        EmployeesMvcDbContext context)
    {
        _appSettings = appSettings;
        _logger = logger;
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult BriefDescription()
    {
        return View();
    }

    public async Task<IActionResult> Organizations()
    {
        return View(await _context.Organizations.Include(x => x.HeadItem).ToListAsync());
    }

    public async Task<IActionResult> OrganizationDetails(long id)
    {
        return View(await _context.Organizations.Include(x => x.HeadItem).FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<IActionResult> OrganizationItemDetails(long id)
    {
        return View(await _context.OrganizationItems.Include(x => x.ParentItem).FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<IActionResult> OrganizationItems(OrganizationItemType itemType)
    {
        switch (itemType)
        {
            case OrganizationItemType.Department:
                ViewData["ItemType"] = "Departments";
                break;
            case OrganizationItemType.JobPosition:
                ViewData["ItemType"] = "JobPositions";
                break;
            case OrganizationItemType.Team:
                ViewData["ItemType"] = "Teams";
                break;
        }
        return View(await _context.OrganizationItems.Where(x => x.ItemType == itemType).Include(x => x.ParentItem).ToListAsync());
    }
}
