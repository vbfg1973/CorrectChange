﻿using CorrectChange.Domain.Models;
using CorrectChange.Domain.Services.ChangeCalculator.ChangeStrategies;

namespace CorrectChange.Domain.Services.ChangeCalculator.Abstract
{
    public interface IChangeCalculatorService
    {
        IList<DenominationQuantity> CalculateChange(decimal price, decimal paymentReceived, 
            Currency currency,
            ChangeStrategyType changeStrategyType);
    }
}