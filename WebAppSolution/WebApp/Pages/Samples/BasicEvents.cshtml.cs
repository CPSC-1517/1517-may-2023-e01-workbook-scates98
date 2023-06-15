using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel
    {
        // PAGE PROPERTIES
        public string FeedBack { get; set; }

        /***************************************************************************
        *
        *   *** IMPORTANT ***
        *
        *   OnGet is a METHOD that is called each time this page is created
        *       The code on this page is called first when the page is retrieved
        *
        *   Remember that the internet is a state-less environment
        *   This means any web page requested exists in memory
        *       for as long as the page is excuting code.
        *       After the page is sent to the user's browser, the system
        *       wipes the page from memory and no longer knows about the page
        *       
        ***************************************************************************/

        public void OnGet()
        {
            FeedBack = "In OnGet";
        }
    }
}
