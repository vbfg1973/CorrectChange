using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.Change.ChangeStrategies.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.Change.ChangeStrategies
{
    public class PreferNotesChangeStrategy : IChangeStrategy
    {
        private readonly CurrencyDenominationsConfig _currencyDenominationsConfig;
        private readonly ILogger<PreferNotesChangeStrategy> _logger;

        public PreferNotesChangeStrategy(CurrencyDenominationsConfig currencyDenominationsConfig,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PreferNotesChangeStrategy>();
            _currencyDenominationsConfig = currencyDenominationsConfig;
        }

        public Denomination[] CalculateChange(decimal price, decimal paymentReceived)
        {
            throw new NotImplementedException();
        }
    }
}