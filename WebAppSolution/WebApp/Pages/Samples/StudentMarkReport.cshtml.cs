using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using WebApp.Models;  // IMPORTANT: The using statement is the NAMESPACE of your code

namespace WebApp.Pages.Samples
{
    public class StudentMarkReportModel : PageModel
    {
        public string Feedback { get; set; }
        
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }

        public List<StudentMarks> studentMarks { get; set; } = new List<StudentMarks>();

        public void OnGet()
        {
        }
    }
}
