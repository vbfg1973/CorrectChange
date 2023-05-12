namespace CorrectChange.Domain.Services.ChangeCalculator.Exceptions
{
    public class UnknownCurrencyException : Exception
    {
        public UnknownCurrencyException()
        {
        }

        public UnknownCurrencyException(string message) : base(message)
        {
        }
    }
}