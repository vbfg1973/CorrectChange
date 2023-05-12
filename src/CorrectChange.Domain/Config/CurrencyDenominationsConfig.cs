using CorrectChange.Domain.Models;

namespace CorrectChange.Domain.Config
{
    public class CurrencyDenominationsConfig
    {
        public Currency Currency { get; set; }
        public List<Denomination> Denominations { get; set; } = new();
    }
}