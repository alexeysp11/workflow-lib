using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class ImportItemModel : PageModel
    {
        private readonly ILogger<ImportItemModel> _logger;

        public ImportItemModel(ILogger<ImportItemModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAddBtn(string product_title, float quantity, 
            float item_price)
        {
            bool isProductCorrect = (product_title != null && product_title != string.Empty);
            bool isQuantityCorrect = (quantity >= 0);
            bool isPriceCorrect = (item_price >= 0);
            bool isDocumentIdCorrect = (Repository.ImportDocId > 0);

            if (isProductCorrect && isQuantityCorrect && isPriceCorrect && 
                isDocumentIdCorrect)
            {
                Repository.Instance.InsertImportItem(product_title, quantity, 
                    item_price, Repository.ImportDocId);
                Repository.IsErrorMessageActivatedOnImportItem = false;
                _logger.LogInformation($"Added ImportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price}) for ImportDocId = {Repository.ImportDocId})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImportItem = true;
                Repository.ErrorMessageOnImportItem = Repository.GetErrorMessage("Add", 
                    "product title, quantity or item price");
            }
            return RedirectToPage();
        }

        public IActionResult OnPostEditBtn(int item_id, string product_title, 
            float quantity, float item_price)
        {
            bool isItemIdCorrect = (item_id > 0);
            bool isProductCorrect = (product_title != null && product_title != string.Empty);
            bool isQuantityCorrect = (quantity >= 0);
            bool isPriceCorrect = (item_price >= 0);

            if (isItemIdCorrect && isProductCorrect && isQuantityCorrect && 
                isPriceCorrect)
            {
                Repository.Instance.UpdateImportItem(item_id, product_title, 
                    quantity, item_price);
                Repository.IsErrorMessageActivatedOnImportItem = false;
                _logger.LogInformation($"Edit ImportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImportItem = true;
                Repository.ErrorMessageOnImportItem = Repository.GetErrorMessage("Edit", 
                    "item ID, product title, quantity or item price");
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteBtn(int item_id)
        {
            bool isItemIdCorrect = (item_id > 0);
            if (isItemIdCorrect)
            {
                Repository.Instance.DeleteImportItem(item_id);
                Repository.IsErrorMessageActivatedOnImportItem = false;
                _logger.LogInformation($"Deleted ImportItem with ID: {item_id}");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnImportItem = true;
                Repository.ErrorMessageOnImportItem = Repository.GetErrorMessage("Delete", "item ID");
            }
            return RedirectToPage();
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnImportItem = false;
        }
    }
}
