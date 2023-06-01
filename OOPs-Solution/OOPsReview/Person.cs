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
        public string FirstName
        {
            get { return _FirstName; } 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is required");
                }
                _FirstName = value;
            }
        }
        
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name is required");
                }
                _LastName = value;
            }
        }
        
        public Residence Address { get; set; } 
        
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();
        // creates an instance of the List so List is NOT null (there is a list available)

        public string FullName { get { return LastName + ", " + FirstName; } }

        public int NumberOfEmployments { get { return EmploymentPositions.Count(); } }


        // ** GREEDY CONSTRUCTOR ** //
        public Person(string firstName, string lastName, Residence address, List<Employment> employmentPositions)
        {
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
        
        

        public void ChangeName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }


        public void AddEmployment(Employment employment)
        {
            if(employment == null)
            {
                throw new ArgumentNullException("Employment record position is required");
            }
            EmploymentPositions.Add(employment);
        }
    }
}
