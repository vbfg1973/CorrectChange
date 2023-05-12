using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations
{
    /// <summary>
    ///     The greedy strategy. Tries to give larger denominations first
    /// </summary>
    public class GreedyChangeStrategy : IChangeStrategy
    {
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;
        private ILogger<GreedyChangeStrategy> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="currencyDenominationsConfig"></param>
        /// <param name="loggerFactory"></param>
        public GreedyChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GreedyChangeStrategy>();
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

            // Make sure denominations come largest first
            foreach (var denomination in _currencyDenominationsConfig.Denominations.OrderByDescending(x => x.Value))
            {
                // How many times denomination fits the changeValueRemaining
                var timesInto = Convert.ToInt32(Math.Truncate(changeValueRemaining / denomination.Value));

                // Skip if not one or more
                if (timesInto < 1) continue;

                // Yield the value
                yield return new DenominationQuantity
                {
                    Denomination = denomination,
                    Quantity = timesInto
                };

                // Update value remaining
                changeValueRemaining -= timesInto * denomination.Value;
            }
        }
    }
}