using CorrectChange.Domain.Extensions;
using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.Abstract;
using Microsoft.Extensions.Logging;

namespace CorrectChange.Verbs.Change
{
    public class ChangeVerb
    {
        private readonly IChangeCalculatorService _changeCalculatorService;
        private readonly ILogger<ChangeVerb> _logger;

        public ChangeVerb(IChangeCalculatorService changeCalculatorService, ILogger<ChangeVerb> logger)
        {
            _changeCalculatorService = changeCalculatorService;
            _logger = logger;
        }

        public void Run(ChangeOptions options)
        {
            var changeDenominations = _changeCalculatorService.CalculateChange(
                options.Price,
                options.PaymentReceived,
                options.Currency,
                options.ChangeStrategy
            ).ToList();

            ShowOutput(options, changeDenominations);
        }

        private static void ShowOutput(ChangeOptions options, List<DenominationQuantity> changeDenominations)
        {
            Console.WriteLine($"Currency: {options.Currency}");
            Console.WriteLine();
            
            var sumOfChange = changeDenominations.SumChange();            
            Console.WriteLine($"Total change: {sumOfChange}");
            Console.WriteLine();

            foreach (var denominationQuantity in changeDenominations)
            {
                Console.WriteLine(
                    $"\t{denominationQuantity.Quantity} x {denominationQuantity.Denomination.Value} : {denominationQuantity.Denomination.DenominationType}");
            }

            Console.WriteLine();
            Console.WriteLine($"Verification: {sumOfChange} + {options.Price} = {sumOfChange + options.Price}");
        }
    }
}