namespace CorrectChange.Domain.Models
{
    public sealed record DenominationQuantity
    {
        public Denomination Denomination { get; init; }
        public int Quantity { get; init; }
        public decimal Value => Denomination.Value * Quantity;
    }
}