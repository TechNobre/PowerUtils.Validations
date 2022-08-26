using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.General;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.General
{
    public class GenderGeneralValidationRulesTests
    {
        [Fact]
        public void NULLGender_Validate_Valid()
        {
            // Arrange
            var fake = new FakeGender(null);


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Empty_ValidateGender_Valid()
        {
            // Arrange
            var fake = new FakeGender("");


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void MaleGender_Validate_Valid()
        {
            // Arrange
            var fake = new FakeGender("male");


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Female_ValidateGender_Valid()
        {
            // Arrange
            var fake = new FakeGender("FemalE");


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void InvalidValue_ValidateGender_Invalid()
        {
            // Arrange
            var fake = new FakeGender("op3");


            // Act
            var act = new FakeGenderValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Gender));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.INVALID);
        }

        [Fact]
        public void Other_ValidateGenderWithOther_Valid()
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

        [Fact]
        public void NotOther_ValidateGender_Invalid()
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

            act.Notifications.First().Property
                .Should()
                    .Be("Gender");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.INVALID);
        }

        [Fact]
        public void Male_ValidateGenderWithOther_Valid()
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

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Null_ValidateGenderWithOther_Valid()
        {
            // Arrange
            string gender = null;


            // Act
            var act = new ValidationsContract<string>(gender)
                .RuleFor("Gender")
                .GenderWithOther();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Empty_ValidateGenderWithOther_Valid()
        {
            // Arrange
            var gender = "";


            // Act
            var act = new ValidationsContract<string>(gender)
                .RuleFor("Gender")
                .GenderWithOther();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }
    }
}
