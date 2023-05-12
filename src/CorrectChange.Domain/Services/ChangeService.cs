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
        public ChangeService()
        {
            
        }
        
        /// <summary>
        ///     Calculates change for the specified currency
        /// </summary>
        /// <param name="price"></param>
        /// <param name="amountTendered"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public IList<DenominationQuantity> CalculateChange(decimal price, decimal amountTendered, Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}