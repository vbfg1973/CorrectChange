using System.Collections;
using CorrectChange.Domain.Config;

namespace CorrectChange.Tests.Services.Data
{
    public class UkSterlingPricePaymentData : AbstractStrategyData, IEnumerable<object[]>
    {
        private const string FileName = "GBPDenominations.json";
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;

        public UkSterlingPricePaymentData()
        {
            _currencyDenominationsConfig = ReadCurrencyDenominationsConfig(FileName);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 10, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 20, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 40, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 50, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 100, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 500, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
            yield return new object[] { 1000, 5, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}