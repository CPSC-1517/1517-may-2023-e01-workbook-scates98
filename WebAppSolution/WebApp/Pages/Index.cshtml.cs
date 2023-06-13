using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
        // : PageModel is the INHERITANCE!
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
            // a constructor can bring in a variable (logger)
            // the parameter has a data type
        {
            _logger = logger;
            // can assign the value of the paramter to the data type
        }

        // METHOD 
        public void OnGet()
        {

        }
    }
}