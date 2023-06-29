using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using WebApp.Models;  // IMPORTANT: The using statement is the NAMESPACE of your code
using System.IO;

namespace WebApp.Pages.Samples
{
    public class StudentMarkReportModel : PageModel
    {
        public string Feedback { get; set; }
        
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }

        public List<StudentMarks> studentMarks { get; set; } = new List<StudentMarks>();



        // DEPENDENCY INJECTION (using the Constructor Injection technique)
        //  a) Create a construcctor for your pagemodel class
        //  b) The services you wish to inject will be parameters on the constructor
        //  c) Save the incoming parameter values in a public property

        public IWebHostEnvironment _WebHostEnvironment { get; set; }

        public StudentMarkReportModel(IWebHostEnvironment env) //
        {
            _WebHostEnvironment = env;
        }



        public void OnGet()
        {
            // The student mark report will be loaded as the page comes up for the first time
            // Therefore, all code will be in the OnGet() event

            // Gets the path to your web app root (needed for your path to the file)
            string contentPathName = _WebHostEnvironment.ContentRootPath;  // This returns the top of the project (WebApp)
            string filePathName = Path.Combine(contentPathName, @"Data\StudentMarks.txt");
            

            // User data will contain all of the data file records (rows) in an array
            Array userdata = null;  // Creates an array to hold the data in the txt file
            // To parse the CSV record (in the TXT file) into an instance of our class,
            //      we set up a reusable variable (markRecord) capable of holding an instance of the class
            StudentMarks markRecord = null;


            try
            {
                // There is a File class in PageModel
                // To use the File class of System.IO you MUST fully qualify your reference to the class
                //      when coding the read method
                userdata = System.IO.File.ReadAllLines(filePathName);

                // Process each record in the record array
                // Each record could possibly throw and exception while Parsing
                // You should process all possible records while reporting records that could not be parsed
                // Meaning: don't stop on the first record that craps out

                foreach (string line in userdata)
                {
                    try
                    {
                        markRecord = StudentMarks.Parse(line);  // Tries to parse each line
                        if(markRecord != null)
                        {
                            studentMarks.Add(markRecord);       // Add record to collection
                        }
                    }
                    catch(FormatException ex)
                    {
                        ModelState.AddModelError("Record Format Error", $"{GetInnerException(ex).Message}: record {line}");
                    }
                    catch(Exception ex)
                    {
                        ModelState.AddModelError("System Error", $"{GetInnerException(ex).Message}: record  {line}");
                    }

                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("File Data Error", $"{GetInnerException(ex).Message}"); // Calls the Exception method to return the root exception
            }


        }


        // IMPORTANT - This method drills down to get the root exception being generated by the system
        public Exception GetInnerException(Exception ex)
        {
            while(ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
