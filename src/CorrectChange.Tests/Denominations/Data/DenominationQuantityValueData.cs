using System.Collections;

namespace CorrectChange.Tests.Denominations.Data
{
    /// <summary>
    ///     Generate data for testing DenominationQuantity calculated property
    /// </summary>
    /// <returns>
    ///     Value of denomination (decimal)
    ///     Quantity of denomination (int)
    ///     Expected total value (decimal)
    /// </returns>
    public class DenominationQuantityValueData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Value, Quantity, Expected
            yield return new object[] { 10, 1, 10 };
            yield return new object[] { 10, 2, 20 };
            yield return new object[] { 20, 1, 20 };
            yield return new object[] { 20, 2, 40 };

            yield return new object[] { 0.5, 1, 0.5 };
            yield return new object[] { 0.5, 2, 1 };
            yield return new object[] { 0.1, 10, 1 };
            yield return new object[] { 0.01, 2, 0.02 };

            yield return new object[] { 0.05, 1, 0.05 };
            yield return new object[] { 0.05, 2, 0.1 };
            yield return new object[] { 0.01, 10, 0.1 };
            yield return new object[] { 0.01, 20, 0.20 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}