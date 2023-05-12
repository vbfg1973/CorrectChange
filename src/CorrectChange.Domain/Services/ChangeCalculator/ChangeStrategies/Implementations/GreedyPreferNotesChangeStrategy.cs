using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations
{
    /// <summary>
    ///     Similar to the greedy strategy. If a currency has a coin for 1 and a note for 1, the note is always returned
    ///     instead of the coin
    /// </summary>
    public class GreedyPreferNotesChangeStrategy : IChangeStrategy
    {
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;
        private readonly ILogger<GreedyPreferNotesChangeStrategy> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="currencyDenominationsConfig"></param>
        /// <param name="loggerFactory"></param>
        public GreedyPreferNotesChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GreedyPreferNotesChangeStrategy>();
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
            throw new NotImplementedException();
        }
    }
}