using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.EmployeesMvc.Core.Domain.Filtering;
using WorkflowLib.Examples.EmployeesMvc.Core.Dto;
using WorkflowLib.Examples.EmployeesMvc.Core.Enums;
using WorkflowLib.Examples.EmployeesMvc.Core.Models;
using WorkflowLib.Examples.EmployeesMvc.Core.Models.Configurations;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Examples.EmployeesMvc.Core.Repositories;

namespace WorkflowLib.Examples.EmployeesMvc.Controllers;

public class HomeController : Controller
{
    private readonly AppSettings _appSettings;
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
        _logger = logger;
        _unitOfWork = unitOfWork;
        _commonFilter = commonFilter;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Organizations()
    {
        return View();
    }

    public IActionResult Employees()
    {
        IEnumerable<Employee> employees = null;
        try
        {
            employees = _unitOfWork.GetEmployees();
        }
        catch (System.Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
        return View(employees);
    }

    public IActionResult Vacations()
    {
        IEnumerable<Absense> vacations = null;
        try
        {
            // Restore previously filtered elements.
            var uidObj = TempData[CacheUidType.VacationsUid.ToString()];
            if (uidObj != null && !string.IsNullOrEmpty(uidObj.ToString()))
            {
                var vacationsFiltered = _unitOfWork.GetFilteredVacations(uidObj.ToString()).ToList();
                uidObj = string.Empty;
                return View(vacationsFiltered);
            }

            // Set info about filters.
            TempData[CacheUidType.FilterInfoVacations.ToString()] = FilterOptionType.NoFiltersApplied;
            TempData[CacheUidType.EmployeeInfoVacations.ToString()] = FilterOptionType.NoFiltersApplied;
            TempData[CacheUidType.FilterOptionsVacations.ToString()] = FilterOptionType.NoFiltersApplied;

            // Get all elements.
            vacations = _unitOfWork.GetVacations();
        }
        catch (System.Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
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
        int? ageMin,
        int? ageMax,
        string gender,
        string jobTitle,
        string department,
        string currentFullName,
        FilterOptionType filterOptions)
    {
        try
        {
            // Get filtered data.
            var employeeDto = new EmployeeDto
            {
                FullName = fullName,
                AgeMin = ageMin == null ? _appSettings.EmployeeMinAge : (int)ageMin,
                AgeMax = ageMax == null ? _appSettings.EmployeeMaxAge : (int)ageMax,
                Gender = gender,
                JobTitle = jobTitle,
                Department = department
            };
            var vacations = _commonFilter.FilterVacations(employeeDto, currentFullName, filterOptions, _unitOfWork.GetEmployees, _unitOfWork.GetVacations);

            // Insert filtered data and get UID.
            string uid = _unitOfWork.InsertFilteredVacations(vacations);

            // Store UID and  in views.
            TempData[CacheUidType.VacationsUid.ToString()] = uid;

            // Store info about filtering.
            TempData[CacheUidType.EmployeeFullname.ToString()] = fullName;
            TempData[CacheUidType.EmployeeMinAge.ToString()] = ageMin;
            TempData[CacheUidType.EmployeeMaxAge.ToString()] = ageMax;
            TempData[CacheUidType.EmployeeGender.ToString()] = gender;
            TempData[CacheUidType.EmployeeJobTitle.ToString()] = jobTitle;
            TempData[CacheUidType.EmployeeDepartment.ToString()] = department;
            TempData[CacheUidType.CurrentEmployeeFullname.ToString()] = currentFullName;
            TempData[CacheUidType.FilterOptionsVacations.ToString()] = filterOptions;
        }
        catch (System.Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
        return RedirectToAction("Vacations");
    }

    public IActionResult AddNewVaction(
        string fullName,
        System.DateTime beginDate,
        System.DateTime endDate)
    {
        try
        {
            if (endDate > beginDate && (endDate - beginDate).Days <= 14)
                _unitOfWork.InsertVacation(fullName ?? string.Empty, beginDate, endDate);
        }
        catch (System.Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
        return RedirectToAction("Vacations");
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
