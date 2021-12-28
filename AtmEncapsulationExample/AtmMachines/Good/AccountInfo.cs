using AtmEncapsulationExample.AtmMachines.Good.Exceptions;

namespace AtmEncapsulationExample.AtmMachines.Good
{
    public class AccountInfo
    {
        public AccountInfo(int accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public int AccountNumber { get; }
        public decimal Balance { get; private set; }

        public Dosh Withdraw(int amountToWithdraw)
        {
            if (amountToWithdraw > Balance)
            {
                throw new YoureTooBrokeException();
            }

            Balance -= amountToWithdraw;
            return new Dosh {CountryOfOrigin = "NZ", Value = amountToWithdraw};
        }

        public void Deposit(Dosh amountToDeposit)
        {
            Balance += amountToDeposit.Value;
        }
    }
}