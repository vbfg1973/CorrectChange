using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeStrategies
{
    public class BruteForceChangeStrategy
    {
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;

        public BruteForceChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig, ILoggerFactory loggerFactory)
        {
            _currencyDenominationsConfig = currencyDenominationsConfig;
        }

        public Denomination[] CalculateChange(decimal price, decimal paymentReceived)
        {
            throw new NotImplementedException();
        }
    }
}