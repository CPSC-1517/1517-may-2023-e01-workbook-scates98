using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        // ATTRIBUTE TITLE
        //  Fact - Does ONE test
        //      Usually set up and coded in the test

        //  Theory - Allows for multiple test data streams applied to the same test

        [Fact]
        public void Create_an_Instance_With_First_and_Last_Name()
            // create statements with meaningful name
        {
            // Arrange (setup)
            string firstName = "Chris";
            string lastName = "Cates";

            // Act (execution)
            Person sut = new Person(firstName, lastName);
                // sut = Subject Under Test

            // Assert (testing of the action / what result do you expect)
            sut.FirstName.Should().Be(firstName);
            sut.LastName.Should().Be(lastName);
        }
    }
}