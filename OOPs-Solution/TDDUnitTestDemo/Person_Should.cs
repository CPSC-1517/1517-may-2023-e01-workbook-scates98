using FluentAssertions;
using OOPsReview;
using System;

namespace TDDUnitTestDemo
{
    public class Person_Should
        // Adding the word: Should to the end of the class helps identify the 
        // flow of the test class in conjunction with the test methods (below)
        // eg: Person_Should Create_an_Instance_With_First_and_Last_Name <-- easy to read
    {
        #region Valid Test
        // ATTRIBUTE TITLE
        //  Fact - Does ONE test
        //      Usually set up and coded in the test

        //  Theory - Allows for multiple test data streams applied to the same test

        [Fact]
        public void Create_an_Instance_Using_Default_Constructor()
            // create statements with meaningful name
        {
            // Arrange (setup the test)
            string expectedfirstname = "unknown";
            string expectedlastname = "unknown";


            // Act (execution)
            Person sut = new Person();
                // sut = Subject Under Test

            // Assert (testing of the action / what result do you expect)
            //sut.FirstName.Should().BeNull();
            sut.FirstName.Should().Be(expectedfirstname);
            //sut.LastName.Should().BeNull();
            sut.LastName.Should().Be(expectedlastname);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_an_Instance_With_First_and_Last_Name_Residence_with_NO__List_Of_Employments()
        // create statements with meaningful name
        {
            // Arrange (setup the test)
            string firstName = "Chris";
            string lastName = "Cates";
            Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";

            // Act (execution)
            Person sut = new Person(firstName, lastName, address, null);
            // sut = Subject Under Test

            // Assert (testing of the action / what result do you expect)
            sut.FirstName.Should().Be(firstName);
            sut.LastName.Should().Be(lastName);
            sut.Address.ToString().Should().Be(expectedAddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }

       


        [Fact]
        public void Change_FirstName_to_New_Name()
        {
            // Arrange (setup the test)
            string firstName = "Chris";
            string lastName = "Cates";
            Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstName, lastName, address, null);

            string expectedFirstName = "bob";

            // Act (execution)
            me.FirstName = expectedFirstName;

            // Assert (testing of the action / what result do you expect)
            me.FirstName.Should().Be(expectedFirstName);
            
        }

        [Fact]
        public void Change_LastName_to_New_Name()
        {
            // Arrange (setup the test)
            string firstName = "Chris";
            string lastName = "Cates";
            Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstName, lastName, address, null);

            string expectedLastName = "bob";

            // Act (execution)
            me.LastName = expectedLastName;

            // Assert (testing of the action / what result do you expect)
            me.LastName.Should().Be(expectedLastName);

        }

        #endregion

        #region Invalid Data

        //[Theory]
        //// Theory allows multiple runs of the same method with different values
        //[InlineData(null, "Cates")]      // tests no firstname with lastname
        //[InlineData("Chris", null)]     // tests firstname with no lastname
        //[InlineData("", "Cates")]       // tests empty string with lastname
        //[InlineData("Chris", "")]       // tests firstname with empty string
        //[InlineData("     ", "Cates")]       // tests blank spaces with lastname
        //[InlineData("Chris", "     ")]       // tests firstname with black spaces

        //public void Create_a_Greedy_Instance_With_No_Names_Throws_Exception(string firstName, string lastName)
        //{
        //    // Arrange (setup the test)
        //    Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
        //    string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";

        //    // Act (execution)
        //    Action action = () => new Person(firstName, lastName, address, null);
        //    //              ^^^ This is a Delegate ^^^^^^^^^^^^^^^^^^^^^^^^^^^


        //    // Assert (testing of the action / what result do you expect)
        //    action.Should().Throw<ArgumentNullException>();
        //}

        //[Theory]
        //// Theory allows multiple runs of the same method with different values
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("     ")]

        //public void Throw_Exception_When_Setting_FirstName_to_Missing_Data(string firstName)
        //{
        //    // Arrange (setup the test)
        //    string lastName = "Cates";
        //    Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
        //    string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";
        //    Person me = new Person("unknown", lastName, address, null);
        //    string expectedFirstName = "unknown";

        //    // Act (execution)
        //    Action action = () => new Person(firstName, lastName, address, null);
        //    //              ^^^ This is a Delegate ^^^^^^^^^^^^^^^^^^^^^^^^^^^


        //    // Assert (testing of the action / what result do you expect)
        //    action.Should().Throw<ArgumentNullException>();
        //}

        #endregion
    }
}