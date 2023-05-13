using CorrectChange.Domain.Common;
using CorrectChange.Domain.Extensions;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Verbs.Change
{
    /// <summary>
    ///     The "change" verb
    /// </summary>
    public class ChangeVerb : IChangeVerb
    {
        private readonly IChangeCalculatorService _changeCalculatorService;
        private readonly ILogger<ChangeVerb> _logger;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="changeCalculatorService"></param>
        /// <param name="logger"></param>
        public ChangeVerb(IChangeCalculatorService changeCalculatorService, ILogger<ChangeVerb> logger)
        {
            _changeCalculatorService = changeCalculatorService;
            _logger = logger;
        }

        /// <summary>
        ///     Calculate the change
        /// </summary>
        /// <param name="verbOptions"></param>
        public void Run(IChangeVerbOptions verbOptions)
        {
            _logger.LogDebug("{Message} {Price} {PaymentReceived} {Currency}",
                LogFmt.Message("Calculating change"),
                LogFmt.Price(verbOptions.Price),
                LogFmt.PaymentReceived(verbOptions.PaymentReceived),
                LogFmt.Currency(verbOptions.Currency)
            );
            var changeDenominations = _changeCalculatorService.CalculateChange(
                verbOptions.Price,
                verbOptions.PaymentReceived,
                verbOptions.Currency,
                verbOptions.ChangeStrategy
            ).ToList();

            ShowOutput(verbOptions, changeDenominations);
        }

        /// <summary>
        ///     Format output for command line
        /// </summary>
        /// <param name="verbOptions"></param>
        /// <param name="changeDenominations"></param>
        private static void ShowOutput(IChangeVerbOptions verbOptions, List<DenominationQuantity> changeDenominations)
        {
            Console.WriteLine($"Currency: {verbOptions.Currency}");
            Console.WriteLine();

            var sumOfChange = changeDenominations.SumChange();
            Console.WriteLine($"Total change: {sumOfChange}");
            Console.WriteLine();

            foreach (var denominationQuantity in changeDenominations)
                Console.WriteLine(
                    $"\t{denominationQuantity.Quantity} x {denominationQuantity.Denomination.Value} : {denominationQuantity.Denomination.DenominationType}");

            Console.WriteLine();
            Console.WriteLine($"Verification: {sumOfChange} + {verbOptions.Price} = {sumOfChange + verbOptions.Price}");
        }
    }
}