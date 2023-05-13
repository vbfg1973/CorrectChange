using CommandLine;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;
using Microsoft.Extensions.Options;

namespace CorrectChange.Verbs.Change
{
    /// <summary>
    ///     Options for change verb
    /// </summary>
    [Verb("change", HelpText = "Calculate change from a price and payment received")]
    public record ChangeVerbOptions : IChangeVerbOptions
    {
        /// <summary>
        ///     The price of the sold item
        /// </summary>
        [Option('p', nameof(Price), HelpText = "The price of the sold item", Required = true)]
        public decimal Price { get; init; }

        /// <summary>
        ///     The payment received from the customer
        /// </summary>
        [Option('r', nameof(PaymentReceived), HelpText = "The payment received from the customer", Required = true)]
        public decimal PaymentReceived { get; init; }

        /// <summary>
        ///     The currency of the transaction
        /// </summary>
        [Option('c', nameof(Currency), HelpText = "The currency of the transaction", Default = Currency.Sterling)]
        public Currency Currency { get; init; }

        /// <summary>
        ///     The change calculating algorithm to use
        /// </summary>
        [Option('s', nameof(ChangeStrategy), HelpText = "The change calculating algorithm to use",
            Default = ChangeStrategyType.GreedyNotes)]
        public ChangeStrategyType ChangeStrategy { get; set; }
    }
}