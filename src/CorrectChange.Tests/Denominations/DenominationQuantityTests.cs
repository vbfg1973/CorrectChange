using CorrectChange.Domain.Models;
using CorrectChange.Tests.Denominations.Data;
using FluentAssertions;

namespace CorrectChange.Tests.Denominations
{
    public class DenominationQuantityTests
    {
        [Theory]
        [ClassData(typeof(DenominationQuantityValueData))]
        public void Given_DenominationQuantity_Calculated_Value_Is_Correct(decimal value, int quantity, decimal expectedValue)
        {
            var denominationQuantity = MakeDenominationQuantity(value, quantity);

            denominationQuantity
                .Value
                .Should()
                .Be(expectedValue);
        }

        /// <summary>
        ///     Everything's a note. Doesn't figure into the calculation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private static DenominationQuantity MakeDenominationQuantity(decimal value, int quantity)
        {
            return new DenominationQuantity
            {
                Denomination = new Denomination
                {
                    Value = value,
                    DenominationType = DenominationType.Note
                },

                Quantity = quantity
            };
        }
    }
}