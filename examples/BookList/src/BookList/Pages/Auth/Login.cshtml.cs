using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WorkflowLib.Examples.BookList;
using WorkflowLib.Examples.BookList.Models;
using WorkflowLib.Examples.BookList.Services; 

namespace WorkflowLib.Examples.BookList.Pages
{
    public class LoginModel : PageModel 
    {
        private readonly ILogger _logger; 

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger; 
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync(string fullname, string password)
        {
            // Get if input values are correct. 
            bool isFullnameCorrect = (fullname != null && fullname != string.Empty);
            bool isPasswordCorrect = (password != null && password != string.Empty);
            
            // Process fields. 
            if (isFullnameCorrect && isPasswordCorrect)
            {
                _logger.LogInformation($"{fullname} tries to log in."); 
                
                try
                {
                    // Verify the credentials.  
                    bool exists = Repository.UserRepositoryInstance.DoesExist(fullname, password); 
                    if (!exists)
                    {
                        throw new System.Exception($"User {fullname} does not exist in the DB."); 
                    }

                    // Creating the security context. 
                    var claims = new List<Claim> 
                    {
                        new Claim(ClaimTypes.Name, fullname), 
                        new Claim(ClaimTypes.Role, "User")
                    };
                    var identity = new ClaimsIdentity(claims, 
                        CookieAuthenticationDefaults.AuthenticationScheme); 
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = System.DateTimeOffset.UtcNow.AddMinutes(5),
                        IsPersistent = true
                    };
                    
                    // Sign in. 
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(identity), 
                        authProperties);
                    
                    string path = "../Books"; 
                    
                    // Create new instance of the user in the repository. 
                    Repository.UserRepositoryInstance.AuthenticateUser(fullname, password); 
                    User user = Repository.UserRepositoryInstance.GetUser(); 
                    if (user == null || user.Fullname != fullname)
                    {
                        throw new System.Exception($"User {fullname} cannot be assigned in the UserRepository (instance is either null or empty)."); 
                    }

                    Repository.IsAuthenticated = true; 

                    _logger.LogInformation($"User {fullname} successfully logged in (redicted to Books)"); 

                    return RedirectToPage(path); 
                }
                catch (System.Exception e)
                {
                    _logger.LogWarning($"Exception: {e}"); 
                }
            }
            return Page(); 
        }
    }
}