namespace CorrectChange.Domain.Services.ChangeCalculator.Exceptions
{
    /// <summary>
    ///     For use when a currency is requested that is defined in the enum but is not in the supplied configuration
    /// </summary>
    public class UnknownCurrencyException : Exception
    {
        /// <summary>
        ///     ctor
        /// </summary>
        public UnknownCurrencyException()
        {
        }

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="message"></param>
        public UnknownCurrencyException(string message) : base(message)
        {
        }
    }
}