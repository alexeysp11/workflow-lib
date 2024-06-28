using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WorkflowLib.Examples.Retail.Accounting.Pages
{
    public class InputDataModel : PageModel
    {
        private readonly ILogger<InputDataModel> _logger;

        public InputDataModel(ILogger<InputDataModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
