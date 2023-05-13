using System.Globalization;
using CorrectChange.Domain.Common;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using FluentAssertions;

namespace CorrectChange.Tests.Common
{
    public class LogFmtTests
    {
        [Theory]
        [InlineData("Message", "This is a string")]
        [InlineData("Message", "This is another string")]
        public void Given_Message_String_Is_Correct(string tag, string message)
        {
            var output = LogFmt.Message(message);

            output
                .Should()
                .EndWith(message);

            output
                .Should()
                .StartWith(tag);

            output
                .Should()
                .Contain("=");

            output
                .Should()
                .Be($"{tag}={message}");
        }
        
        [Theory]
        [InlineData("Price", 0.01)]
        [InlineData("Price", 10)]
        public void Given_Price_String_Is_Correct(string tag, decimal price)
        {
            var output = LogFmt.Price(price);

            output
                .Should()
                .EndWith(price.ToString(CultureInfo.InvariantCulture));

            output
                .Should()
                .StartWith(tag);

            output
                .Should()
                .Contain("=");

            output
                .Should()
                .Be($"{tag}={price}");
        }
        
        [Theory]
        [InlineData("PaymentReceived", 0.01)]
        [InlineData("PaymentReceived", 10)]
        public void Given_PaymentReceived_String_Is_Correct(string tag, decimal paymentReceived)
        {
            var output = LogFmt.PaymentReceived(paymentReceived);

            output
                .Should()
                .EndWith(paymentReceived.ToString(CultureInfo.InvariantCulture));

            output
                .Should()
                .StartWith(tag);

            output
                .Should()
                .Contain("=");

            output
                .Should()
                .Be($"{tag}={paymentReceived}");
        }
        
        [Theory]
        [InlineData("Currency", Currency.Euro)]
        [InlineData("Currency", Currency.Sterling)]
        public void Given_Currency_String_Is_Correct(string tag, Currency currency)
        {
            var output = LogFmt.Currency(currency);

            output
                .Should()
                .EndWith(currency.ToString());

            output
                .Should()
                .StartWith(tag);

            output
                .Should()
                .Contain("=");

            output
                .Should()
                .Be($"{tag}={currency}");
        }
        
        [Theory]
        [InlineData("ChangeAlgorithm", ChangeStrategyType.Greedy)]
        [InlineData("ChangeAlgorithm", ChangeStrategyType.GreedyWithPreferenceForNotes)]
        public void Given_ChangeAlgorithm_String_Is_Correct(string tag, ChangeStrategyType changeStrategyType)
        {
            var output = LogFmt.ChangeAlgorithm(changeStrategyType);

            output
                .Should()
                .EndWith(changeStrategyType.ToString());

            output
                .Should()
                .StartWith(tag);

            output
                .Should()
                .Contain("=");

            output
                .Should()
                .Be($"{tag}={changeStrategyType}");
        }
    }
}