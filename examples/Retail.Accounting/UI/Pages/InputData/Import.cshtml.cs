using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WorkflowLib.Examples.Retail.Accounting; 
using WorkflowLib.Examples.Retail.Accounting.Models; 

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class ImportModel : PageModel
    {
        private readonly ILogger<ImportModel> _logger;

        public ImportModel(ILogger<ImportModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAddBtn(string document_number, string employee, 
            string supplier, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);
            bool isSupplierCorrect = (supplier != null && supplier != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect && isSupplierCorrect)
            {
                Repository.Instance.InsertImportDoc(document_number, employee, 
                    supplier, date_time); 
                Repository.IsErrorMessageActivatedOnImport = false; 
                _logger.LogInformation($"Added Import (document_number: {document_number}, employee: {employee}, supplier: {supplier}, date_time: {date_time})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImport = true; 
                Repository.ErrorMessageOnImport = Repository.GetErrorMessage("Add", 
                    "document number, employee name or supplier name"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int document_id, string document_number, string employee, 
            string supplier, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);
            bool isSupplierCorrect = (supplier != null && supplier != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect && isSupplierCorrect)
            {
                Repository.Instance.UpdateImportDoc(document_id, document_number, 
                    employee, supplier, date_time);
                Repository.IsErrorMessageActivatedOnImport = false; 
                _logger.LogInformation($"Edited Import (document_number: {document_number}, employee: {employee}, supplier: {supplier}, date_time: {date_time})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImport = true; 
                Repository.ErrorMessageOnImport = Repository.GetErrorMessage("Edit", 
                    "document ID, document number, employee name or supplier name"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int document_id)
        {
            bool isDocIdCorrect = (document_id > 0); 
            if (isDocIdCorrect)
            {
                Repository.Instance.DeleteImportDoc(document_id); 
                Repository.IsErrorMessageActivatedOnImport = false; 
                _logger.LogInformation($"Deleted ImportDoc with ID: {document_id}"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImport = true; 
                Repository.ErrorMessageOnImport = Repository.GetErrorMessage("Delete", "document ID"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostWatchBtn(int document_id)
        {
            bool isDocIdCorrect = (document_id > 0); 
            if (isDocIdCorrect)
            {
                Repository.ImportDocId = document_id; 
                Repository.IsErrorMessageActivatedOnImport = false; 
                return RedirectToPage("ImportItem");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImport = true; 
                Repository.ErrorMessageOnImport = Repository.GetErrorMessage("Watch", "document ID"); 
            }
            return RedirectToPage(); 
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnImport = false; 
        }
    }
}
