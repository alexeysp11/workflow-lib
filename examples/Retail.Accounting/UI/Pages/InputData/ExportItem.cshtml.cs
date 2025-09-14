using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VelocipedeUtils.Examples.Retail.Accounting.Pages
{
    public class ExportItemModel : PageModel
    {
        private readonly ILogger<ExportItemModel> _logger;

        public ExportItemModel(ILogger<ExportItemModel> logger)
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
            bool isDocumentIdCorrect = (Repository.ExportDocId > 0);
            
            if (isProductCorrect && isQuantityCorrect && isPriceCorrect && 
                isDocumentIdCorrect)
            {
                Repository.Instance.InsertExportItem(product_title, quantity, 
                    item_price, Repository.ExportDocId);
                Repository.IsErrorMessageActivatedOnExportItem = false;
                _logger.LogInformation($"Added ExportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price}) for ExportDocId = {Repository.ExportDocId})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnExportItem = true;
                Repository.ErrorMessageOnExportItem = Repository.GetErrorMessage("Add", 
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
                Repository.Instance.UpdateExportItem(item_id, product_title, 
                    quantity, item_price);
                Repository.IsErrorMessageActivatedOnExportItem = false;
                _logger.LogInformation($"Edit ExportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price})");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnExportItem = true;
                Repository.ErrorMessageOnExportItem = Repository.GetErrorMessage("Edit", 
                    "item ID, product title, quantity or item price");
            }
            return RedirectToPage();
        }

        public IActionResult OnPostDeleteBtn(int item_id)
        {
            bool isItemIdCorrect = (item_id > 0);
            if (isItemIdCorrect)
            {
                Repository.Instance.DeleteExportItem(item_id);
                Repository.IsErrorMessageActivatedOnExportItem = false;
                _logger.LogInformation($"Deleted ExportItem with ID: {item_id}");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnExportItem = true;
                Repository.ErrorMessageOnExportItem = Repository.GetErrorMessage("Delete", "item ID");
            }
            return RedirectToPage();
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnExportItem = false;
        }
    }
}
