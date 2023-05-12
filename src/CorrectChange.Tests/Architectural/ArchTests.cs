using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using FluentAssertions;
using NetArchTest.Rules;

namespace CorrectChange.Tests.Architectural
{
    public class ArchTests
    {
        /// <summary>
        ///     Ensure implementations of interfaces have meaningful names denoting their type
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="implementationNameEndsWith"></param>
        [Theory]
        [InlineData(typeof(IChangeStrategy), "ChangeStrategy")]
        [InlineData(typeof(IChangeCalculatorService), "ChangeCalculatorService")]
        public void Interface_Implementations_Are_Properly_Named(Type interfaceType, string implementationNameEndsWith)
        {
            Types.InCurrentDomain()
                .That()
                .ImplementInterface(interfaceType)
                .Should()
                .BeClasses()
                .And()
                .HaveNameEndingWith(implementationNameEndsWith)
                .GetResult()
                .IsSuccessful
                .Should()
                .BeTrue();
        }
    }
}