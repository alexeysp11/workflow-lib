using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class PartnersModel : PageModel
    {
        private readonly ILogger<PartnersModel> _logger;

        public PartnersModel(ILogger<PartnersModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string partner_name, string email, 
            string phone)
        {
            bool isPartnerCorrect = (partner_name != null && partner_name != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isPartnerCorrect && isEmailCorrect && isPhoneCorrect)
            {
                Repository.Instance.InsertPartner(partner_name, email, phone);
                Repository.IsErrorMessageActivatedOnPartners = false;
                _logger.LogInformation($"Added new Partner (partner_name: {partner_name})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnPartners = true;
                Repository.ErrorMessageOnPartners = Repository.GetErrorMessage("Add", 
                    "partner name, email or phone");
            }
            return RedirectToPage();
        }

        public IActionResult OnPostEditBtn(int partner_id, string partner_name, 
            string email, string phone)
        {
            bool isPartnerIdCorrect = (partner_id > 0);
            bool isPartnerNameCorrect = (partner_name != null && partner_name != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isPartnerIdCorrect && isPartnerNameCorrect && isEmailCorrect && 
                isPhoneCorrect)
            {
                Repository.Instance.UpdatePartner(partner_id, partner_name, email, 
                    phone);
                Repository.IsErrorMessageActivatedOnPartners = false;
                _logger.LogInformation($"Edited a Partner (partner_name: {partner_name})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnPartners = true;
                Repository.ErrorMessageOnPartners = Repository.GetErrorMessage("Edit", 
                    "partner ID, partner name, email or phone");
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteBtn(int partner_id)
        {
            bool isPartnerIdCorrect = (partner_id > 0);
            if (isPartnerIdCorrect)
            {
                Repository.Instance.DeletePartner(partner_id);
                Repository.IsErrorMessageActivatedOnPartners = false;
                _logger.LogInformation($"Deleted Partner with ID: {partner_id}");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnPartners = true;
                Repository.ErrorMessageOnPartners = Repository.GetErrorMessage("Delete", "partner ID");
            }
            return RedirectToPage();
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnPartners = false;
        }
    }
}
