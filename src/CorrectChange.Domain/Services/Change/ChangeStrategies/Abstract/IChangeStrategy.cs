using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Services.Change.ChangeStrategies.Abstract
{
    public interface IChangeStrategy
    {
        Denomination[] CalculateChange(decimal price, decimal paymentReceived);
    }
}