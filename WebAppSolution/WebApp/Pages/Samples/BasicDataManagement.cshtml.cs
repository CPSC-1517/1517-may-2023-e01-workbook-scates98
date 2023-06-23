using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // form control properties:
        // it is the asp-for that links the form control to the property
        // PROBLEM:
        // if a property does NOT have a [BindProperty] attribute,
        //      the value of the property is NOT updated when the form is submitted
        //      the property is considered as a read-only property (one-way binding)
        //      the property value is "out-going only" (from the server to the client)

        //[BindProperty]    // this attribute is not required 
        // However, if you wish to receive data from your client (form)
        //      into the server (PageModel) you MUST use have the
        //      [BindProperty] attribute on the property
        // The property will be  a two-way binding
        //  The property value is BOTH "out-going" and "in-coming"

        [BindProperty]
        public int Num { get; set; }

        [BindProperty]
        public string MassText { get; set; }

        [BindProperty]
        public int FavouriteCourse { get; set; } // using intege from select 

        [BindProperty]
        public string FavouriteCourseNoValueOnOption { get; set; } // using default string from select

        [BindProperty]
        public string Feedback { get; set; }    // one-way property for messages


        // This is an example of you managing the collection of errors on the form yourself
        // The List is a list of errors collected during your validation
        public List<string> ErrorList { get; set; } = new List<string>();


        public void OnGet()
        {
        }

        public void OnPostControlProcessing()
        {
            Feedback = "You pressed the button!"
                + $" Number value is: {Num}"
                + $"  Mass text is: {MassText}"
                + $"  Favourite course with value is: {FavouriteCourse}"
                + $"  Favourite course with value is: {FavouriteCourseNoValueOnOption}";
        }
    }
}
