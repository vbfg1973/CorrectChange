using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Services.Change.ChangeStrategies.Abstract
{
    public interface IChangeStrategy
    {
        IEnumerable<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived);
    }
}