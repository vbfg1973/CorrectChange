namespace CorrectChange.Domain.Models
{
    /// <summary>
    ///     An object representing one or more of a specific denomination. For example £40 could be represented here by a
    ///     Denomination of £20 and a Quantity of 2
    /// </summary>
    public sealed record DenominationQuantity
    {
        /// <summary>
        ///     The specific denomination
        /// </summary>
        public Denomination Denomination { get; init; } = null!;

        /// <summary>
        ///     How many of the denomination
        /// </summary>
        public int Quantity { get; init; }

        /// <summary>
        ///     The total value represented by this DenominationQuantity object
        /// </summary>
        public decimal Value => Denomination.Value * Quantity;
    }
}