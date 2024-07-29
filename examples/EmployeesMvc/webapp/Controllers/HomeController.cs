using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.EmployeesMvc.Core.Models;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Examples.EmployeesMvc.Core.Repositories;
using WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;

namespace WorkflowLib.Examples.EmployeesMvc.Controllers;

public class HomeController : Controller
{
    private AppSettings _appSettings;
    private FilterOptionsSettings _filterOptionsSettings;
    private TempDataSettings _tempDataSettings;
    
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICommonDataFilter _commonFilter;

    public HomeController(
        AppSettings appSettings,
        ILogger<HomeController> logger,
        IUnitOfWork unitOfWork,
        ICommonDataFilter commonFilter)
    {
        _appSettings = appSettings;
        _filterOptionsSettings = _appSettings.StringSettings.FilterOptionsSettings;
        _tempDataSettings = _appSettings.StringSettings.TempDataSettings;

        _logger = logger;
        _unitOfWork = unitOfWork;
        _commonFilter = commonFilter;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Employees()
    {
        var employees = _unitOfWork.GetEmployees();
        return View(employees);
    }

    public IActionResult Vacations()
    {
        // Restore previously filtered elements.
        var uidObj = TempData[_tempDataSettings.VacationsUidStr];
        if (uidObj != null && !string.IsNullOrEmpty(uidObj.ToString()))
        {
            var vacationsFiltered = _unitOfWork.GetFilteredVacations(uidObj.ToString()).ToList();
            uidObj = string.Empty;
            return View(vacationsFiltered);
        }

        // Set info about filters.
        TempData[_tempDataSettings.FilterInfoVacationsStr] = _filterOptionsSettings.NoFiltersApplied;
        TempData[_tempDataSettings.EmployeeInfoVacationsStr] = _filterOptionsSettings.NoFiltersApplied;
        TempData[_tempDataSettings.FilterOptionsVacationsStr] = _filterOptionsSettings.NoFiltersApplied;

        // Get all elements.
        var vacations = _unitOfWork.GetVacations();

        return View(vacations);
    }

    public IActionResult NewVacation()
    {
        return View();
    }

    [HttpPost("[action]")]
    [Route("/Home")]
    public IActionResult FilterVacations(
        string fullName,
        string ageMin,
        string ageMax,
        string gender,
        string jobTitle,
        string department,
        string currentFullName,
        string filterOptions)
    {
        // Get filtered data.
        var vacations = _commonFilter.FilterVacations(fullName, ageMin, ageMax, gender, jobTitle, department, currentFullName, filterOptions, _unitOfWork.GetEmployees, _unitOfWork.GetVacations);

        // Insert filtered data and get UID.
        string uid = _unitOfWork.InsertFilteredVacations(vacations);

        // Store UID and  in views.
        TempData[_tempDataSettings.VacationsUidStr] = uid;

        // Store info about filtering.
        TempData[_tempDataSettings.FilterInfoVacationsStr] = _filterOptionsSettings.GetFilterOptionsString(fullName, ageMin, ageMax, gender, jobTitle, department);  
        TempData[_tempDataSettings.EmployeeInfoVacationsStr] = _filterOptionsSettings.GetFilterOptionsString(currentFullName);  
        TempData[_tempDataSettings.FilterOptionsVacationsStr] = filterOptions;

        return RedirectToAction("Vacations");
    }

    public IActionResult AddNewVaction(
        string fullName,
        System.DateTime beginDate,
        System.DateTime endDate)
    {
        if (endDate > beginDate && (endDate - beginDate).Days <= 14)
            _unitOfWork.InsertVacation(fullName ?? string.Empty, beginDate, endDate);
        return RedirectToAction("Vacations");
    }

    public IActionResult SetLanguage(string lang)
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
        return Redirect(Request.Headers["Referer"].ToString());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
