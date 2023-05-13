using CorrectChange.Domain.Config;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeCalculator
{
    /// <summary>
    ///     Factory to produce the correct IChangeStrategy
    /// </summary>
    public static class ChangeStrategyFactory
    {
        /// <summary>
        ///     Retrieves an IChangeStrategy defined by ChangeStrategyType
        /// </summary>
        /// <param name="changeStrategyType"></param>
        /// <param name="currencyDenominationsConfig"></param>
        /// <param name="loggerFactory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IChangeStrategy GetChangeStrategy(ChangeStrategyType changeStrategyType,
            CurrencyDenominationsConfig currencyDenominationsConfig, ILoggerFactory loggerFactory)
        {
            return changeStrategyType switch
            {
                ChangeStrategyType.Greedy => new GreedyChangeStrategy(currencyDenominationsConfig, loggerFactory),
                ChangeStrategyType.GreedyWithPreferenceForNotes => new GreedyPreferNotesChangeStrategy(
                    currencyDenominationsConfig, loggerFactory),
                _ => throw new UnsupportedChangeStrategyException(nameof(changeStrategyType), changeStrategyType, null)
            };
        }
    }
}