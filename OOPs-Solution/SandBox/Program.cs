// See https://aka.ms/new-console-template for more information

// Ensure this CONSOLE APPLICATION knows about class by:
// 1. Select project name (Sandbox) and expand to show Dependencies
// 2. Right-click Dependencies and select Add Project Reference
// 3. Check the appropriate project class library (OOPsReview)

using OOPsReview;

Console.WriteLine("Hello, World!");

// Driver code 
// RecordSamples();
// RefactorSample();


FileIOCSV(); // Calls method for file operations

// METHOD 
void FileIOCSV()
{
    // Create a collection of employment instances to write out the data

    // creates a list of the Employment object
    List<Employment> employments = new List<Employment>();
    // adds a new instance of the Employment object (3 records)
    employments.Add(new Employment("SAS Member", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel),"TeamMember"), DateTime.Parse("2015/06/14"),3.6));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "TeamLeader"), DateTime.Parse("2019/01/24"), 2.8));
    employments.Add(new Employment("SAS Lead", (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), "Supervisor"), DateTime.Parse("2021/09/24"), 1.8));

    DumpEmployments(employments);


    Write_Employment_Collection_To_CSV(employments);

    //
    List<Employment> employmentsRead = new List<Employment>();

    employmentsRead = Read_Employment_Collection_From_CSV();

    DumpEmployments(employmentsRead);
}

// METHOD
void Write_Employment_Collection_To_CSV(List<Employment> employments)
{
    // Use the File class to append text records into a file
    // by using the file class one does not need to setup file IO stream 
    //  File IO streams (StreamWriter/StreamReader) are built into the methods
    //  of the File class


    //FILE CLASS https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-7.0
    //AppendAllText - Takes only one string
    //AppendText - 
    //WriteAllLines - 
    //Write - Overwrites all data in the specified file

    // Create the file path: D:\Temp\EmploymentData.txt
    string filepathname = @"D:\Temp\EmploymentData.txt";

    // Convert List<employment> into a List<string> (list of strings)
    List<string> emplymentCollectionAsStrings = new List<string>();
    foreach (Employment employment in employments)
    {
        emplymentCollectionAsStrings.Add(employment.ToString());
    }


    // writes the list of data from the list titled employementCollectionAsStrings
    // Appends the data
    File.AppendAllLines(filepathname, emplymentCollectionAsStrings);
}

// METHOD??
List<Employment> Read_Employment_Collection_From_CSV()
{
    // Create the file path: D:\Temp\EmploymentData.txt
    string filepathname = @"D:\Temp\EmploymentData.txt";


    Employment employmentInstance = null;
    // Convert List<employment> into a List<string> (list of strings)
    List<Employment> employmentCollection = new List<Employment>();


    try
    {
        // Read ALL lines
        // Returns an array of all lines from a file as strings
        string[] employmentCSVStrings = File.ReadAllLines(filepathname);

        // convert each string from th CSV data into an Employment Instance
        // Use the .Parse for this action

        foreach (string line in employmentCSVStrings)
        {
            try
            {
                employmentInstance = Employment.Parse(line);
                employmentCollection.Add(employmentInstance);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentOutOfRangeException ex) // is a sub Argument of ArgumentException so it CANNOT come first
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tRecord Error: {ex.Message} on data line {line}");
            }

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


    return employmentCollection;

}


// METHOD
// Dumps all records in the list
void DumpEmployments(List<Employment> employments)
{
    Console.WriteLine("\n\t\tDump of employment instances");
    for(int i = 0; i < employments.Count; i++)
    {
        Console.WriteLine($"Instance {i}:\t {employments[i].ToString()}");
    }
}


void RecordSamples()
{


    Residence myHome = new Residence(123, "Main St.", "Edmonton", "AB", "T6W3C8");
    // creates an instance of a READ-ONLY Record class named 'Residence'
    Console.WriteLine(myHome.ToString());
    // Can a value be changed in a record instance? NO!
    // myHome.Number = 321; // <-- This does NOT work (commented out)


}


 void RefactorSample()
{

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
    if (myHome.Province.ToLower() == "sk")
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
        myHome.Province.ToLower() == "sk" ||
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
                break;
            }
    }
}





