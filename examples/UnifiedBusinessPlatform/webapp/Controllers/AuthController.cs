using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.DbContexts;
using WorkflowLib.Examples.UnifiedBusinessPlatform.ViewModels;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Controllers;

public class AuthController : Controller
{
    private readonly EmployeesMvcDbContext _context;

    public AuthController(EmployeesMvcDbContext context)
    {
        _context = context;
    }

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.UserAccounts.FirstOrDefault(x => x.Login == model.Username && x.Password == model.Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home", null);
            }
        }
        return RedirectToAction("SignIn");
    }
}