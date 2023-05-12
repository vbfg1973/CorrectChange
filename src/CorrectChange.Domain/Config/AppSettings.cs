namespace CorrectChange.Domain.Config
{
    public class AppSettings
    {
        /// <summary>
        ///     List of supported currencies and their denominations
        /// </summary>
        public List<CurrencyDenominationsConfig> Currencies { get; set; } = new();
    }
}