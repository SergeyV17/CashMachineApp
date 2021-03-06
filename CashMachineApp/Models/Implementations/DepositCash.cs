﻿using System.Collections.Generic;
using CashMachineApp.Models.Abstractions;

namespace CashMachineApp.Models.Implementations
{
    /// <summary>
    /// Класс реализации логики внесения средств
    /// </summary>
    class DepositCash : IDepositCashService
    {
        public int DepositAmount { get; set; } // заданная сумма внесения

        /// <summary>
        /// Метод проверяющий кратность заданной суммы на 10 (проверка на мелочь)
        /// </summary>
        /// <param name="textBoxAmountValue">заданная сумма</param>
        /// <returns>признак успешной проверки</returns>
        public bool CheckForTrifles(string textBoxAmountValue)
        {
            DepositAmount = int.Parse(textBoxAmountValue);      

            return DepositAmount % 10 != 0 ? false : true;
        }

        /// <summary>
        /// Метод внесения средств в банкомат
        /// </summary>
        /// <param name="cashMachine">банкомат</param>
        /// <returns>признак успешной операции</returns>
        public bool DepositFundsToCashMachine(ICashMachine cashMachine)
        {
            // Временный список банкнот
            IList<Banknote> tempListOfBanknotes = CalculateBanknotes.DepositBanknotesByAmounOfCash(DepositAmount, cashMachine.BanknotesCountOfEachType);

            // Проверка: хватит ли места для банкнот в банкомате после внесения средств
            if (cashMachine.CurrentCountOfBanknotes + tempListOfBanknotes.Count < cashMachine.MaxCountOfBanknotes)
            {
                // Внесение средств
                foreach (var banknote in tempListOfBanknotes)
                    cashMachine.AddBanknote(banknote);

                return true;    
            }

            return false;
        }
    }
}
