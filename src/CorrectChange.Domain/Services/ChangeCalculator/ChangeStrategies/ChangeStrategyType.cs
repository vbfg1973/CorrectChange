namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies
{
    /// <summary>
    ///     Types of change strategy
    /// </summary>
    public enum ChangeStrategyType
    {
        /// <summary>
        ///     An unknown strategy, included here for exception testing
        /// </summary>
        Default,

        /// <summary>
        ///     The greedy strategy. Tries to give larger denominations first
        /// </summary>
        GreedyNotes,

        /// <summary>
        ///     Similar to the greedy strategy. If a currency has a coin for 1 and a note for 1, the note is always returned
        ///     instead of the coin
        /// </summary>
        GreedyCoins
    }
}