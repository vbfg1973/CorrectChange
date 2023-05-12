using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;

namespace CorrectChange.Domain.Config
{
    public class AppSettings
    {
        /// <summary>
        ///     Change strategy to use - Defaults to Greedy
        /// </summary>
        public ChangeStrategyType ChangeStrategy { get; init; } = ChangeStrategyType.Greedy;

        /// <summary>
        ///     List of supported currencies and their denominations
        /// </summary>
        public List<CurrencyDenominationsConfig> Currencies { get; init; } = new();
    }
}