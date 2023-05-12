using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Services.ChangeCalculator.Abstract
{
    public interface IChangeStrategy
    {
        IEnumerable<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived);
    }
}