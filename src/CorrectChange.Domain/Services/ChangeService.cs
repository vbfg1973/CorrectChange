using CorrectChange.Domain.Common;
using CorrectChange.Domain.Config;
using CorrectChange.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Domain.Services
{
    public interface IChangeService
    {
        IList<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived, Currency currency);
    }

    /// <summary>
    ///     Calculates change for specified currency
    /// </summary>
    public class ChangeService : IChangeService
    {
        private readonly AppSettings _appSettings;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<ChangeService> _logger;

        public ChangeService(AppSettings appSettings, ILoggerFactory loggerFactory)
        {
            _appSettings = appSettings;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<ChangeService>();
        }
        
        /// <summary>
        ///     Calculates change for the specified currency
        /// </summary>
        /// <param name="price"></param>
        /// <param name="paymentReceived"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        public IList<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived, Currency currency)
        {
            _logger.LogDebug("{Message} {Price} {PaymentReceived} {Currency}", 
                LogFmt.Message("Attempting to calculate change"),
                LogFmt.Price(price),
                LogFmt.PaymentReceived(paymentReceived),
                LogFmt.Currency(currency));
            
            throw new NotImplementedException();
            
            _logger.LogDebug("{Message} {Price} {PaymentReceived} {Currency}", 
                LogFmt.Message("Change calculated"),
                LogFmt.Price(price),
                LogFmt.PaymentReceived(paymentReceived),
                LogFmt.Currency(currency));
        }
    }
}