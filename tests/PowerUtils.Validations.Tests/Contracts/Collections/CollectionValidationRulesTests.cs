using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Collections
{
    public class CollectionValidationRulesTests
    {
        [Fact]
        public void Null_ValidateMin_Valid()
        {
            // Arrange
            List<string> list = null;
            var min = 3;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Min<List<string>, List<string>, string>(min);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void BelowMin_ValidateMin_Invalid()
        {
            // Arrange
            var list = new List<string> { "fake1", "fake2" };
            var min = 3;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Min<List<string>, List<string>, string>(min);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(min));
        }

        [Fact]
        public void Null_ValidateMax_Valid()
        {
            // Arrange
            List<string> list = null;
            var max = 1;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Max<List<string>, List<string>, string>(max);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void AboveMax_ValidateMax_Invalid()
        {
            // Arrange
            var list = new List<string> { "fake1", "fake2" };
            var max = 1;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Max<List<string>, List<string>, string>(max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(max));
        }

        [Fact]
        public void Null_ValidateRange_Valid()
        {
            // Arrange
            List<string> list = null;
            var min = 3;
            var max = 4;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Range<List<string>, List<string>, string>(min, max);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void BelowMin_ValidateRange_Invalid()
        {
            // Arrange
            var list = new List<string> { "fake1", "fake2" };
            var min = 3;
            var max = 4;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Range<List<string>, List<string>, string>(min, max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(min));
        }

        [Fact]
        public void AboveMax_ValidateRange_Invalid()
        {
            // Arrange
            var list = new List<string> { "fake1", "fake2" };
            var min = 0;
            var max = 1;


            // Act
            var act = new ValidationsContract<List<string>>(list)
                .RuleFor("fake")
                .Range<List<string>, List<string>, string>(min, max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(max));
        }
    }
}
