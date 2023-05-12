namespace CorrectChange.Domain.Models
{
    /// <summary>
    ///     Represents the coin or note, whether it is a coin or note, and the currency denominated in
    /// </summary>
    public sealed record Denomination
    {
        /// <summary>
        ///     The value of the denomination
        /// </summary>
        public decimal Value { get; init; }

        /// <summary>
        ///     The type of denomination (Coin, note, etc). Some currencies have both notes and
        ///     coins representing the same value
        /// </summary>
        public DenominationType DenominationType { get; init; }
    }
}