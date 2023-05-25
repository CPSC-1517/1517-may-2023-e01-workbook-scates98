// See https://aka.ms/new-console-template for more information

// Ensure this CONSOLE APPLICATION knows about class by:
// 1. Select project name (Sandbox) and expand to show Dependencies
// 2. Right-click Dependencies and select Add Project Reference
// 3. Check the appropriate project class library (OOPsReview)

using OOPsReview;

Console.WriteLine("Hello, World!");

Residence myHome = new Residence(123, "Main St.", "Edmonton", "AB", "T6W3C8");
// creates an instance of a READ-ONLY Record class named 'Residence'
Console.WriteLine(myHome.ToString());
// Can a value be changed in a record instance? NO!
// myHome.Number = 321; // <-- This does NOT work (commented out)

// To alter a value in a record instance, you must create a new instance entirely
myHome = new Residence(1051, "Main St.", "Edmonton", "AB", "T6W3C8");
Console.WriteLine(myHome.ToString());


// ** EXAMPLE OF REFRACTORY ** //
// Refractory is the process of restructuring the code, while not changing
//  its original functionality. The goal of refractoring is to improve
//  internal code by making small changes without altering external
//  behaviour of the code.

// Example: original code
bool flag = false;
if (myHome.Province.ToLower() == "ab")
{
    flag = true;
}
if (myHome.Province.ToLower() == "bc")
{
    flag = true;
}
if (myHome.Province.ToLower().== "sk")
{
    flag = true;
}
if (myHome.Province.ToLower() == "mb")
{
    flag = true;
}



// Example: Refractor code (using a switch statement)
//  The following code is more efficient but does not 
//  alter the core functionality of the code
// 
// Option 1:
if (myHome.Province.ToLower() == "ab" ||
    myHome.Province.ToLower() == "bc" ||
    myHome.Province.ToLower().== "sk" ||
    myHome.Province.ToLower() == "mb")
{
    flag = true;
}

// Option 2
switch (myHome.Province.ToLower())
{
    case "ab":
    case "bc":
    case "sk":
    case "mb":
        {
            flag = true;
            break;
        }
    default:
        {
            flag = false;
        }
}
