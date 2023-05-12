using CorrectChange.Domain.Config;

namespace CorrectChange.Tests.Services
{
    public class ChangeServiceTests
    {
        public void Given_A_Currency_Denomination_Calculate_Correct_Change()
        {
        }

        private AppSettings FakeAnAppSettings(CurrencyDenominationsConfig currencyDenominationsConfig)
        {
            return new AppSettings
            {
                Currencies = new List<CurrencyDenominationsConfig>
                {
                    currencyDenominationsConfig
                }
            };
        }
    }
}