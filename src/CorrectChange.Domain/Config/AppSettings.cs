namespace CorrectChange.Domain.Config
{
    /// <summary>
    ///     Standard app specific configuration object
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        ///     List of supported currencies and their denominations
        /// </summary>
        public List<CurrencyDenominationsConfig> Currencies { get; init; } = new();
    }
}