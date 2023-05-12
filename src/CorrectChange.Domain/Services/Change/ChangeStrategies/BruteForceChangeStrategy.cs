using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.Change.ChangeStrategies.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.Change.ChangeStrategies
{
    public class BruteForceChangeStrategy : IChangeStrategy
    {
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;
        private ILogger<BruteForceChangeStrategy> _logger;

        public BruteForceChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BruteForceChangeStrategy>();
            _currencyDenominationsConfig = currencyDenominationsConfig;
        }

        public Denomination[] CalculateChange(decimal price, decimal paymentReceived)
        {
            throw new NotImplementedException();
        }
    }
}