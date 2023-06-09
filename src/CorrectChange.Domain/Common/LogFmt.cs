﻿using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;

namespace CorrectChange.Domain.Common
{
    /// <summary>
    ///     Helps with providing standard formatted logs and structured logging
    /// </summary>
    public static class LogFmt
    {
        private const string MessageTag = "Message";
        private const string PriceTag = "Price";
        private const string PaymentReceivedTag = "PaymentReceived";
        private const string CurrencyTag = "Currency";
        private const string ChangeAlgorithmTag = "ChangeAlgorithm";

        /// <summary>
        ///     Tags log messages
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string Message(string message)
        {
            return $"{MessageTag}={message}";
        }

        /// <summary>
        ///     Tags payment received
        /// </summary>
        /// <param name="paymentReceived"></param>
        /// <returns></returns>
        public static string PaymentReceived(decimal paymentReceived)
        {
            return $"{PaymentReceivedTag}={paymentReceived}";
        }

        /// <summary>
        ///     Tags currencies
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public static string Currency(Currency currency)
        {
            return $"{CurrencyTag}={currency}";
        }

        /// <summary>
        ///     Tags prices
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string Price(decimal price)
        {
            return $"{PriceTag}={price}";
        }

        /// <summary>
        ///     Tags change algorithm
        /// </summary>
        /// <param name="changeStrategyType"></param>
        /// <returns></returns>
        public static string ChangeAlgorithm(ChangeStrategyType changeStrategyType)
        {
            return $"{ChangeAlgorithmTag}={changeStrategyType}";
        }
    }
}