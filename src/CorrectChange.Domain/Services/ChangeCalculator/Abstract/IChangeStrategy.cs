using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Services.ChangeCalculator.Abstract
{
    /// <summary>
    ///     Abstract interface for implementing different methodologies for calculating change
    /// </summary>
    public interface IChangeStrategy
    {
        /// <summary>
        ///     Calculates the change returning a list of denomination quantity objects
        /// </summary>
        /// <param name="price"></param>
        /// <param name="paymentReceived"></param>
        /// <returns></returns>
        IEnumerable<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived);
    }
}