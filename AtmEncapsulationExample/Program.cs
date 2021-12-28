using System;
using AtmEncapsulationExample.AtmMachines;
using AtmEncapsulationExample.AtmMachines.Crappy;
using AtmEncapsulationExample.AtmMachines.Good;
using AtmEncapsulationExample.AtmMachines.Good.Exceptions;

namespace AtmEncapsulationExample
{
    class Program
    {
        const int accountId = 12345;
        static void Main(string[] args)
        {
           
            CallGoodAtmMachine();
            CallCrappyAtmMachine();

        }

        private static void CallGoodAtmMachine()
        {
            //Call a factory to get back our atm interface implementation
            var atmMachine = AtmMachineFactory.GetAtmMachine();

            atmMachine.Login(5555);

            var balance = atmMachine.CheckBalance(accountId);

            Console.WriteLine($"I checked my balance on account #{accountId}.  The balance is now ${balance}");

            var myMoneyToSpend = atmMachine.Withdraw(20, accountId);

            Console.WriteLine($"I withdrew some money from the ATM.  I got out {myMoneyToSpend.Value}");

            balance = atmMachine.CheckBalance(accountId);

            Console.WriteLine($"I checked my balance on account #{accountId}.  The balance is now ${balance}");
        }

        private static void CallCrappyAtmMachine()
        {
            var atmMachine = new CrappyAtmMachine();
            var amountToWithdraw = 20;

            var curAccount = atmMachine.ThisJerksAccounts.Find(g => g.AccountNumber.Equals(accountId));
            if(curAccount != null)
            {
                Console.WriteLine($"I checked my balance on account #{accountId}.  The balance is now ${curAccount.Balance}");

                if (curAccount.Balance < amountToWithdraw)
                {
                    throw new YoureTooBrokeException();
                }
            }

            //Oh, so I don't have enough money, eh?  How's about I just add another bank account for myself
            // And give myself a WHOLE LOTTA Money
            Console.WriteLine($"I'll create me a a new account with way too much money in it");
            var myAccount = new AccountInfo(5678, 1000000000000);
            atmMachine.ThisJerksAccounts.Add(myAccount);

            //I'll just validate myself
            atmMachine.UserIsValidated = true;

            // Now let's withdraw a bunch of money I shouldn't have access to touch
            var account = atmMachine.ThisJerksAccounts.Find(g => g.AccountNumber.Equals(5678));
            var dosh = account.Withdraw(500000);
            Console.WriteLine($"I've just withdrawn money from a phony account I created and added to the ATM Machine!  Amount I withdrew: {dosh.Value}");
            //And finally, I'll just mess with the total amount of dosh in the machine
            atmMachine.TotalCashInTheMachine = new Dosh { CountryOfOrigin = "NZ", Value = -100000 };
            Console.WriteLine($"I just put the ATM Machine into a negative balance!  Amount in the ATM Machine now: {atmMachine.TotalCashInTheMachine.Value}");
        }


    }
}