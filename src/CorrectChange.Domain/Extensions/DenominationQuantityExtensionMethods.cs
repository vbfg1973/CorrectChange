using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Extensions
{
    /// <summary>
    ///     Helpers for DenominationQuantity operations
    /// </summary>
    public static class DenominationQuantityExtensionMethods
    {
        /// <summary>
        ///     Add up all change
        /// </summary>
        /// <param name="denominationQuantities"></param>
        /// <returns></returns>
        public static decimal SumChange(this IEnumerable<DenominationQuantity> denominationQuantities)
        {
            return denominationQuantities
                .Select(d => d.Quantity * d.Denomination.Value)
                .Sum();
        }
    }
}