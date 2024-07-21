using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class SettingsModel : PageModel
    {
        private readonly ILogger<SettingsModel> _logger;

        public SettingsModel(ILogger<SettingsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostSaveBtn(string company_name, string owner, 
            string country, string city)
        {
            bool isCompanyNameCorrect = (company_name != null && company_name != string.Empty);
            bool isOwnerCorrect = (owner != null && owner != string.Empty);
            bool isCountryCorrect = (country != null && country != string.Empty);
            bool isCityCorrect = (city != null && city != string.Empty);

            if (isCompanyNameCorrect && isOwnerCorrect && isCountryCorrect && 
                isCityCorrect)
            {
                Repository.Instance.SetMainCompany(company_name, owner, country, 
                    city);
                Repository.IsErrorMessageActivatedOnSettings = false;
                _logger.LogInformation($"Edited information about the company (company_name: {company_name}, owner: {owner}, country: {country}, city: {city})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnSettings = true;
                Repository.ErrorMessageOnSettings = Repository.GetErrorMessage("Save", "company name, owner, country, city");
            }
            return RedirectToPage();
        }
    }
}
