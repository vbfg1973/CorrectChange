﻿using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.Change.ChangeStrategies;
using CorrectChange.Tests.Services.Data;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorrectChange.Tests.Services
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
            var strategy = new GreedyChangeStrategy(currencyDenominationsConfig, new NullLoggerFactory());

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
        public void Given_Currency_Config_And_Strategy_Change_Is_Correct(decimal paymentReceived,
            decimal price, Currency currency, CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            var strategy = new GreedyChangeStrategy(currencyDenominationsConfig, new NullLoggerFactory());

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
    }
}