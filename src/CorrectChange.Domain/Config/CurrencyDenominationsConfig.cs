using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Config
{
    /// <summary>
    ///     Currency types and all their denominations
    /// </summary>
    public class CurrencyDenominationsConfig
    {
        public string CurrencyName { get; set; } = null!;
        public Currency Currency { get; set; }
        public HashSet<Denomination> Denominations { get; set; } = new();
    }
}