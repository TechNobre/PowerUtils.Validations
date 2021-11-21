using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.RestAPI.Tests.Fakes.Validations.General;
using PowerUtils.Validations;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.General
{
    public class GenderGeneralValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeGender fake = new FakeGender(null);


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty()
        {
            // Arrange
            FakeGender fake = new FakeGender(string.Empty);


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid_Male()
        {
            // Arrange
            FakeGender fake = new FakeGender("male");


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid_Female()
        {
            // Arrange
            FakeGender fake = new FakeGender("FemalE");


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid()
        {
            // Arrange
            FakeGender fake = new FakeGender("op3");

            string expectedProperty = nameof(fake.Gender);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }

        [Fact(DisplayName = "Test gender with support to other with value 'Other' - Should return TRUE")]
        public void GenderWithOther_Other_ReturnTrue()
        {
            // Arrange
            var gender = "Other";


            // Act
            var act = new ValidationsContract<string>(gender)
                .RuleFor("Gender")
                .GenderWithOther();


            // Assert
            act.Valid.Should()
                .BeTrue();
        }

        [Fact(DisplayName = "Test gender with support to other with value not 'Other'  - Should return FALSE")]
        public void Gender_NotOther_ReturnFalse()
        {
            // Arrange
            var gender = "Fake";


            // Act
            var act = new ValidationsContract<string>(gender)
                .RuleFor("Gender")
                .GenderWithOther();


            // Assert
            act.Invalid.Should()
                .BeTrue();
        }

        [Fact(DisplayName = "Test gender with support to other with value 'Male' - Should return TRUE")]
        public void GenderWithOther_Male_ReturnTrue()
        {
            // Arrange
            var gender = "male";


            // Act
            var act = new ValidationsContract<string>(gender)
                .RuleFor("Gender")
                .GenderWithOther();


            // Assert
            act.Valid.Should()
                .BeTrue();
        }
    }
}