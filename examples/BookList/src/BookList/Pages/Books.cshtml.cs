using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.BookList.Pages
{
    public class BooksModel : PageModel 
    {
        private readonly ILogger _logger; 

        public BooksModel(ILogger<BooksModel> logger)
        {
            _logger = logger; 
        }

        public void OnGet()
        {
            try
            {
                Repository.UserRepositoryInstance.GetBooksFromDb(); 
                var books = Repository.UserRepositoryInstance.GetBookList(); 
                if (books == null)
                {
                    throw new System.Exception("List of books cannot be null"); 
                }
            }
            catch (System.Exception e)
            {
                _logger.LogWarning($"Exception in OnGet method: {e}"); 
            }
        }

        public IActionResult OnPostAddBtn(string name, string author, int year, 
            string description)
        {
            bool isNameCorrect = (name != null && name != string.Empty);
            bool isAuthorCorrect = (author != null && author != string.Empty);
            bool isYearCorrect = (year < 2021);
            bool isDescriptionCorrect = (description != null && description != string.Empty);

            if (isNameCorrect && isAuthorCorrect && isYearCorrect && 
                isDescriptionCorrect)
            {
                Repository.UserRepositoryInstance.AddNewBook(name, author, description); 
                
                _logger.LogInformation($"Book is added by {Repository.UserRepositoryInstance.GetUser().Fullname}."); 
                return RedirectToPage("Books");
            }
            return RedirectToPage(); 
        }
    }
}