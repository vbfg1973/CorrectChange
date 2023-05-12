using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies.Implementations
{
    public class PreferNotesGreedyChangeStrategy : IChangeStrategy
    {
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;
        private readonly ILogger<PreferNotesGreedyChangeStrategy> _logger;

        public PreferNotesGreedyChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PreferNotesGreedyChangeStrategy>();
            _currencyDenominationsConfig = currencyDenominationsConfig;
        }

        public IEnumerable<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived)
        {
            throw new NotImplementedException();
        }
    }
}