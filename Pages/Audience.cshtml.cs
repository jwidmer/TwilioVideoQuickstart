using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TwilioVideoQuickstart2.Pages
{
    public class AudienceModel : PageModel
    {
        private readonly ILogger<AudienceModel> _logger;

        public AudienceModel(ILogger<AudienceModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
