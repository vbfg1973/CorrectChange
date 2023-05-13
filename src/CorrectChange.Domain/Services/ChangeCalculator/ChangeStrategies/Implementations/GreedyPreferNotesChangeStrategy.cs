using CorrectChange.Domain.Config;

namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations
{
    /// <summary>
    ///     Similar to the greedy strategy. If a currency has both a coin and a note for a particular denomination,
    ///     the note is always returned instead of the coin
    /// </summary>
    public class GreedyPreferNotesChangeStrategy : AbstractChangeStrategy
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="currencyDenominationsConfig"></param>
        public GreedyPreferNotesChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig) : base(
            currencyDenominationsConfig)
        {
        }
    }
}