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
        public void Create_an_Instance_With_First_and_Last_Name_Residence_with_NO_List_Of_Employments()
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
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();
            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";
            

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
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();

            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";
            string expectedLastName = "bob";

            // Act (execution)
            me.LastName = expectedLastName;

            // Assert (testing of the action / what result do you expect)
            me.LastName.Should().Be(expectedLastName);

        }


        [Fact]
        public void Change_Both_First_and_Last_Name_to_New_Name()
        {
            // Arrange
            // Arrange (setup the test)
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();

            string expectedFirstName = "pat";
            string expectedLastName = "smith";

            // Act
            me.ChangeName(expectedFirstName, expectedLastName);

            // Assert
            me.FirstName.Should().Be(expectedFirstName);
            me.LastName.Should().Be(expectedLastName);
        }

        [Fact]
        public void Return_the_FullName_of_Person()
        {
            // Arrange (setup the test)
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();

            string expectedFullName = "Cates, Chris";

            // Act (execution)
            string actual = me.FullName;
            

            // Assert (testing of the action / what result do you expect)
            actual.Should().Be(expectedFullName);
        }

        [Fact]
        public void Return_the_Number_of_Employment_Instances_For_New_Person()
        {
            // Arange (setup)
            // This tests for NO Employment Instances
            Person sut = Make_SUT_Instance();

            // Act (execution)
            int actual = sut.NumberOfEmployments;

            // Assert (testing of the action / what result do you expect)
            actual.Should().Be(0);
        }

        [Fact]
        public void Add_First_Employment_Instance()
        {
            // Arange (setup)
            // This tests for NO Employment Instances
            Person sut = Make_SUT_Instance();
            int expectedNumberOfEmployment = 1;

            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));
            // Creates an instance of Employment

            //Act (execution)
            sut.AddEmployment(employment);

            // Assert (testing of the action / what result do you expect)
            sut.NumberOfEmployments.Should().Be(expectedNumberOfEmployment);
            sut.EmploymentPositions[0].ToString().Should().Be(employment.ToString());
        }

        [Fact]
        public void Add_Another_Employment_Instance()
        {
            // Arange (setup)
            // This tests for NO Employment Instances

            string firstName = "Chris";
            string lastName = "Cates";
            Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6W3C8");

            List<Employment> employments = new List<Employment>();
            Employment emp1 = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2016, 03, 10));
            Employment emp2 = new Employment("TDD Lead", SupervisoryLevel.TeamLeader, new DateTime(2020, 03, 10));
            employments.Add(emp1);
            employments.Add(emp2);
            Person sut = new Person(firstName, lastName, address, employments);

            Employment employment = new Employment("TDD Supervisor", SupervisoryLevel.Supervisor, new DateTime(2023, 03, 10));

            int expectednumberofemployment = 3;
            List<Employment> expectedemployments = new List<Employment>()
            {
                emp1,
                emp2,
                employment
            };

            //Act (execution)
            sut.AddEmployment(employment);


            //Assert (testing of the action)
            sut.NumberOfEmployments.Should().Be(expectednumberofemployment);
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedemployments);
        }


        // ** METHOD ** //
        public Person Make_SUT_Instance()
        {
            string firstName = "Chris";
            string lastName = "Cates";
            Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstName, lastName, address, null);
            return me;
            // The above code is put into a METHOD to cut out the duplication of this code from all test procedures
        }



        #endregion

        #region Invalid Data

        [Theory]
        // Theory allows multiple runs of the same method with different values
        [InlineData(null, "Cates")]      // tests no firstname with lastname
        [InlineData("Chris", null)]     // tests firstname with no lastname
        [InlineData("", "Cates")]       // tests empty string with lastname
        [InlineData("Chris", "")]       // tests firstname with empty string
        [InlineData("     ", "Cates")]       // tests blank spaces with lastname
        [InlineData("Chris", "     ")]       // tests firstname with black spaces

        public void Create_a_Greedy_Instance_With_No_Names_Throws_Exception(string firstName, string lastName)
        {
            // Arrange (setup the test)
            Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";

            // Act (execution)
            Action action = () => new Person(firstName, lastName, address, null);
            //              ^^^ This is a Delegate ^^^^^^^^^^^^^^^^^^^^^^^^^^^


            // Assert (testing of the action / what result do you expect)
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        // Theory allows multiple runs of the same method with different values
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]

        // changing the firstName via the FirstName Property
        // Validation firstName is required. 
        public void Throw_Exception_When_Setting_FirstName_to_Missing_Data(string changeName)
        {
            // Arrange (setup the test)
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();

            //string expectedFirstName = firstName;

            // Act (execution)
            //Action action = () => new Person(firstName, lastName, address, null);
            //              ^^^ This is a Delegate ^^^^^^^^^^^^^^^^^^^^^^^^^^^

            // Act (execution)
            // Testing: Will the property capture an invalid name change
            Action action = () => me.FirstName = changeName;

            // the action will record the result of each of the samples of InlineData
            // What was the result () of the action of => me.FirstName = changeName
            // Action is a special unit testing datatype that records the results of the 
            //  executed statement into variable action statement
            //  () => for the following code execution
            //  me.FirstName = changeName  <-- Is the actual action being tested
            //          as if it were really in a program


            // Assert (testing of the action / what result do you expect)
            action.Should().Throw<ArgumentNullException>();
        }



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public void Throw_Exception_When_Setting_LastName_to_Missing_Data(string changeName)
        {
            // Arrange (setup the test)
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();


            string expectedAddress = "1051,Maple St.,Edmonton,AB,T6Y7U8";
            // Act (execution)
            // Testing: Will the property capture an invalid name change
            Action action = () => me.LastName = changeName;


            // Assert (testing of the action / what result do you expect)
            action.Should().Throw<ArgumentNullException>().WithMessage("*is required*");
        }


        [Theory]
        [InlineData(null, "Cates")]
        [InlineData("Chris", null)]
        [InlineData("", "Cates")]
        [InlineData("Chris", "")]
        [InlineData("    ", "Cates")]
        [InlineData("Chris", "     ")]
        public void Throw_Expection_When_Changing_First_And_Last_Name(string changefirstname, string changelastname)
        {
            // Arrange (setup the test)
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();



            //Act (execution) (sut subject under test)
            Action action = () => me.ChangeName(changefirstname, changelastname);

            //Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*is required*");
        }

        [Fact]
        public void Throw_Exception_When_Adding_Null_Emploment_Instance()
        {
            //Arrange (setup)
            //no employment instances
            Person sut = Make_SUT_Instance();


            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));

            //Act (execution)
            Action action = () => sut.AddEmployment(null);


            //Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*required*");
        }




        //////////////////////////////////////
        // COPIED FROM CLASS TEAMS MEETING ///
        //////////////////////////////////////
        ///

        [Theory]
        [InlineData(null, "welch")]
        [InlineData("don", null)]
        [InlineData("", "welch")]
        [InlineData("don", "")]
        [InlineData("     ", "welch")]
        [InlineData("don", "     ")]
        public void Throw_Exception_When_Changing_FirstName_And_LastName(string changedfirstname, string changedlastname)
        {

            // Arrange (setup the test)
            //string firstName = "Chris";
            //string lastName = "Cates";
            //Residence address = new Residence(1051, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            //Person sut = new Person(firstName, lastName, address, null);
            // ^^^^ Commented out because it was replaced by METHOD ^^^^^

            Person me = Make_SUT_Instance();
            
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";


            // Act Area (execution) ------ SUT means subject under test
            Action action = () => me.ChangeName(changedfirstname, changedlastname);
            ;
            // Assert Area (testing of the action)
            action.Should().Throw<ArgumentNullException>().WithMessage("*is required*");

        } // End of Throw_Exception_When_Changing_FirstName_And_LastName Test
        


        #endregion
    }
}