using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;

namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations
{
    /// <summary>
    ///     Similar to the greedy strategy. If a currency has both a coin and a note for a particular denomination,
    ///     the note is always returned instead of the coin
    /// </summary>
    public class GreedyPreferCoinsChangeStrategy : AbstractChangeStrategy, IChangeStrategy
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="currencyDenominationsConfig"></param>
        public GreedyPreferCoinsChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig) : base(
            currencyDenominationsConfig)
        {
            PreferredDenominationType = DenominationType.Coin;
        }
    }
}