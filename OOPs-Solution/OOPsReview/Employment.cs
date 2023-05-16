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

        // ** Property: Title
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

        // fully implemented property
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

        // There is no validation within the property
        // There is no private data member for this property
        // The system will generate an internal storage area for the data and handle the setting & getting from that storage area
        
        // The private set means the property will only be able to be set via a constructor or method
        // Auto-implemented properties can have either a public or private set
        // Using a public or private set is a design decision

        public DateTime StartDate { get; private set; }

    }
}