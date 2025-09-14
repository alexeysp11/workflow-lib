using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VelocipedeUtils.Examples.BookList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLogOutAsync()
        {
            if (Repository.IsAuthenticated)
            {
                try
                {
                    string fullname = Repository.UserRepositoryInstance.GetUser().Fullname;
                    Repository.UserRepositoryInstance.LogOutUser();
                    if (Repository.UserRepositoryInstance.GetUser() != null)
                    {
                        throw new System.Exception($"User {fullname} was not deleted from UserRepository.");
                    }

                    await HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    Repository.IsAuthenticated = false;
                    
                    _logger.LogInformation($"User {fullname} succefully logged out.");
                }
                catch (System.Exception e)
                {
                    _logger.LogWarning($"Exception: {e}");
                }
            }
            return RedirectToPage();
        }

        public IActionResult OnPostBooks()
        {
            return RedirectToPage("/Books");
        }
    }
}
