using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VelocipedeUtils.Examples.Retail.Accounting.Pages
{
    public class ManagementModel : PageModel
    {
        private readonly ILogger<ManagementModel> _logger;

        public ManagementModel(ILogger<ManagementModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
