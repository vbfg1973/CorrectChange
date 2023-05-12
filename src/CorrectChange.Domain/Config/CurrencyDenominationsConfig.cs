using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Config
{
    /// <summary>
    ///     Currency types and all their denominations
    /// </summary>
    public class CurrencyDenominationsConfig
    {
        public string CurrencyName { get; init; } = null!;
        public Currency Currency { get; init; }
        public HashSet<Denomination> Denominations { get; init; } = new();
    }
}