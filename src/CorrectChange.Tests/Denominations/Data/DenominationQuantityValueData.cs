using System.Collections;
using CorrectChange.Domain.Models;

namespace CorrectChange.Tests.Denominations.Data
{
    public class DenominationQuantityValueData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Amount
            // Quantity
            // Currency,
            // Expected
            yield return new object[] { 10, 1, Currency.Euro, 10 };
            yield return new object[] { 10, 1, Currency.UnitedStatesDollar, 10 };
            yield return new object[] { 10, 1, Currency.ChinaRenminbi, 10 };
            yield return new object[] { 10, 1, Currency.Sterling, 10 };
            yield return new object[] { 10, 1, Currency.AustraliaDollar, 10 };
            
            yield return new object[] { 10, 2, Currency.Euro, 20 };
            yield return new object[] { 10, 2, Currency.UnitedStatesDollar, 20 };
            yield return new object[] { 10, 2, Currency.ChinaRenminbi, 20 };
            yield return new object[] { 10, 2, Currency.Sterling, 20 };
            yield return new object[] { 10, 2, Currency.AustraliaDollar, 20 };
            
            yield return new object[] { 20, 1, Currency.Euro, 20 };
            yield return new object[] { 20, 1, Currency.UnitedStatesDollar, 20 };
            yield return new object[] { 20, 1, Currency.ChinaRenminbi, 20 };
            yield return new object[] { 20, 1, Currency.Sterling, 20 };
            yield return new object[] { 20, 1, Currency.AustraliaDollar, 20 };
            
            yield return new object[] { 20, 2, Currency.Euro, 40 };
            yield return new object[] { 20, 2, Currency.UnitedStatesDollar, 40 };
            yield return new object[] { 20, 2, Currency.ChinaRenminbi, 40 };
            yield return new object[] { 20, 2, Currency.Sterling, 40 };
            yield return new object[] { 20, 2, Currency.AustraliaDollar, 40 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}