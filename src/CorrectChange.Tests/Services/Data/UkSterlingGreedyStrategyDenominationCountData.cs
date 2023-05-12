using System.Collections;
using CorrectChange.Domain.Config;

namespace CorrectChange.Tests.Services.Data
{
    public class UkSterlingGreedyStrategyDenominationCountData : AbstractStrategyData, IEnumerable<object[]>
    {
        private const string FileName = "GBPDenominations.json";
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;

        public UkSterlingGreedyStrategyDenominationCountData()
        {
            _currencyDenominationsConfig = ReadCurrencyDenominationsConfig(FileName);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            // Nowt (0)
            yield return new object[]
                { 1, 1, 0, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 5x1 (1)
            yield return new object[]
                { 10, 5, 1, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 10x1 5x1 (2)
            yield return new object[]
                { 20, 5, 2, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 20x1 10x1 5x1 (3)
            yield return new object[]
                { 40, 5, 3, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 20x2 5z1
            yield return new object[]
                { 50, 5, 2, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 50x1 20x2 5x1 (3)
            yield return new object[]
                { 100, 5, 3, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 50x1 20x2 5x1 (3)
            yield return new object[]
                { 500, 5, 3, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 50x1 20x2 5x1 (3)
            yield return new object[]
                { 1000, 5, 3, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class EuroGreedyStrategyDenominationCountData : AbstractStrategyData, IEnumerable<object[]>
    {
        private const string FileName = "GBPDenominations.json";
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;

        public EuroGreedyStrategyDenominationCountData()
        {
            _currencyDenominationsConfig = ReadCurrencyDenominationsConfig(FileName);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            // Nowt (0)
            yield return new object[]
                { 1, 1, 0, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 5x1 (1)
            yield return new object[]
                { 10, 5, 1, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 10x1 5x1 (2)
            yield return new object[]
                { 20, 5, 2, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 20x1 10x1 5x1 (3)
            yield return new object[]
                { 40, 5, 3, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 20x2 5z1
            yield return new object[]
                { 50, 5, 2, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 50x1 20x2 5x1 (3)
            yield return new object[]
                { 100, 5, 3, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 200x2 50x1 20x2 5x1 (4)
            yield return new object[]
                { 500, 5, 4, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };

            // 200x2 50x1 20x2 5x1 (4)
            yield return new object[]
                { 1000, 5, 4, _currencyDenominationsConfig.Currency, _currencyDenominationsConfig };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}