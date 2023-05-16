using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{

    // ** UTILITIES CLASS ** //

    public static class Utilities
        // this is a shared static class
        // Static classes are NOT instantiated by the outside user (developer/code)
        // Static classes items are referenced using: classname.xxxx
        // Methods within this class have the keyword static in their signature
        // Static classes are sahred between all outside users at the same time 
        // DO NOT STORE ANYTHING IN A STATIC CLASS because you can't be certain data will be there when you use the class again
        // Consider placing GENERIC re-usable methods with a static class
    {
        // sample of a generic method: numeric is a zero or positive value
        public static bool IsZeroOrPositive(double value)
        {
            // don't put breaks in methods, loops
            // a structured method (applies to loops, etc.) will have a single entry point and a single exit point

            // IMPORTANT!!
            // AVOID where possible multiple returns from a method
            // AVOID using a 'break' to exit a loop structure or if statement

            bool valid = true;
            if (value < 0.0d)   // d = declares the 0.0 as a double, but is not needed.
                                // Any value that uses a decimal point is automatically considered as a double
            {
                valid = false;
            }
            return valid;
        }
        
        // ** OVERLOADING ** //
        // overload the IsZeroOrPositive so that it uses intgers or decimals
        // Overload takes the name and parameter list
        public static bool IsZeroOrPositive(int value)
        {
            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }

        public static bool IsZeroOrPositive(decimal value)
        {

            bool valid = true;
            if (value < 0.0m)   //m = declares the 0.0 as a decimal
            {
                valid = false;
            }
            return valid;
        }
    }
}
