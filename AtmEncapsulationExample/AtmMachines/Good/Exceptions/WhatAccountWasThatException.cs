using System;

namespace AtmEncapsulationExample.AtmMachines.Good.Exceptions
{
    public class WhatAccountWasThatException : Exception
    {
        public int WrongAccountNumber { get; }
        public WhatAccountWasThatException(int accountNumber)
        {
            WrongAccountNumber = accountNumber;
        }
    }
}