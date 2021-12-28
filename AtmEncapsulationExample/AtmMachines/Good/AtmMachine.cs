using System.Collections.Generic;
using System.Linq;
using AtmEncapsulationExample.AtmMachines.Good.Exceptions;

namespace AtmEncapsulationExample.AtmMachines.Good
{
    /// <summary>
    /// Our encapsulated ATM Machine
    /// </summary>
    public class AtmMachine : IAtmMachine
    {
        private int _validPinCode = 5555;
        private bool _userValidated;
        private readonly List<AccountInfo> _thisJerksAccounts = new List<AccountInfo>();
        private readonly Dosh _totalCashInTheMachine;


        public AtmMachine()
        {
            _totalCashInTheMachine = new Dosh {CountryOfOrigin = "NZ", Value = 100000};
        }


        public void Login(int pinCode)
        {
            //Validate the person is who they say they are
            ValidateUserIsWhoTheySayTheyAre(pinCode);

            //go fetch the accounts they have
           
            var account1 = new AccountInfo(12345, 200);
            var account2 = new AccountInfo(34567, 550);
            _thisJerksAccounts.Add(account1);
            _thisJerksAccounts.Add(account2);

        }

        private bool ValidateUserIsWhoTheySayTheyAre(int pinCode)
        {
            if (pinCode != _validPinCode)
            {
                _userValidated = false;
                throw new YoureNotValidatedPalException();
            }

            _userValidated = true;
            return true;
        }

        public Dosh Withdraw(int amountToWithdraw, int accountNumber)
        {
            if (!_userValidated)
            {
                throw new YoureNotValidatedPalException();
            }

            var currentAccount = GetAccount(accountNumber);
            if (_totalCashInTheMachine.Value < amountToWithdraw)
            {
                throw new MachineOutOfDoshException();
            }


            var accountDosh =  currentAccount.Withdraw(amountToWithdraw);
            _totalCashInTheMachine.Value -= accountDosh.Value;
            return accountDosh;
        }

        public void Deposit(Dosh amountToDeposit, int accountNumber)
        {
            if (!_userValidated)
            {
                throw new YoureNotValidatedPalException();
            }

            var currentAccount = GetAccount(accountNumber);
            
            currentAccount.Deposit(amountToDeposit);
            _totalCashInTheMachine.Value += amountToDeposit.Value;
        }

        public decimal CheckBalance(int accountNumber)
        {
            if (!_userValidated)
            {
                throw new YoureNotValidatedPalException();
            }

            var currentAccount = GetAccount(accountNumber);
            return currentAccount.Balance;
        }

        public void TransferFunds(int amountToTransfer, int sourceAccountNumber, int destinationAccountNumber)
        {
            if (!_userValidated)
            {
                throw new YoureNotValidatedPalException();
            }

            var sourceAccount = GetAccount(sourceAccountNumber);
            var destinationAccount = GetAccount(destinationAccountNumber);

            destinationAccount.Deposit(sourceAccount.Withdraw(amountToTransfer));
        }

        #region private methods
        
        private AccountInfo GetAccount(int accountNumber)
        {
            var currentAccount = _thisJerksAccounts.FirstOrDefault(g => g.AccountNumber.Equals(accountNumber));
            if (currentAccount == null)
            {
                throw new WhatAccountWasThatException(accountNumber);
            }

            return currentAccount;
        }

        #endregion 

    }
}