using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Config
{
    /// <summary>
    ///     Currency types and all their denominations
    /// </summary>
    public class CurrencyDenominationsConfig
    {
        /// <summary>
        ///     Name of the currency
        /// </summary>
        public string CurrencyName { get; init; } = null!;

        /// <summary>
        ///     Enum definition of the currency
        /// </summary>
        public Currency Currency { get; init; }

        /// <summary>
        ///     A collection of all the denominations available
        /// </summary>
        public HashSet<Denomination> Denominations { get; init; } = new();
    }
}