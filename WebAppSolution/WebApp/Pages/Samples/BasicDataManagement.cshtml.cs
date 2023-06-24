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
        public string? MassText { get; set; }
        // IMPORTANT - QUESTION MARK ? indicates that this property is nullable (not required/optional)

        [BindProperty]
        public int FavouriteCourse { get; set; } // using intege from select 

        [BindProperty]
        public string FavouriteCourseNoValueOnOption { get; set; } // using default string from select

        [BindProperty]
        public string? Feedback { get; set; }    // one-way property for messages


        // This is an example of you managing the collection of errors on the form yourself
        // The List is a list of errors collected during your validation
        public List<string> ErrorList { get; set; } = new List<string>();


        public void OnGet()
        {
        }

        // NOTE: The return datatype of 'void' stays on the same page
        //          Whereas IActionResult returns      
        //public void OnPostControlProcessing()
        //{
        //    //Feedback = "You pressed the button!"
        //    //    + $" Number value is: {Num}"
        //    //    + $"  Mass text is: {MassText}"
        //    //    + $"  Favourite course with value is: {FavouriteCourse}"
        //    //    + $"  Favourite course with value is: {FavouriteCourseNoValueOnOption}";

        //    if(Num<0)
        //    {
        //        // Using ModelState
        //        ModelState.AddModelError("", $"Num value of {Num} cannot be negative");

        //        // Managing your own errors 
        //        ErrorList.Add($"Num value of {Num} cannot be negative");
        //    }

        //    if (string.IsNullOrWhiteSpace(MassText))
        //    {
        //        // Using ModelState
        //        ModelState.AddModelError("", $"MassText value cannot be empty");

        //        // Managing your own errors 
        //        ErrorList.Add($"MassText value cannot be empty");
        //    }

        //    if (FavouriteCourse == 0)
        //    {
        //        // Using ModelState
        //        ModelState.AddModelError("", $"FavouriteCourse value of {FavouriteCourse} cannot be null");

        //        // Managing your own errors 
        //        ErrorList.Add($"FavouriteCourse value of {FavouriteCourse} cannot be null");
        //    }

        //    if (FavouriteCourseNoValueOnOption == "On Screen prompt line ...")
        //    {
        //        // Using ModelState
        //        ModelState.AddModelError("", $"FavouriteCourseNoValueOnOption value cannot be null");

        //        // Managing your own errors 
        //        ErrorList.Add($"FavouriteCourseNoValueOnOption value cannot be null");
        //    }

        //    // if(ErrorList.Count()==0)
        //    if (ModelState.IsValid)      // ModelState checks for you inside the AddModelError method
        //    {
        //        Feedback = "Your data was valid.";
        //    }

        //}
        
        public IActionResult OnPostControlProcessing()
        {
            //Feedback = "You pressed the button!"
            //    + $" Number value is: {Num}"
            //    + $"  Mass text is: {MassText}"
            //    + $"  Favourite course with value is: {FavouriteCourse}"
            //    + $"  Favourite course with value is: {FavouriteCourseNoValueOnOption}";

            if (Num < 0)
            {
                // Using ModelState
                ModelState.AddModelError("", $"Num value of {Num} cannot be negative");

                // Managing your own errors 
                ErrorList.Add($"Num value of {Num} cannot be negative");
            }

            if (string.IsNullOrWhiteSpace(MassText))
            {
                // Using ModelState
                ModelState.AddModelError("", $"MassText value cannot be empty");

                // Managing your own errors 
                ErrorList.Add($"MassText value cannot be empty");
            }

            if (FavouriteCourse == 0)
            {
                // Using ModelState
                ModelState.AddModelError("", $"FavouriteCourse value of {FavouriteCourse} cannot be null");

                // Managing your own errors 
                ErrorList.Add($"FavouriteCourse value of {FavouriteCourse} cannot be null");
            }

            if (FavouriteCourseNoValueOnOption == "On Screen prompt line ...")
            {
                // Using ModelState
                ModelState.AddModelError("", $"FavouriteCourseNoValueOnOption value cannot be null");

                // Managing your own errors 
                ErrorList.Add($"FavouriteCourseNoValueOnOption value cannot be null");
            }

            // if(ErrorList.Count()==0)
            if (ModelState.IsValid)      // ModelState checks for you inside the AddModelError method
            {
                Feedback = "Your data was valid.";
            }
            return Page(); // This statement is required because we changed the return datatype from
                           //   void to IActionResult
                           // The action is to stay on the same page

        }
        public IActionResult OnPostRedirectPage()
        {
            // IActionResult requires the event to have a return statement with some type of action
            // In this example the action is to redirect to the page supplied as the supplied 
            //      parameter value
            // An alternative to using IActionResult to stay on the same page is to use Return Page;
            return RedirectToPage("BasicEvents");
        }

       
    }
}
