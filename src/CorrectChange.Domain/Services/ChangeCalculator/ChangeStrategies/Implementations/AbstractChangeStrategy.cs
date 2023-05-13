using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;

namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations
{
    /// <summary>
    ///     Methods used by more than one change strategy
    /// </summary>
    public abstract class AbstractChangeStrategy : IChangeStrategy
    {
        /// <summary>
        ///     The config for the currency denominations
        /// </summary>
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;

        /// <summary>
        ///     The preferred denomination type
        /// </summary>
        protected DenominationType PreferredDenominationType = DenominationType.Note;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="currencyDenominationsConfig"></param>
        protected AbstractChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            _currencyDenominationsConfig = currencyDenominationsConfig;
        }

        /// <summary>
        ///     Returns the denomination quantities representing the change
        /// </summary>
        /// <param name="price"></param>
        /// <param name="paymentReceived"></param>
        /// <returns></returns>
        public IEnumerable<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived)
        {
            // Price is larger or equal to the payment received. No change forthcoming.
            if (price >= paymentReceived)
                yield break;

            var changeValueRemaining = paymentReceived - price;

            var denominationDictionary =
                FindDenominationsWithBothCountAndNote(_currencyDenominationsConfig.Denominations);

            // Make sure denominations come largest first
            foreach (var value in denominationDictionary.Keys.OrderDescending())
            {
                // How many times denomination fits the changeValueRemaining
                var timesInto = Convert.ToInt32(Math.Truncate(changeValueRemaining / value));

                // Skip if not one or more
                if (timesInto < 1) continue;

                // Only one denomination of this type
                if (denominationDictionary[value].Count == 1)
                    // Yield the only available denomination
                    yield return new DenominationQuantity
                    {
                        Denomination = denominationDictionary[value].First(),
                        Quantity = timesInto
                    };

                // More than one, return the right one 
                else
                    // Yield the preferred denomination
                    yield return new DenominationQuantity
                    {
                        Denomination = denominationDictionary[value]
                            .First(x => x.DenominationType == PreferredDenominationType),
                        Quantity = timesInto
                    };

                // Update value remaining
                changeValueRemaining -= timesInto * value;
            }
        }

        /// <summary>
        ///     Turn a collection of denominations into a dictionary grouped by value
        /// </summary>
        /// <param name="denominations"></param>
        /// <returns></returns>
        private static Dictionary<decimal, List<Denomination>> FindDenominationsWithBothCountAndNote(
            IEnumerable<Denomination> denominations)
        {
            return denominations
                .GroupBy(x => x.Value)
                .ToDictionary(x => x.Key, g => g.ToList());
        }
    }
}