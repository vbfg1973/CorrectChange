using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;

namespace CorrectChange.Domain.Services.ChangeCalculator.Abstract
{
    /// <summary>
    ///     Abstract interface for change calculator services
    /// </summary>
    public interface IChangeCalculatorService
    {
        /// <summary>
        ///     Calculates the change returning a list of denomination quantity objects
        /// </summary>
        /// <param name="price"></param>
        /// <param name="paymentReceived"></param>
        /// <param name="currency"></param>
        /// <param name="changeStrategyType"></param>
        /// <returns></returns>
        IList<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived,
            Currency currency,
            ChangeStrategyType changeStrategyType);
    }
}