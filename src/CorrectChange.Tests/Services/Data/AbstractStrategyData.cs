using System.Text.Json;
using System.Text.Json.Serialization;
using CorrectChange.Domain.Config;

public abstract class AbstractStrategyData
{
    protected CurrencyDenominationsConfig ReadCurrencyDenominationsConfig(string fileName)
    {
        return JsonSerializer.Deserialize<CurrencyDenominationsConfig>(
            File.ReadAllText(Path.Combine("Resources", fileName)),
            new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } })!;
    }
}