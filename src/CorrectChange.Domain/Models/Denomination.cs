namespace CorrectChange.Domain.Models
{
    /// <summary>
    ///     Represents the coin or note, whether it is a coin or note, and the currency denominated in
    /// </summary>
    public sealed class Denomination
    {
        /// <summary>
        ///     The value of the denomination
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     The type of denomination (Coin, note, etc)
        /// </summary>
        public DenominationType DenominationType { get; set; }

        /// <summary>
        ///     The currency of the denomination
        /// </summary>
        public Currency Currency { get; set; }
    }
}