using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.EmployeesMvc.Helpers; 
using WorkflowLib.Examples.EmployeesMvc.Models;

namespace WorkflowLib.Examples.EmployeesMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork; 
    private readonly ICommonDataFilter _tekoFilter; 

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ICommonDataFilter tekoFilter)
    {
        _logger = logger;
        _unitOfWork = unitOfWork; 
        _tekoFilter = tekoFilter; 
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Employees()
    {
        var uidObj = TempData[StringHelper.EmployeesUidStr];
        if (uidObj != null && !string.IsNullOrEmpty(uidObj.ToString()))
        {
            var employeesFiltered = _unitOfWork.GetFilteredEmployees(uidObj.ToString()).ToList(); 
            uidObj = string.Empty;
            return View(employeesFiltered);
        }
        TempData[StringHelper.FilterInfoEmployeesStr] = StringHelper.NoFiltersApplied; 
        TempData[StringHelper.FilterOptionsEmployeesStr] = StringHelper.NoFiltersApplied; 
        var employees = _unitOfWork.GetEmployees(); 
        return View(employees);
    }

    public IActionResult Vacations()
    {
        // Restore previously filtered elements 
        var uidObj = TempData[StringHelper.VacationsUidStr];
        if (uidObj != null && !string.IsNullOrEmpty(uidObj.ToString()))
        {
            var vacationsFiltered = _unitOfWork.GetFilteredVacations(uidObj.ToString()).ToList(); 
            uidObj = string.Empty;
            return View(vacationsFiltered);
        }

        // Set info about filters 
        TempData[StringHelper.FilterInfoVacationsStr] = StringHelper.NoFiltersApplied; 
        TempData[StringHelper.EmployeeInfoVacationsStr] = StringHelper.NoFiltersApplied; 
        TempData[StringHelper.FilterOptionsVacationsStr] = StringHelper.NoFiltersApplied; 

        // Get all elements 
        var vacations = _unitOfWork.GetVacations(); 

        return View(vacations);
    }

    public IActionResult Managing()
    {
        return View(); 
    }

    public IActionResult NewVacation()
    {
        return View(); 
    }

    [HttpPost("[action]")]
    [Route("/Home")]
    public IActionResult FilterEmployees(string fio, string ageMin, string ageMax, string gender, string jobTitle, string department, 
        string filterOptions)
    {
        // Apply filters 
        var employees = _tekoFilter.FilterEmployees(fio, ageMin, ageMax, gender, jobTitle, department, filterOptions, _unitOfWork.GetEmployees); 
        
        // Save filtered employees 
        string uid = _unitOfWork.InsertFilteredEmployees(employees); 

        // Save info about applied filters 
        TempData[StringHelper.EmployeesUidStr] = uid; 
        TempData[StringHelper.FilterInfoEmployeesStr] = StringHelper.GetFilterOptionsString(fio, ageMin, ageMax, gender, jobTitle, department); 
        TempData[StringHelper.FilterOptionsEmployeesStr] = filterOptions; 
        
        return RedirectToAction("Employees");
    }

    [HttpPost("[action]")]
    [Route("/Home")]
    public IActionResult FilterVacations(string fio, string ageMin, string ageMax, string gender, string jobTitle, string department, 
        string currentFio, string filterOptions)
    {
        // Get filtered data 
        var vacations = _tekoFilter.FilterVacations(fio, ageMin, ageMax, gender, jobTitle, department, currentFio, filterOptions, _unitOfWork.GetEmployees, _unitOfWork.GetVacations); 

        // Insert filtered data and get UID 
        string uid = _unitOfWork.InsertFilteredVacations(vacations); 

        // Store UID and  in views 
        TempData[StringHelper.VacationsUidStr] = uid; 

        // Store info about filtering 
        TempData[StringHelper.FilterInfoVacationsStr] = StringHelper.GetFilterOptionsString(fio, ageMin, ageMax, gender, jobTitle, department);  
        TempData[StringHelper.EmployeeInfoVacationsStr] = StringHelper.GetFilterOptionsString(currentFio);  
        TempData[StringHelper.FilterOptionsVacationsStr] = filterOptions; 

        return RedirectToAction("Vacations");
    }

    public IActionResult AddNewVaction(string fio, System.DateTime beginDate, System.DateTime endDate)
    {
        if (endDate > beginDate && (endDate - beginDate).Days <= 14)
            _unitOfWork.InsertVacation(fio ?? string.Empty, beginDate, endDate); 
        return RedirectToAction("Vacations"); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
