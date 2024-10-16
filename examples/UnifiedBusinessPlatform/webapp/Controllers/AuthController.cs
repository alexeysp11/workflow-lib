using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.UnifiedBusinessPlatform.ViewModels;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Controllers;

public class Auth : Controller
{
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            // var User = from m in _context.SignIn select m;
            // User = User.Where(s => s.username.Contains(model.username));
            // if (User.Count() != 0)
            // {
            //     if (User.First().password == model.password)
            //     {
            //         return RedirectToAction("Success");
            //     }
            // }
        }
        return RedirectToAction("SignIn");
    }
}