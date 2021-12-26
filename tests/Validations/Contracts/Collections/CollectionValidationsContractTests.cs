using FluentAssertions;
using PowerUtils.Validations.Contracts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Collections
{
    public class CollectionValidationsContractTests
    {

        [Fact]
        public void List_Min_Invalid()
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

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(min));
        }

        [Fact]
        public void List_Max_Invalid()
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

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(max));
        }

        [Fact]
        public void List_RangeMin_Invalid()
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

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(min));
        }

        [Fact]
        public void List_RangeMax_Invalid()
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

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(max));
        }
    }
}