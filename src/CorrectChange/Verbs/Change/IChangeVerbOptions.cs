using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using CorrectChange.Verbs.Abstract;

namespace CorrectChange.Verbs.Change
{
    /// <summary>
    ///     Abstract change options
    /// </summary>
    public interface IChangeVerbOptions : IVerbOptions
    {
        /// <summary>
        ///     The price of the sold item
        /// </summary>
        decimal Price { get; init; }

        /// <summary>
        ///     The payment received from the customer
        /// </summary>
        decimal PaymentReceived { get; init; }

        /// <summary>
        ///     The currency of the transaction
        /// </summary>
        Currency Currency { get; init; }

        /// <summary>
        ///     The change calculating algorithm to use
        /// </summary>
        ChangeStrategyType ChangeStrategy { get; set; }
    }
}