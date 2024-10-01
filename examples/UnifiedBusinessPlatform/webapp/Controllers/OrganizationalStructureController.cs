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
