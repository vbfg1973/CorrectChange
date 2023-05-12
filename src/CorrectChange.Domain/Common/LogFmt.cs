using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Common
{
    public static class LogFmt
    {
        private const string MessageTag = "Message";
        private const string PriceTag = "Price";
        private const string PaymentReceivedTag = "PaymentReceived";
        private const string CurrencyTag = "Currency";

        public static string Message(string message)
        {
            return $"{MessageTag}={message}";
        }

        public static string PaymentReceived(decimal paymentReceived)
        {
            return $"{PaymentReceivedTag}={paymentReceived}";
        }

        public static string Currency(Currency currency)
        {
            return $"{CurrencyTag}={currency}";
        }

        public static string Price(decimal price)
        {
            return $"{PriceTag}={price}";
        }
    }
}