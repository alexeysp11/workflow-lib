using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ILogger<ProductsModel> _logger;

        public ProductsModel(ILogger<ProductsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
