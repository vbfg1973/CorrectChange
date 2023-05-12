using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;

namespace CorrectChange.Domain.Config
{
    public class AppSettings
    {
        /// <summary>
        ///     List of supported currencies and their denominations
        /// </summary>
        public List<CurrencyDenominationsConfig> Currencies { get; init; } = new();
    }
}