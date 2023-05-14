using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations;
using CorrectChange.Tests.Services.Change.Strategies.Data;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorrectChange.Tests.Services.Change.Strategies
{
    public class ChangeStrategyTests
    {
        /// <summary>
        ///     Ensure total number of different denominations is correct.
        ///     In this scenario we are count denomination types. Not the number of notes or coins. For example, £40 can be one
        ///     DenominationQuantity object of £10 with a Quantity of 4; or 1 of £20
        /// </summary>
        /// ///
        /// <remarks>
        ///     Currency is not used in the test but is in the method signature for context when
        ///     reading test runner output
        /// </remarks>
        /// <param name="paymentReceived"></param>
        /// <param name="price"></param>
        /// <param name="denominationCount"></param>
        /// <param name="currency"></param>
        /// <param name="currencyDenominationsConfig"></param>
        [Theory]
        [ClassData(typeof(UkSterlingGreedyStrategyDenominationCountData))]
        public void Given_Currency_Config_And_Strategy_Denomination_Type_Count_Is_Correct(decimal paymentReceived,
            decimal price, int denominationCount, Currency currency,
            CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            #region WarningSuppression

            // suppress unused warning from xunit and resulting self assignment warning.
            // Normally dangerous and to be heeded, but in this case only present for context in the test runner.
#pragma warning disable CS1717
            currency = currency;
#pragma warning restore CS1717

            #endregion

            var strategy = new GreedyPreferNotesChangeStrategy(currencyDenominationsConfig);

            var denominationQuantities = strategy.CalculateChange(price, paymentReceived).ToList();

            denominationQuantities
                .Count
                .Should()
                .Be(denominationCount);
        }

        /// <summary>
        ///     Ensure value of all change + price == paymentReceived
        /// </summary>
        /// <remarks>
        ///     Currency is not used in the test but is in the method signature for context when
        ///     reading test runner output
        /// </remarks>
        /// <param name="paymentReceived"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="currencyDenominationsConfig"></param>
        [Theory]
        [ClassData(typeof(UkSterlingPricePaymentData))]
        [ClassData(typeof(EuroPricePaymentData))]
        public void Given_Currency_Config_And_GreedyStrategy_Change_Is_Correct(decimal paymentReceived,
            decimal price, Currency currency, CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            #region WarningSuppression

            // suppress unused warning from xunit and resulting self assignment warning.
            // Normally dangerous and to be heeded, but in this case only present for context in the test runner.
#pragma warning disable CS1717
            currency = currency;
#pragma warning restore CS1717

            #endregion

            var strategy = new GreedyPreferNotesChangeStrategy(currencyDenominationsConfig);

            var denominationQuantities = strategy.CalculateChange(price, paymentReceived).ToList();

            // Total value of all change received
            var changeValue = denominationQuantities
                .Select(quantity => quantity.Denomination.Value * quantity.Quantity)
                .Sum();

            // All change + price should == payment received
            (changeValue + price)
                .Should()
                .Be(paymentReceived);
        }

        /// <summary>
        ///     Ensure value of all change + price == paymentReceived
        /// </summary>
        /// <remarks>
        ///     Currency is not used in the test but is in the method signature for context when
        ///     reading test runner output
        /// </remarks>
        /// <param name="paymentReceived"></param>
        /// <param name="price"></param>
        /// <param name="currency"></param>
        /// <param name="currencyDenominationsConfig"></param>
        [Theory]
        [ClassData(typeof(UkSterlingPricePaymentData))]
        [ClassData(typeof(EuroPricePaymentData))]
        public void Given_Currency_Config_And_GreedyStrategyNotes_Change_Is_Correct(decimal paymentReceived,
            decimal price, Currency currency, CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            #region WarningSuppression

            // suppress unused warning from xunit and resulting self assignment warning.
            // Normally dangerous and to be heeded, but in this case only present for context in the test runner.
#pragma warning disable CS1717
            currency = currency;
#pragma warning restore CS1717

            #endregion

            var strategy = new GreedyPreferCoinsChangeStrategy(currencyDenominationsConfig);

            var denominationQuantities = strategy.CalculateChange(price, paymentReceived).ToList();

            // Total value of all change received
            var changeValue = denominationQuantities
                .Select(quantity => quantity.Denomination.Value * quantity.Quantity)
                .Sum();

            // All change + price should == payment received
            (changeValue + price)
                .Should()
                .Be(paymentReceived);
        }

        /// <summary>
        ///     Ensures the change strategy factory produces the correct strategy types on request
        /// </summary>
        /// <param name="changeStrategyType"></param>
        /// <param name="strategyType"></param>
        [Theory]
        [InlineData(ChangeStrategyType.GreedyNotes, typeof(GreedyPreferNotesChangeStrategy))]
        [InlineData(ChangeStrategyType.GreedyCoins, typeof(GreedyPreferCoinsChangeStrategy))]
        public void Given_Strategy_Type_Ensure_Factory_Creates_Correct_Strategy(ChangeStrategyType changeStrategyType,
            Type strategyType)
        {
            var strategy = ChangeStrategyFactory.GetChangeStrategy(changeStrategyType, null!);

            strategy
                .GetType()
                .Should()
                .Be(strategyType);
        }

        /// <summary>
        ///     Ensures the change strategy factory throws on an unknown strategy
        /// </summary>
        /// <param name="changeStrategyType"></param>
        [Theory]
        [InlineData(ChangeStrategyType.Default)]
        public void Given_Unsupported_Strategy_Type_Ensure_Factory_Throws(ChangeStrategyType changeStrategyType)
        {
            // The currency denomination config is a suppressed null in this case cos it ought to just error
            // before passing on to some concrete strategy implementation
            Action act = () =>
                ChangeStrategyFactory.GetChangeStrategy(changeStrategyType, null!);

            act
                .Should()
                .Throw<UnsupportedChangeStrategyException>();
        }
    }
}