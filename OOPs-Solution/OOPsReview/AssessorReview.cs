using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    internal class AssessorReview
    {
        // This class will be used to review how and accessor can be used
        //  to control access to calculate a value

        // On a property
        //  the 'get' return a value to the calling client
        //      the value is the data associated with the property
        //      the get can have logic to caclulate the return value
        // The 'set' receives a value from the calling client
        //      the incoming value is placed into a data hold
        //      the 'data hold' is a temp space that's holding the data
        //      the set can have logic to validate the incoming data

        public int Number1 { get; set; }    // auto-implmented property
        public int Number2 { get; set; }    // auto-implmented property
        public int Add
        { 
            get
            {
                return Number1 + Number2;
            }
        }
    }
}
