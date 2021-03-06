﻿namespace CashMachineApp.Models.Abstractions
{
    /// <summary>
    /// Интерфейс определяющий работу меню внесения средств
    /// </summary>
    interface IDepositCashService
    {
        int DepositAmount { get; set; } // Заданная сумма выдачи
        bool CheckForTrifles(string textBoxAmountValue); // Метод проверяющий кратность заданной суммы 10 (проверка на мелочь)
        bool DepositFundsToCashMachine(ICashMachine cashMachine); // Метод добавления банкнот в банкомат
    }
}
