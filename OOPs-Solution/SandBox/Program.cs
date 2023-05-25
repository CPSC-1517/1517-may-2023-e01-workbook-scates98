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
// To alter a value in a record instance, you must create a new instance

myHome = new Residence(1051, "Main St.", "Edmonton", "AB", "T6W3C8");
Console.WriteLine(myHome.ToString());
