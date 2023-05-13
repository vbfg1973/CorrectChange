using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator;
using CorrectChange.Tests.Services.Change.Strategies.Data;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorrectChange.Tests.Services
{
    public class ChangeServiceTests
    {
        [Theory]
        [ClassData(typeof(UkSterlingGreedyStrategyDenominationCountData))]
        public void Given_A_Currency_Denomination_Counts_Are_Correct(decimal paymentReceived,
            decimal price, int denominationCount, Currency currency,
            CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            var changeService = new ChangeCalculatorService(FakeAnAppSettings(currencyDenominationsConfig),
                new NullLoggerFactory());

            var denominationQuantities = changeService.CalculateChange(price, paymentReceived, currency);
            
            denominationQuantities
                .Count
                .Should()
                .Be(denominationCount);
        }

        [Theory]
        [ClassData(typeof(UkSterlingPricePaymentData))]
        [ClassData(typeof(EuroPricePaymentData))]
        public void Given_Currency_Config_And_Strategy_Change_Is_Correct(decimal paymentReceived,
            decimal price, Currency currency, CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            var changeService = new ChangeCalculatorService(FakeAnAppSettings(currencyDenominationsConfig),
                new NullLoggerFactory());

            var denominationQuantities = changeService.CalculateChange(price, paymentReceived, currency);

            // Total value of all change received
            var changeValue = denominationQuantities
                .Select(quantity => quantity.Denomination.Value * quantity.Quantity)
                .Sum();

            // All change + price should == payment received
            (changeValue + price)
                .Should()
                .Be(paymentReceived);
        }

        private static AppSettings FakeAnAppSettings(CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            return new AppSettings
            {
                Currencies = new List<CurrencyDenominationsConfig>
                {
                    currencyDenominationsConfig
                }
            };
        }
    }
}