using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Pages.Samples
{
    public class StudentMarkInputModel : PageModel
    {
        public string Feedback { get; set; }
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }
        public IWebHostEnvironment _webHostEnvironment { get; set; }


        public List<Assessment> assessmentList { get; set; } = new List<Assessment>();

        //public StudentMarks studentRecord { get; set; }


        [BindProperty]
        public StudentMarks studentRecord { get; set; }

        [BindProperty]
        public string? FirstName { get; set; }
        [BindProperty]
        public string? LastName { get; set; }

        [BindProperty]
        public int Assessment { get; set; }

        [BindProperty]
        public int AssessmentVersion { get; set; }

        [BindProperty]
        public double Mark { get; set; }

        // CONTRUCTOR //
        public StudentMarkInputModel(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }

        public void OnGet()
        {
           PopulateAssessment();    // Calls Method
        }

        // METHODS //

        public void PopulateAssessment()
        {
            // This is to simulate obtaining data that could come from a table in a database
            assessmentList.Add(new Assessment() { Id = 1, Description = "Exercise" });       // creates an instance of Assessment and populates it with some values using initialization
            assessmentList.Add(new Assessment() { Id = 2, Description = "Lab" });            //     to access the list, call the method
            assessmentList.Add(new Assessment() { Id = 3, Description = "Assessment" });     //
            assessmentList.Add(new Assessment() { Id = 4, Description = "Project" });
            assessmentList.Add(new Assessment() { Id = 5, Description = "Quiz" });

            //Sorts the collection
            // x and y represents any two records in your collection at any point in time
            // .CompareTo will compare the property on each record
            // The deaful Sort is asscending x, y
            // To do a descending sort, switch x.property.CompareTo(y.property) around so 
            //      it would appear y.property.CompareTo(x.property)
            assessmentList.Sort((x, y) => x.Description.CompareTo(y.Description));
        }

        public IActionResult OnPostRecord()
        {
            // Form Validation
            if (string.IsNullOrWhiteSpace(studentRecord.LastName))
            {
                ModelState.AddModelError("LastName","LastName is required");
            }
            if (studentRecord.Assessment == 0)
            {
                ModelState.AddModelError("Assessment","You have not selected an assessment.");
            }

            // Check if the data has passed all validation
            if(ModelState.IsValid)
            {
                // Build an instance of StudentMarks
                //studentRecord = new StudentMarks()
                //{
                //    FirstName = FirstName,
                //    LastName = LastName,
                //    Assessment = Assessment,
                //    AssessmentVersion = AssessmentVersion,
                //    Mark = Mark
                //};



                // Create a record 
                string recordAndEndOfLine = studentRecord + "\n";


                // Next is to access and write the string to a data file
                // get the patt to your web app root
                string contentPathName = _webHostEnvironment.ContentRootPath;  // This returns the top of the project (WebApp)
                string filePathName = Path.Combine(contentPathName, @"Data\StudentMarks.txt");

                // Append to the file
                // If the file does not exist, it will be created
                System.IO.File.AppendAllText(filePathName, recordAndEndOfLine);

                OnPostClear();
                PopulateAssessment();

            }

            return Page();
        }
        public IActionResult OnPostClear()
        {
            ModelState.Clear();     // Clears all values entered on the web page (including the dynamic list (assessmentList)
            studentRecord = null;   // clear record
            //FirstName = null;
            //LastName = null;
            //Assessment = 0;
            //AssessmentVersion = 0;
            Mark = 0;

            // since the server does not remember anything that was done on this web page
            //      the last time it was procesed, you are required to ensure all 
            //      required data for the page is present.
            // Since the AssessmentList has been cleared, it needs to be recreated
            PopulateAssessment();
            return Page();
        }
        public IActionResult OnPostRedirectToReport()
        {
            
            return RedirectToPage("StudentMarkReport");
        }
    }
}
