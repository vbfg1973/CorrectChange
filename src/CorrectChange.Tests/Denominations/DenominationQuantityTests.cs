using CorrectChange.Domain.Models;
using CorrectChange.Tests.Denominations.Data;
using FluentAssertions;

namespace CorrectChange.Tests.Denominations
{
    public class DenominationQuantityTests
    {
        [Theory]
        [ClassData(typeof(DenominationQuantityValueData))]
        public void Given_DenominationQuantity_Calculated_Value_Is_Correct(decimal amount, int quantity,
            Currency currency,
            decimal expectedValue)
        {
            var denominationQuantity = MakeDenominationQuantity(amount, quantity, currency);

            denominationQuantity
                .Value
                .Should()
                .Be(expectedValue);
        }

        /// <summary>
        ///     Everything's a note. Doesn't figure into the calculation
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="quantity"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        private static DenominationQuantity MakeDenominationQuantity(decimal amount, int quantity, Currency currency)
        {
            return new DenominationQuantity
            {
                Denomination = new Denomination
                {
                    Amount = amount,
                    Currency = currency,
                    DenominationType = DenominationType.Note
                },

                Quantity = quantity
            };
        }
    }
}