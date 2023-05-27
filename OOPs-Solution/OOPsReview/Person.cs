using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        // creates private FIELDS

        // ** PROPERTIES ** //
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Residence Address { get; set; } 
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();
        // creates an instance of the List so List is NOT null (there is a list available)


        // ** GREEDY CONSTRUCTOR ** //
        public Person(string firstName, string lastName, Residence address, List<Employment> employmentPositions)
        {
            //if (string.IsNullOrEmpty(firstName))
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "First name is required");
            }
            //if (string.IsNullOrEmpty(lastName))
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Last name is required");
            }
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            if (employmentPositions != null)
            {
                EmploymentPositions = employmentPositions;      // stores the supplied list of employments
            }
            // Writes data to public properties
        }

        // Default CONSTRUCTOR//
        public Person()
        {
            //EmploymentPositions = new List<Employment>();   // create an empty instance of the list
            // ^^^ this code not needed because we can create the list 

            FirstName = "unknown";
            LastName = "unknown";

        }
    }
}
