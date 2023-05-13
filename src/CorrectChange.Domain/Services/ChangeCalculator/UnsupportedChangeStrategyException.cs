namespace CorrectChange.Domain.Services.ChangeCalculator
{
    /// <summary>
    /// Exception for Unsupported Change Strategies
    /// </summary>
    public class UnsupportedChangeStrategyException : ArgumentOutOfRangeException
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="actualValue"></param>
        /// <param name="message"></param>
        public UnsupportedChangeStrategyException(string? paramName, object? actualValue, string? message)
        {
        }
    }
}