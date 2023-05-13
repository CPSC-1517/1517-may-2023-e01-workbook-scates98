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
        // declares enum
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


    }
}