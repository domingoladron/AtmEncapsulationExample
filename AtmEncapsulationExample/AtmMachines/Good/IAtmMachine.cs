namespace AtmEncapsulationExample.AtmMachines.Good
{
    /// <summary>
    /// The public interface to our ATM Machine
    /// </summary>
    public interface IAtmMachine
    { 
        // Login with your PIN code
        void Login(int pinCode);
        // Withdraw some money
        Dosh Withdraw(int amountToWithdraw, int accountNumber);
        // Deposit some money
        void Deposit(Dosh amountToDeposit, int accountNumber);
        //Check your balance
        decimal CheckBalance(int accountNumber);
        // Transfer money from one account to another 
        void TransferFunds(int amountToTransfer, int sourceAccountNumber, int destinationAccountNumber);
    }
}
