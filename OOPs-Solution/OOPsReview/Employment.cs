using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ^^ copied from SupervisoryLevel.cs for no other reason than to keep consistency between .cs files
// 

namespace OOPsReview
{
    public class Employment
    // Renamed default "Class1.cs" file (in Visual Studio) to "Employment.cs" to change public class name (above). 
    // NOTE: The file name does NOT need to match, but it's easier to keep track of classes if you do!
    {
        // ** FIELDS ** //
        // Private Data Members for Class
        private SupervisoryLevel _Level;
        // declares enum ^^^

        private string _Title;          // default value of a string is: NULL
        private double _Years;          // default value of a numeric value is: 0


        // ** PROPERTIES ** //

        // Properties are associated with a single piece of data
        // Properties can be implemented by:
        //  a) Fully Implemented Properties
        // Fully implemented propterties usually has additional logic to execute for the control over the data; such as validation
        // Fully implemented properties will have a declared data member to store the data

        //  b) Auto Implemented Properties
        // Auto implemented properties do not have additional logic
        // Auto implemented properties do not have a declared data member to store the data.
        // Instead the Operating System will create, on the property's behalf a storage area that is accessible ONLY by using the property.

        // IMPORTANT: A property does NOT have any declared incoming parameter list!!

        // A property will ALWAYS have an Accessor, but does not require a Mutator
        // If it does not have a mutator, the property is considered "read-only" and is usually returning a computed value:
        //      example: a FullName made up of 2 pieces of data FirstName and LastName
        //      has a mutator the proptery will at some point save the data to storage
        //      the mutoator may be public (defualt) or private
        //          public: accessible by the outside users of the class
        //          privte: accessible ONLY within the class

        // ** PROPERTY: Title
        // validation: there must be a character string (not empty/null)
        public string Title
        {
            // GET / GETTER = accessor - Returns the string associated with this property (Title)
            get { return _Title; }

            // SET / SETTER = Mutator - It is within the set of validation of the data is done to determine if the data is acceptable
            // by default SET are public (but can be private if declared so)
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                    // throws an exception and stops program immediately if the conditions are met
                }
                _Title = value;
            }
        }

        // ** FULLY IMPLEMENTED PROPERTY ** //
        //
        // DO VALIDATION HERE!!

        public SupervisoryLevel Level

        {
            get { return _Level; }
            private set
            {
                // A private set means that the propterty can only be set by code within the class definition
                // This is done by using the word 'private' before 'set'
                // The advantage of doing this is: increasing security on the field as any change is under the control of the class definition

                // Validate the value given as an enum is actually defined
                // A user of this class could send in an integer value that was type cast as this enum datatype BUT have a a non-defined value

                // To test for a defined enum value, use: Enum.IsDefined(typeof(xxxx), value);
                // Where xxxx is the name of the enum datatype 

                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory Level is invalid: {value}");
                }
                _Level = value;     // assigns the current value to the private data member
            }
        }

        // Validate the years of service in the employee position as a positive value

        public double Years
        {
            get { return _Years;  }     // used on the right side of an assignment statement or in an expression
            set                         // used on the left side of an assignment statement 
            {
                //if (value < 0)        // using a utility's generic method to do this test
                if (!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException("value");
                }    
                _Years = value;         // assigns the current value to the private data member
            }

        }


        // ** AUTO-IMPLEMENTED PROPERTY ** //

        public DateTime StartDate { get; private set; }

        // There is no validation within the property
        // There is no private data member for this property
        // The system will generate an internal storage area for the data and handle the setting & getting from that storage area

        // The private set means the property will only be able to be set via a constructor or method
        // Auto-implemented properties can have either a public or private set
        // Using a public or private set is a design decision





        // ** CONSTRUCTORS ** //
        //
        // Purpose of a constructor is to create an instance of your class in a known state
        // Class dfinitions do NOT need a constructor
        // If a class definition does NOT have a constructor, then the system will create
        //  the instance and assign the system default value to each data member and/or auto-implemented property
        // If you have no constructor, the common phrase is "using a system constructor"

        // ** IMPORTANT ** IF YOU CODE A CONSTRUCTOR IN YOUR CLASS, YOU ARE RESPONSIBLE FOR CODING ALL CONSTRUCTORS FOR THE CLASS!!


        // Types of CONSTRUCTORS

        // 1. "Default" constructor
        //  Applies your own literal values for your data members and/or auto-implemented properties
        //  that differ from the system default values
        //  Why? You may have data that is validated and using the system default values which would cause and exception

        public Employment()
        {
            // This constructor will be used on creting a instance using:
            //      Employment myInstance = new Employment();
            // A practice used is to avoid referencing the data members directly especially if the property contains validation
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
            // optionally, you could set years to zero, but that is the system default value for a numeric
            // therefore, you don't need to assigna a value unless you wanted to
        }

        // 2. Greedy constructor
        // A Greedy constructor is one that accepts a parameter list of values to assign
        // to your instance data on the creation of the instance
        // generally, your greedy constructor contains a parameter on the signature for each
        // data member in your class definition

        // all default parameters must appear AFTER non-default parameter in your parameter list
        // in this example, we will use Years as an optional parameter
        public Employment(string title, SupervisoryLevel level,
            DateTime startdate, double years = 0.0)
        {
            Title = title;
            Level = level;
            Years = years;
            // this example is demonstrating where you can place validation for 
            // properties that are auto-implemented

            // Put validation right in the property
            // validate start date must not exist in the future
            // validation can be done anywhere in your class
            //  since the property is auto-implemented AND has a private set
            //  validation can be done in the constructor or a method that alters the property value
            // IF the validation is done in the property, IT WOULD NOT be an auto-implemented property
            //  but a fully-implemented property
            // .Today has a time of: 00:00:000 AM
            // .Now has a specific time of day at execution (example: 18:47:256 PM)
            //  by using the .Today.AddDays(1), you cover all times on a specific date
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate = startdate;
        }

        // ** METHODS ** //
        // Behaviours (a.k.a: Methods) 
        // A method consists of a header (accesslevel return data type (rdt) methodname (optional [list of parameters])
        //      followed by a coding block  { . . . . . . . . . }

        public void SetEmploymentResponsibilityLevel (SupervisoryLevel level)
        {
            Level = level;
            // property has a PRIVATE SET, therefore the only ways to assign a value to the Property is either:
            //  a) via the constructor at creation time
            //  b) via a PUBLIC METHOD within the class
            //
            // What about validating the value?
            // Validation can be done in multiple places
            //  a) Can be validated in the method
            //  b) Can be validated in the propterty if property fully implemented
            // 
        }


        public void CorrectStartDate(DateTime startdate)
        {
            // The StartDate Property is an Auto-Implemented Property
            // The StartDate Property has NO validation code
            // You need to do any validation on the incoming value 
            //  wherever you plan to alter the existing value in the class

            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate = startdate;

        }


        public void UpdateCurrentEmploymentYearsExperience()
        {
            TimeSpan span = DateTime.Now - StartDate;
            Years = Math.Round((span.Days / 365.25), 1);
        }


        public override string ToString()
            // override forces system to use the string in this method
        {
            return $"{Title},{Level},{StartDate.ToString("MMM, dd, yyyy")}";
            // returns the Property 'Title' 
            // DateTime is an object, thus it as a ToString built-in. Using overloading we can format the DateTime string
            // this creates a physical instance of the property

        }
            
    }
}