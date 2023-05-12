using CorrectChange.Domain.Config;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeCalculator
{
    public static class ChangeStrategyFactory
    {
        public static IChangeStrategy GetChangeStrategy(ChangeStrategyType changeStrategyType,
            CurrencyDenominationsConfig currencyDenominationsConfig, ILoggerFactory loggerFactory)
        {
            return changeStrategyType switch
            {
                ChangeStrategyType.Greedy => new GreedyChangeStrategy(currencyDenominationsConfig, loggerFactory),
                ChangeStrategyType.GreedyWithPreferenceForNotes => new GreedyPreferNotesChangeStrategy(
                    currencyDenominationsConfig, loggerFactory),
                _ => throw new ArgumentOutOfRangeException(nameof(changeStrategyType), changeStrategyType, null)
            };
        }
    }
}