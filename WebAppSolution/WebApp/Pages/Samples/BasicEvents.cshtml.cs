using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel
    {
        // PAGE PROPERTIES
        public string FeedBack { get; set; }
            // public property within the class that can be used in the CSHTML page
        private Random random = new Random();
            // private field within the class

        /*******************************************************************************
        *
        *   *** IMPORTANT ***
        *
        *   OnGet is a METHOD that is called & executed each time this page is created
        *       The code on this page is called first when the page is retrieved
        *
        *   Remember that the internet is a state-less environment
        *   This means any web page requested exists in memory
        *       for as long as the page is excuting code.
        *       After the page is sent to the user's browser, the system
        *       wipes the page from memory and no longer knows about the page
        *       
        *******************************************************************************/

        public void OnGet()
        {
            FeedBack = "OnGet was executed";
        }


        /*******************************************************************************
        * 
        * OnPost is a method that is called by default if the submit button is clicked
        *  AND thre is no code for the spefific event handler for the button
        * 
        *******************************************************************************/
        //public void OnPost()
        public void OnPostFirstButton()
        {
            int oddeven = random.Next(1, 101);
            if (oddeven % 2 == 0)
            {
                FeedBack = $"Your value {oddeven} is even";
            }
            else 
            {
                FeedBack = $"Your value {oddeven} is odd";
            }
        }
        public void OnPostSecondButton()
        {
            FeedBack = "You clicked the second button and there is a coded event for the button page handler name!";
        }
    }
}
