﻿using CashMachineApp.Models;

namespace CashMachineApp.Interfaces
{
    /// <summary>
    /// Интерфейс определяющий работу меню выдачи средств
    /// </summary>
    interface IWithdrawCashService
    {
        int WithdrawAmount { get; set; } // Сумма выдачи
        int BanknoteDenomination { get; set; } // Выбранный номинал банкноты

        // Метод проверки на корректную выдачу (заданная сумма должна быть кратна выбранному номиналу)
        bool CheckForCorrectWithdraw(int banknoteDenomination); 
        bool CheckForTrifles(string textBoxAmountValue); // // Метод проверяющий кратность заданной суммы 10 (проверка на мелочь)

        bool DefaultWithdraw(CashMachine cashMachine); // Метод выдачи средств по умолчанию

        bool SelectedDenominationWithdraw(CashMachine cashMachine, int banknoteDenomination); // Метод выдачи средств с разменом по выбранному номиналу
    }
}
