using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WorkflowLib.Examples.BookList;
using WorkflowLib.Examples.BookList.Models;
using WorkflowLib.Examples.BookList.Services; 

namespace WorkflowLib.Examples.BookList.Pages
{
    public class RegisterModel : PageModel 
    {
        private readonly ILogger _logger; 

        public RegisterModel(ILogger<RegisterModel> logger)
        {
            _logger = logger; 
        }

        public void OnGet()
        {

        }
        
        public IActionResult OnPost(string fullname, string country, string city, 
            string password)
        {
            // Get if input values are correct. 
            bool isFullnameCorrect = (fullname != null && fullname != string.Empty);
            bool isCountryCorrect = (country != null && country != string.Empty);
            bool isCityCorrect = (city != null && city != string.Empty);
            bool isPasswordCorrect = (password != null && password != string.Empty);

            // Process fields. 
            if (isFullnameCorrect && isCountryCorrect && isCityCorrect && 
                isPasswordCorrect)
            {
                // Log information that user tries to create an account. 
                _logger.LogInformation($"User {fullname} ({city}, {country}) tries to create an account.");

                // Insert user into DB and get if it is inserted successfully. 
                try
                {
                    Repository.UserRepositoryInstance.CreateUser(fullname, country, city, password); 
                    bool exists = Repository.UserRepositoryInstance.DoesExist(fullname, password); 
                    if (!exists)
                    {
                        throw new System.Exception($"User {fullname} does not exist after inserting into the DB."); 
                    }
                    _logger.LogInformation($"User {fullname} ({city}, {country}) successfully created an account."); 
                }
                catch (System.Exception e)
                {
                    _logger.LogWarning($"Exception: {e}"); 
                    return RedirectToPage(); 
                }
                return RedirectToPage("Login"); 
            }
            return RedirectToPage(); 
        }
    }
}