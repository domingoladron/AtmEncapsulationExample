using System.Collections.Generic;
using AtmEncapsulationExample.AtmMachines.Good;

namespace AtmEncapsulationExample.AtmMachines.Crappy
{


    /// <summary>
    /// Our un-encapsulated ATM Machine
    /// </summary>
    public class CrappyAtmMachine 
    {
        public bool UserIsValidated { get; set; }
        public readonly List<AccountInfo> ThisJerksAccounts = new List<AccountInfo>();
        public Dosh TotalCashInTheMachine { get; set; }


        public CrappyAtmMachine()
        {
            TotalCashInTheMachine = new Dosh {CountryOfOrigin = "NZ", Value = 100000};
            var account1 = new AccountInfo(12345, 200);
            var account2 = new AccountInfo(34567, 550);
            ThisJerksAccounts.Add(account1);
            ThisJerksAccounts.Add(account2);
        }

    }
}
