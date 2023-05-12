using CorrectChange.Domain.Common;
using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using CorrectChange.Domain.Services.ChangeCalculator.Exceptions;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services.ChangeCalculator
{
    /// <summary>
    ///     Calculates change for specified currency
    /// </summary>
    public class ChangeCalculatorService : IChangeService
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<ChangeCalculatorService> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public ChangeCalculatorService(AppSettings appSettings, ILoggerFactory loggerFactory)
        {
            _appSettings = appSettings;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<ChangeCalculatorService>();
        }

        /// <summary>
        ///     Calculates change for the specified currency
        /// </summary>
        /// <remarks>Currency will default to UK Sterling, ChangeStrategy will default to greedy</remarks>
        /// <param name="price"></param>
        /// <param name="paymentReceived"></param>
        /// <param name="currency"></param>
        /// <param name="changeStrategyType"></param>
        /// <returns></returns>
        public IList<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived,
            Currency currency = Currency.Sterling, ChangeStrategyType changeStrategyType = ChangeStrategyType.Greedy)
        {
            _logger.LogDebug("{Message} {Price} {PaymentReceived} {Currency}",
                LogFmt.Message("Attempting to calculate change"),
                LogFmt.Price(price),
                LogFmt.PaymentReceived(paymentReceived),
                LogFmt.Currency(currency));

            // If none of the defined currencies in the config match the requested, throw
            if (_appSettings.Currencies.All(curr => curr.Currency != currency))
                throw new UnknownCurrencyException($"Currency {currency.ToString()} is not defined in configuration");

            var c = _appSettings.Currencies.First(curr => curr.Currency == currency);
            var changeStrategy = ChangeStrategyFactory.GetChangeStrategy(changeStrategyType, c, _loggerFactory);

            var results = changeStrategy.CalculateChange(price, paymentReceived).ToList();

            _logger.LogDebug("{Message} {Price} {PaymentReceived} {Currency}",
                LogFmt.Message("Change calculated"),
                LogFmt.Price(price),
                LogFmt.PaymentReceived(paymentReceived),
                LogFmt.Currency(currency));

            return results;
        }
    }
}