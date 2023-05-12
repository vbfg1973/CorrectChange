using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Services
{
    public interface IChangeService
    {
        IList<DenominationQuantity> CalculateChange(decimal price, decimal amountTendered, Currency currency);
    }

    /// <summary>
    ///     Calculates change for specified currency
    /// </summary>
    public class ChangeService : IChangeService
    {
        public IList<DenominationQuantity> CalculateChange(decimal price, decimal amountTendered, Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}