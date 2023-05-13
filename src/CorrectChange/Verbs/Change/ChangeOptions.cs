using CommandLine;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;

namespace CorrectChange.Verbs.Change
{
    [Verb("change", HelpText = "Calculate change from a price and payment received")]
    public record ChangeOptions
    {
        [Option('p', nameof(Price), HelpText = "The price of the sold item", Required = true)]
        public decimal Price { get; init; }

        [Option('r', nameof(PaymentReceived), HelpText = "The payment received from the customer", Required = true)]
        public decimal PaymentReceived { get; init; }

        [Option('c', nameof(Currency), HelpText = "The currency of the transaction", Default = Currency.Sterling)]
        public Currency Currency { get; init; }

        [Option('s', nameof(ChangeStrategy), HelpText = "The change calculating algorithm to use", Default = ChangeStrategyType.Greedy)]
        public ChangeStrategyType ChangeStrategy { get; set; }
    }
}